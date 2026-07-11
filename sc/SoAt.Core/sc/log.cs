using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace sc
{
    /// <summary>
    /// sc.log — bridge เดิมเรียก addLine(string) แบบ static ได้เหมือนเดิม
    /// ตอนเริ่ม app ให้เรียก sc.log.init(loggerFactory, appName, logDir) ใน Program.cs
    ///
    /// File sink (ตาม legacy C:\SoAt_TNMA\sc\log.cs):
    ///   legacy เขียน {pathSolution}\logs\{appName}-{loginUser}-{sessionId}.txt ผ่าน sc.file.streamWriter
    ///   Blazor ไม่มี page/session lifecycle แบบ Web Forms → ปรับเป็นไฟล์ต่อรอบรัน app:
    ///   {logDir}\{appName}-{yyyyMMdd-HHmmss}.txt (timestamp จับตอน init ครั้งเดียว;
    ///   append; streamWriter มี retry กัน lock เหมือน legacy)
    ///   format บรรทัด = "yyyyMMdd-HH:mm:ss.fff <ข้อความ>" ตาม legacy เป๊ะ
    /// </summary>
    public class log
    {
        public const string lineMain = "--------------- ";

        // Static logger สำหรับ backward-compatible static addLine()
        private static ILogger? _logger;
        private static bool _active;

        // File sink — เปิดเมื่อ init ส่ง logDir มา (ทุก module ชี้ logs\ ที่ root solution ร่วมกัน)
        private static string? _appName;
        private static string? _logDir;
        private static string? _initStamp;   // วันที่-เวลา ตอน init (ครั้งเดียวต่อ app start) → 1 รอบรัน = 1 ไฟล์

        // gate ต่อ user ตาม legacy setActive(): เขียนไฟล์เฉพาะ user ที่ programmer='1' (si_security_user)
        // AsyncLocal = per-async-flow — Blazor Server หลาย user ใช้ process เดียวกัน (static ตัวเดียวจะปนข้าม user)
        // dbFactory.create เป็นคนเซ็ตค่านี้ (ตรวจ programmer + cache ต่อ user)
        private static readonly AsyncLocal<bool?> _userActive = new();
        public static void setUserActive(bool active) => _userActive.Value = active;

        public static void init(ILoggerFactory factory, string? appName = null, string? logDir = null)
        {
            _logger  = factory.CreateLogger("sc");
            _appName = appName;
            _logDir  = logDir;
            // InvariantCulture — เครื่อง culture ไทยจะได้ปี พ.ศ. ในชื่อไฟล์ (25690712) → บังคับ ค.ศ.
            _initStamp = DateTime.Now.ToString("yyyyMMdd-HHmmss", System.Globalization.CultureInfo.InvariantCulture);
            _active  = true;
        }

        public static bool _isActive
        {
            get => _active;
            set => _active = value;
        }

        // ไฟล์ต่อรอบรัน: logs\{appName}-{yyyyMMdd-HHmmss ตอน app start}.txt (แทน legacy {appName}-{loginUser}-{sessionId}.txt)
        static string? _pathFile
            => string.IsNullOrWhiteSpace(_logDir) || string.IsNullOrWhiteSpace(_appName)
                ? null
                : Path.Combine(_logDir!, $"{_appName}-{_initStamp}.txt");

        // timestamp หน้าบรรทัด format เดียวกับ legacy: "yyyyMMdd-HH:mm:ss.fff "
        static string _time
            => DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') +
               "-" + DateTime.Now.ToString("HH:mm:ss.fff ");

        public static void addLine(string lineText, Stopwatch? _ = null)
        {
            if (!_active) return;
            _logger?.LogDebug("{Line}", lineText);

            var pathFile = _pathFile;
            if (_userActive.Value == true && !string.IsNullOrWhiteSpace(pathFile))
                sc.file.streamWriter(pathFile, _time + lineText);
        }
        public static void addLineNest(string lineText, Stopwatch? _ = null)
        {
            if (!_active) return;
            _logger?.LogDebug("[NEST] {Line}", lineText);

            var pathFile = _pathFile;
            if (_userActive.Value == true && !string.IsNullOrWhiteSpace(pathFile))
                sc.file.streamWriter(pathFile, _time + "[NEST] " + lineText);
        }
    }
}
