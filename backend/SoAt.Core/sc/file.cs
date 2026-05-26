using System.Diagnostics;

namespace sc
{
    public class @file
    {
        // ─── Read ─────────────────────────────────────────────────────────────────

        public static byte[] readBytes(string sPath)
        {
            using var fs = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            using var br = new BinaryReader(fs);
            return br.ReadBytes((int)new FileInfo(sPath).Length);
        }

        // ─── Write / Delete ───────────────────────────────────────────────────────

        public static void deleteFile(string sPath)
        {
            var fi = new FileInfo(sPath);
            if (fi.Exists) fi.Delete();
        }

        public static bool exists(string sPath) => new FileInfo(sPath).Exists;

        public static void streamWriter(string fileName, string lineText, bool withCreateNew = false)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return;

            var dirPath = Path.GetDirectoryName(fileName)!;
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            if (withCreateNew && System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    using var sw = new StreamWriter(fileName, append: true);
                    sw.WriteLine(lineText);
                    break;
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }
        }

        // ─── Metadata ─────────────────────────────────────────────────────────────

        // CHANGED: AppDomain.CurrentDomain.BaseDirectory → AppContext.BaseDirectory
        public static string getLastModified(string pathFile)
        {
            try
            {
                var d = System.IO.File.GetLastWriteTime(
                    Path.Combine(AppContext.BaseDirectory, pathFile.TrimStart('\\', '/')));
                return d.ToString("yyMMddHHmss");
            }
            catch { return string.Empty; }
        }

        // ─── Conversion ───────────────────────────────────────────────────────────

        // REMOVED: ofDownload(Page, path) — used ASP.NET HttpResponse, not applicable in API

        public static bool ConvertToPdf(string libreOfficePath, string inputFile, string outputFile)
        {
            var inputFilePath  = inputFile.Replace("\\\\", "\\");
            var outputFilePath = outputFile.Replace("\\\\", "\\");
            try
            {
                string arguments = $"--headless --convert-to pdf --outdir \"{Path.GetDirectoryName(outputFilePath)}\" \"{inputFilePath}\"";
                sc.log.addLine("ConvertToPdf InputFile "  + inputFilePath);
                sc.log.addLine("ConvertToPdf OutputFile " + outputFilePath);

                var startInfo = new ProcessStartInfo
                {
                    FileName               = libreOfficePath,
                    Arguments              = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError  = true,
                    UseShellExecute        = false,
                    CreateNoWindow         = true
                };

                sc.log.addLine("ConvertToPdf Run :" + libreOfficePath + startInfo.Arguments);
                using var process = Process.Start(startInfo)!;
                string output = process.StandardOutput.ReadToEnd();
                string error  = process.StandardError.ReadToEnd();
                process.WaitForExit();

                sc.log.addLine($"ConvertToPdf Error: {error}");
                sc.log.addLine($"ConvertToPdf Output: {output}");

                return process.ExitCode == 0;
            }
            catch (Exception ex)
            {
                sc.log.addLine($"ConvertToPdf Exception: {ex.Message}");
                return false;
            }
        }
    }
}
