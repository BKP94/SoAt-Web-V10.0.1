using Microsoft.Extensions.Configuration;

namespace sc
{
    public class app
    {
        public const string MAIN_SITE_NAME    = "PEAN";
        public const string MESSAGE_ERROR_MORE = "MESSAGE_ERROR_MORE";

        public enum attSeting { app, login, version, Error2Email, coop }

        private static IConfiguration? _config;

        // CHANGED: was WebConfigurationManager.AppSettings — now requires init() at startup
        public static void init(IConfiguration configuration) => _config = configuration;

        public static string getAppSettings(attSeting key, string? defaultValue = null)
            => getAppSettings(key.ToString(), defaultValue);

        public static string getAppSettings(string key, string? defaultValue = null)
            => _config?[key] ?? defaultValue ?? string.Empty;

        // อ่าน connection string จาก section ConnectionStrings (เช่น "repConnection" ที่ sc.report ใช้)
        public static string getConnectionString(string name)
            => _config?.GetConnectionString(name) ?? string.Empty;

        // CHANGED: legacy fallback ไป System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName()
        //          ถูกตัด (ไม่มีบน net10/Blazor) → อ่านจาก config key "app" อย่างเดียว
        //          แต่ละ Blazor app ตั้ง "app": "<ชื่อ module>" ใน appsettings.json (เช่น scReport)
        public static string appName => getAppSettings(attSeting.app);
    }
}
