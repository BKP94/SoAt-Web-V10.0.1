using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace sc
{
    public class json
    {
        // ─── decode ───────────────────────────────────────────────────────────────

        static object? _decode(object? json)
        {
            if (json == null) return null;

            if (json is JObject jo)
            {
                var dict = new Dictionary<string, object?>();
                foreach (var pair in jo)
                {
                    dict[pair.Key] = _decode(JsonConvert.DeserializeObject(pair.Value!.ToString()));
                }
                return dict;
            }

            if (json is JArray ja)
            {
                if (ja.Count == 2 && ja[0].ToString().StartsWith("#"))
                {
                    string type = ja[0].ToString()[1..];
                    return type switch
                    {
                        att.datatype.jsUndefined => null,
                        att.datatype.jsDate      => value.toDate(ja[1]),
                        att.datatype.jsBoolean   => value.toBoolean(ja[1]),
                        att.datatype.jsArray     => _decode(JsonConvert.DeserializeObject(ja[1].ToString())),
                        att.datatype.jsNumber    => _decodeNumber(ja[1].ToString()),
                        _                        => value.toString(ja[1]),
                    };
                }
                var list = new List<object?>();
                foreach (var item in ja)
                    list.Add(_decode(item));
                return list;
            }

            return null;
        }

        static object _decodeNumber(string s)
        {
            var clean = Regex.Replace(s, "[,%]", "");
            if (s.Contains('.')) return value.toDecimal(clean);
            if (int.TryParse(clean, out _)) return value.toInteger(clean);
            return value.toDecimal(clean);
        }

        public static object? decode(object? json)
            => _decode(JsonConvert.DeserializeObject((json ?? string.Empty).ToString()!));

        // ─── encode ───────────────────────────────────────────────────────────────

        public static string encode(object? v)
        {
            if (v == null || v is DBNull)
                return $"[\"#{att.datatype.jsUndefined}\",\"null\"]";

            if (v is string s)
                return $"[\"#{att.datatype.jsString}\",\"{s}\"]";

            if (sc.value.isNumeric(v.GetType()))
                return $"[\"#{att.datatype.jsNumber}\",\"{v}\"]";

            if (v is bool b)
                return $"[\"#{att.datatype.jsBoolean}\",\"{(b ? "true" : "false")}\"]";

            if (v is DateTime)
                return $"[\"#{att.datatype.jsDate}\",\"{sc.value.toStringEN(v, true)}\"]";

            if (v is Array || v.GetType().Name.StartsWith("List"))
            {
                var parts = new List<string>();
                if (v is Array arr) foreach (object o in arr) parts.Add(encode(o));
                else if (v is List<int>     li) foreach (int     o in li) parts.Add(encode(o));
                else if (v is List<string>  ls) foreach (string  o in ls) parts.Add(encode(o));
                else if (v is List<decimal> ld) foreach (decimal o in ld) parts.Add(encode(o));
                else if (v is List<double>  lf) foreach (double  o in lf) parts.Add(encode(o));
                else if (v is List<DateTime> ldt) foreach (DateTime o in ldt) parts.Add(encode(o));
                else if (v is List<object>  lo) foreach (object  o in lo) parts.Add(encode(o));
                else throw new Exception("E95:Not supported type: " + v.GetType().Name);
                return $"[\"#{att.datatype.jsArray}\",[{string.Join(",", parts)}]]";
            }

            if (v is Dictionary<string, object> dict)
            {
                var parts = dict.Select(p => $"\"{p.Key}\":{encode(p.Value)}");
                return "{" + string.Join(",", parts) + "}";
            }

            return string.Empty;
        }

        // ─── getService (WebRequest → HttpClient) ─────────────────────────────────

        public static object? getService(string url)
        {
            try
            {
                using var client   = new HttpClient();
                using var request  = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content    = new StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                using var response = client.Send(request);
                var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jObject = JObject.Parse(result);
                var d = jObject["d"];
                if (d == null) return null;
                if (d.ToString().StartsWith("{"))
                {
                    var vals = new Dictionary<string, object?>();
                    foreach (var pc in JObject.Parse(d.ToString()))
                        vals[pc.Key] = pc.Value;
                    return vals;
                }
                return d;
            }
            catch { return null; }
        }

        // ─── helpers ──────────────────────────────────────────────────────────────

        public static Dictionary<string, TValue>? ToDictionary<TValue>(object obj)
        {
            var js = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<Dictionary<string, TValue>>(js);
        }
    }
}
