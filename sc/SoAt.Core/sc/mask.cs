namespace sc
{
    public struct mask
    {
        // Numeric masks = .NET custom numeric format strings (Blazor DxMaskedInput
        // bound to decimal/int). อย่าใช้ range syntax "<0..99>" แบบ DevExpress WinForms
        // เดิม — Blazor ไม่รองรับ จะโชว์ mask ดิบตอนคีย์
        public const string maskDecimal         = "#,##0.00";
        public const string maskDecimalNegative = "#,##0.00;-#,##0.00";
        public const string maskDecimal3        = "#,##0.000";
        public const string maskInteger         = "#,##0";
        public const string maskIntegerNegative = "#,##0;-#,##0";
        public const string maskYear            = "0000";
        public const string maskIdCard          = "9-9999-99999-99-9";
        public const string maskPercent4        = "#,##0.0000' %'";
        public const string maskPercent2        = "#,##0.00' %'";
        public const string maskDate            = "99/99/9999";
        public const string maskDateTime        = "00/00/0000 00:00:00";
    }
}
