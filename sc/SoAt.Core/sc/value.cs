using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace sc
{
    public class value
    {
        public const string ValueChecked   = "1";
        public const string ValueUnchecked = "0";

        // ─── Type checks ─────────────────────────────────────────────────────────

        public static bool isValueDate(object s)
        {
            object v = s;
            if (v is string str)
            {
                if (string.IsNullOrWhiteSpace(str)) return false;
                var parts = str.Split('/', '-', ':', ' ');
                if (parts.Length == 0) return false;
                var items = new List<int>();
                foreach (var p in parts)
                {
                    if (p.Trim().Length > 0)
                    {
                        if (int.TryParse(p, out int n)) items.Add(n);
                        else return true;
                    }
                }
                return items.Count > 0;
            }
            return v != null;
        }

        public static bool isNumeric(object s)
        {
            if (s == null || s is DBNull) return false;
            return isNumeric(s.GetType());
        }
        public static bool isNumeric(Type t) => isNumericInt(t) || isNumericDec(t);
        public static bool isNumericInt(Type? t)
        {
            if (t == null) return false;
            return Type.GetTypeCode(t) switch
            {
                TypeCode.Byte or TypeCode.SByte or TypeCode.UInt16 or TypeCode.UInt32
                    or TypeCode.UInt64 or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 => true,
                _ => false
            };
        }
        public static bool isNumericDec(Type? t)
        {
            if (t == null) return false;
            return Type.GetTypeCode(t) switch
            {
                TypeCode.Decimal or TypeCode.Double or TypeCode.Single => true,
                _ => false
            };
        }
        public static bool isNumberAllChar(object s)
        {
            var text = toString(s);
            return isValidText(text) && decimal.TryParse(text, out _);
        }
        public static bool isValidText(object s) => !string.IsNullOrWhiteSpace(toString(s));
        public static bool isValidKey(Dictionary<string, object> s, string keyName)
        {
            if (s == null) throw new Exception("C110:Invalid Dictionary");
            if (string.IsNullOrWhiteSpace(keyName)) throw new Exception("C111:Invalid keyName=" + keyName);
            return s.ContainsKey(keyName) || s.ContainsKey(keyName.ToLower()) || s.ContainsKey(keyName.ToUpper());
        }
        public static bool isAllowExtensionImg(string fileName)
            => new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" }.Contains(Path.GetExtension(fileName.ToLower()));
        public static bool isAllowExtensionMS(string fileName)
            => new[] { ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".rtf" }.Contains(Path.GetExtension(fileName.ToLower()));
        public static bool isAllowExtensionTif(string fileName)
            => new[] { ".tif", ".tiff" }.Contains(Path.GetExtension(fileName.ToLower()));
        public static bool isEqual(Type type, object valOld, object valNew)
        {
            if (isNumeric(type)) return toDecimal(valOld) == toDecimal(valNew);
            if (type == typeof(DateTime))
            {
                var d1 = toDate(valOld); var d2 = toDate(valNew);
                if (d1 == null && d2 == null) return true;
                if (d1 != null && d2 != null) return d1.Equals(d2);
                return false;
            }
            bool nullOld = valOld == null || valOld == DBNull.Value || (valOld is string so && string.IsNullOrEmpty(so));
            bool nullNew = valNew == null || valNew == DBNull.Value || (valNew is string sn && string.IsNullOrEmpty(sn));
            if (nullOld && nullNew) return true;
            if (!nullOld && !nullNew) return valOld!.Equals(valNew);
            return false;
        }

        // ─── Date helpers ─────────────────────────────────────────────────────────

        public static DateTime getFirstDayOfMonth(DateTime d) => new(d.Year, d.Month, 1);
        public static DateTime getLastDayOfMonth(DateTime d) => new(d.Year, d.Month, DateTime.DaysInMonth(d.Year, d.Month));

        // ─── toString ─────────────────────────────────────────────────────────────

        public static string toString(object? s)
        {
            if (s == null || s is DBNull) return string.Empty;
            if (s is DateTime dt) return dt.ToString("dd/MM/yyyy");
            if (s is bool b) return b ? ValueChecked : ValueUnchecked;
            return s.ToString() ?? string.Empty;
        }
        public static string toString(decimal s) => s.ToString("N2");
        public static string toString(Dictionary<string, object> s, string key)
        {
            if (s == null || string.IsNullOrWhiteSpace(key)) return string.Empty;
            if (s.TryGetValue(key, out var v)) return toString(v);
            if (s.TryGetValue(key.ToLower(), out v)) return toString(v);
            if (s.TryGetValue(key.ToUpper(), out v)) return toString(v);
            return string.Empty;
        }
        public static string toString(DataRow? dr, string colName)
        {
            if (dr == null || string.IsNullOrWhiteSpace(colName)) return string.Empty;
            if (dr.Table.Columns.Contains(colName)) return toString(dr[colName]);
            return string.Empty;
        }

        // ─── toStringTH (Thai Buddhist calendar) ──────────────────────────────────

        public static string toStringTH(object? s, bool withTime = false)
        {
            var d = toDate(s);
            if (d == null) return string.Empty;
            var dt2 = (DateTime)d;
            var cal = new ThaiBuddhistCalendar();
            var year = cal.GetYear(dt2);
            var str = $"{dt2.Day:D2}/{dt2.Month:D2}/{year}";
            if (withTime) str += $" {dt2:HH:mm:ss}";
            return str;
        }
        public static string toStringEN(object? s, bool withTime = false)
        {
            var d = toDate(s);
            if (d == null) return string.Empty;
            var dt2 = (DateTime)d;
            return withTime ? dt2.ToString("dd/MM/yyyy HH:mm:ss") : dt2.ToString("dd/MM/yyyy");
        }
        public static string toStringF(object? s, string? colType = null)
        {
            if (s == null || s is DBNull) return string.Empty;
            if (colType == att.datatype.Decimal || (colType == null && (s is decimal || s is double || s is float)))
                return toDecimal(s).ToString("N2");
            if (colType == att.datatype.Integer)
                return toInteger(s).ToString("N0");
            if (colType == att.datatype.Date || s is DateTime)
                return toStringTH(s);
            return toString(s);
        }

        // ─── toBoolean ────────────────────────────────────────────────────────────

        public static bool toBoolean(object? s)
        {
            if (s == null || s is DBNull) return false;
            if (s is bool b) return b;
            var str = toString(s).Trim().ToLower();
            return str == "1" || str == "true" || str == "yes" || str == "y";
        }
        public static bool toBoolean(Dictionary<string, object> s, string key) => toBoolean(toString(s, key));
        public static bool toBoolean(DataRow? dr, string col) => toBoolean(toString(dr, col));

        // ─── toInteger ────────────────────────────────────────────────────────────

        public static int toInteger(object? s)
        {
            if (s == null || s is DBNull) return 0;
            if (s is int i) return i;
            if (s is long l) return (int)l;
            if (s is decimal dec) return (int)dec;
            if (int.TryParse(toString(s).Replace(",", ""), out var n)) return n;
            return 0;
        }
        public static int toInteger(Dictionary<string, object> s, string key) => toInteger(toString(s, key));
        public static int toInteger(DataRow? dr, string col) => toInteger(toString(dr, col));

        // ─── toDecimal ────────────────────────────────────────────────────────────

        public static decimal toDecimal(object? s)
        {
            if (s == null || s is DBNull) return 0m;
            if (s is decimal d) return d;
            if (decimal.TryParse(toString(s).Replace(",", ""), out var n)) return n;
            return 0m;
        }
        public static decimal toDecimal(Dictionary<string, object> s, string key) => toDecimal(toString(s, key));
        public static decimal toDecimal(DataRow? dr, string col) => toDecimal(toString(dr, col));

        // ─── toDate ───────────────────────────────────────────────────────────────

        public static object? toDate(object? s)
        {
            if (s == null || s is DBNull) return null;
            if (s is DateTime dt) return dt;
            var str = toString(s).Trim();
            if (string.IsNullOrWhiteSpace(str)) return null;

            // ลองแปลง Thai Buddhist year dd/MM/YYYY ที่ปีเป็น พ.ศ.
            if (DateTime.TryParseExact(str, new[]
                { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd", "dd-MM-yyyy", "dd/MM/yyyy HH:mm:ss" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
            {
                // ถ้าปีเป็น พ.ศ. (> 2500) ให้แปลงกลับ
                if (parsed.Year > 2500)
                    return new DateTime(parsed.Year - 543, parsed.Month, parsed.Day,
                        parsed.Hour, parsed.Minute, parsed.Second);
                return parsed;
            }
            return null;
        }

        // ─── toList ───────────────────────────────────────────────────────────────

        public static List<string> toList(string s, char separator = '/')
        {
            if (string.IsNullOrWhiteSpace(s)) return new();
            return s.Split(separator).Select(x => x.Trim()).ToList();
        }
        public static List<object> toList(object? s)
        {
            if (s == null) return new();
            if (s is List<object> lo) return lo;
            return new() { s };
        }

        // ─── toDictionary ─────────────────────────────────────────────────────────

        public static Dictionary<string, object> toDictionary(string s, char separator = '/')
        {
            var d = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (string.IsNullOrWhiteSpace(s)) return d;
            foreach (var item in s.Split(separator))
            {
                var idx = item.IndexOf('=');
                if (idx > 0)
                    d[item[..idx].Trim()] = item[(idx + 1)..].Trim();
            }
            return d;
        }
        public static Dictionary<string, object> toDictionary(DataRow dr)
        {
            var d = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            foreach (DataColumn col in dr.Table.Columns)
                d[col.ColumnName] = dr[col] is DBNull ? null! : dr[col];
            return d;
        }
        public static Dictionary<string, object> toDictionary(List<Dictionary<string, object>> rows, string keyCol)
        {
            var d = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            foreach (var row in rows)
                d[toString(row, keyCol)] = row;
            return d;
        }

        // ─── SQL helpers ──────────────────────────────────────────────────────────

        public static string dbValueT(object? s)
        {
            if (s == null || s is DBNull) return "null";
            if (s is bool b) return b ? "1" : "0";
            if (s is DateTime dt) return $"'{dt:yyyy-MM-dd HH:mm:ss}'";
            if (isNumeric(s)) return s.ToString()!;
            return $"'{s.ToString()!.Replace("'", "''")}'";
        }

        public static string sqlArgs(string sqlQuery, params object?[] args)
        {
            if (args == null || args.Length == 0) return sqlQuery;
            var sql = sqlQuery;
            // Replace from highest index to lowest to avoid partial replacements
            for (int i = args.Length - 1; i >= 0; i--)
                sql = sql.Replace($"{{{i}}}", dbValueT(args[i]));
            return sql;
        }

        public static string sqlWhere(string sqlQuery, string? where, params object?[] args)
        {
            var whereStr = string.IsNullOrWhiteSpace(where) ? string.Empty : where;
            var sql = sqlQuery.Replace(db._WHERE, whereStr);
            return sqlArgs(sql, args);
        }

        // ─── toMask ───────────────────────────────────────────────────────────────

        public static string toMask(string value, string mask)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            var digits = Regex.Replace(value, @"\D", "");
            var result = new System.Text.StringBuilder();
            int di = 0;
            foreach (char c in mask)
            {
                if (c == '9') { if (di < digits.Length) result.Append(digits[di++]); }
                else result.Append(c);
            }
            return result.ToString();
        }
        public static string toMaskIDCard(string value) => toMask(value, "9-9999-99999-99-9");
    }
}
