using System.Runtime.CompilerServices;

namespace sc
{
    /// <summary>
    /// ติด prefix บอกแหล่ง error + เลขบรรทัด ให้ข้อความที่พ่นให้ผู้ใช้ (debug ได้เร็ว)
    ///   C = error จาก C#  |  E = error จาก PL/PostgreSQL  (เดิม J = JavaScript เลิกใช้แล้ว เพราะ Blazor ไม่มี JS → C)
    /// เลขบรรทัด compiler เติมให้อัตโนมัติผ่าน [CallerLineNumber] → ไม่ต้องไล่ sync เลขมือเวลาโค้ดเลื่อน
    /// </summary>
    /// <example>throw new InvalidOperationException(sc.msg.C("ไม่พบใบสมัคร"));  // → "C268:ไม่พบใบสมัคร"</example>
    public struct msg
    {
        /// <summary>ข้อความ/ข้อผิดพลาดจากฝั่ง C# → "C{บรรทัด}:{text}" (เลขบรรทัด ณ จุดเรียกอัตโนมัติ)</summary>
        public static string C(string text, [CallerLineNumber] int line = 0) => $"C{line}:{text}";

        /// <summary>
        /// ข้อความจากฝั่ง PL/PostgreSQL → "E{line}:{text}".
        /// ปกติ message E ถูกเขียนใน function/trigger PL อยู่แล้ว (พก prefix มาเอง); helper นี้ไว้กรณี C# ต้องระบุ E เอง (ต้องใส่เลขบรรทัด PL มือ)
        /// </summary>
        public static string E(string text, int line) => $"E{line}:{text}";
    }
}
