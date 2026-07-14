namespace sc
{
    /// <summary>
    /// sc.appUser — ambient "ผู้ใช้ที่ล็อกอิน" ต่อ scope/circuit (แทน legacy sc.app.loginUser ที่เป็น Session var)
    ///
    /// เหตุผล: Blazor Server ไม่มี Session แบบ Web Forms + AsyncLocal ไม่ flow ข้าม UI event เชื่อถือไม่ได้
    ///   → ต้องเป็น scoped service (1 circuit = 1 instance) แล้วเซ็ตค่าจาก cookie claims (AppUserCircuitHandler)
    ///
    /// ใช้ทำอะไร: dbFactory.create() ที่เรียกแบบ "ไม่ส่ง loginId" (เช่น read service ที่ไม่รู้ user)
    ///   จะ fallback มาใช้ Id/Br/Pc ที่นี่ → ทำให้ programmer log gate (sc.log) + SET LOCAL app.login_*
    ///   ทำงานกับทุก query แม้ caller ไม่ได้ threading userId ผ่าน signature (เลียน ambient ของ legacy)
    /// </summary>
    public sealed class appUser
    {
        /// <summary>user_id (claims: ClaimTypes.NameIdentifier)</summary>
        public string? Id { get; set; }

        /// <summary>branch_id (claims: "branch_id")</summary>
        public string? Br { get; set; }

        /// <summary>client_pc — Blazor ไม่มีรหัสเครื่องแบบ legacy ปกติ null</summary>
        public string? Pc { get; set; }

        /// <summary>โหลด claims เข้า instance นี้แล้ว (เซ็ตครั้งเดียวต่อ circuit เมื่อ authenticated)</summary>
        public bool Loaded { get; set; }
    }
}
