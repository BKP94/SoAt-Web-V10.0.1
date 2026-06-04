using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace sc
{
    /// <summary>
    /// sc.log — bridge เดิมเรียก addLine(string) แบบ static ได้เหมือนเดิม
    /// ตอนเริ่ม app ให้เรียก sc.log.init(loggerFactory) ใน Program.cs
    /// </summary>
    public class log
    {
        public const string lineMain = "--------------- ";

        // Static logger สำหรับ backward-compatible static addLine()
        private static ILogger? _logger;
        private static bool _active;

        public static void init(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("sc");
            _active = true;
        }

        public static bool _isActive
        {
            get => _active;
            set => _active = value;
        }

        public static void addLine(string lineText, Stopwatch? _ = null)
        {
            if (!_active) return;
            _logger?.LogDebug("{Line}", lineText);
        }
        public static void addLineNest(string lineText, Stopwatch? _ = null)
        {
            if (!_active) return;
            _logger?.LogDebug("[NEST] {Line}", lineText);
        }
    }
}
