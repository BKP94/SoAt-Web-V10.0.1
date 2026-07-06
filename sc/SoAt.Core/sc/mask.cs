using System.Linq;

namespace sc
{
    public struct mask
    {
        // Numeric masks = .NET STANDARD numeric format specifiers (Blazor DxMaskedInput
        // bound to decimal/int). ใช้ "n2"/"n0" ไม่ใช่ custom "#,##0.00" เพราะ DxMaskedInput
        // นับ placeholder ของ custom format เป็นจำนวนหลักสูงสุด (#,##0 = พิมพ์ได้แค่ 4 หลัก
        // = หลักพัน). standard specifier ไม่จำกัดหลัก. ห้ามใช้ range syntax "<0..99>" (WinForms)
        public const string maskDecimal         = "n2";
        public const string maskDecimalNegative = "n2";   // numeric mask รับเครื่องหมายลบได้เอง
        public const string maskDecimal3        = "n3";
        public const string maskInteger         = "n0";
        public const string maskIntegerNegative = "n0";
        public const string maskYear            = "0000";  // ปีตายตัว 4 หลัก (จำกัดหลักตั้งใจ)
        public const string maskIdCard          = "9-9999-99999-99-9";
        public const string maskPercent4        = "#,##0.0000' %'";
        public const string maskPercent2        = "#,##0.00' %'";
        public const string maskDate            = "99/99/9999";
        public const string maskDateTime        = "00/00/0000 00:00:00";

        /// <summary>คืนเฉพาะตัวเลข (ตัด mask literal เช่นขีด/ช่องว่างทิ้ง) —
        /// ใช้ normalize เลขบัตร/เลขที่ก่อนเก็บลง DB เพราะ DxMaskedInput text mask
        /// เก็บค่า "รวมตัวคั่น" (เช่น 1-2345-67890-12-3 = 17 ตัว ล้น varchar(15))</summary>
        public static string? ofDigits(string? s) =>
            string.IsNullOrEmpty(s) ? s : new string(s.Where(char.IsDigit).ToArray());

        /// <summary>จัดรูปเลขบัตร ปชช. 13 หลัก → "9-9999-99999-99-9" สำหรับ "แสดงผล" (read-only).
        /// คู่กับ const <see cref="maskIdCard"/> ที่ใช้กับ editor. ถ้าไม่ใช่ 13 หลัก คืนค่าเดิม</summary>
        public static string idCard(string? s)
        {
            var d = ofDigits(s);
            if (string.IsNullOrEmpty(d) || d.Length != 13) return s ?? string.Empty;
            return $"{d[..1]}-{d.Substring(1, 4)}-{d.Substring(5, 5)}-{d.Substring(10, 2)}-{d[12..]}";
        }
    }
}
