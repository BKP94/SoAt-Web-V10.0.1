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
    }
}
