namespace sc
{
    public class css
    {
        public static Type? getType(string cssColType)
        {
            if (cssColType == col.Date || cssColType == col.DateTime)
                return typeof(DateTime);

            if (cssColType == col.Integer || cssColType == col.Integer2
             || cssColType == col.Decimal || cssColType == col.Decimal2 || cssColType == col.Decimal3
             || cssColType == col.Year || cssColType == col.Month)
                return typeof(double);

            if (cssColType == col.DepositAccNo)
                return typeof(string);

            return null;
        }

        /// <summary>
        /// map CSS col-marker → mask string (sc.mask.*) สำหรับ Blazor DxMaskedInput
        /// (เทียบ legacy ที่ใส่ class col-* บน field แล้ว format ตาม class).
        /// คืน null ถ้าไม่ใช่ชนิดที่ต้อง mask. Date/DateTime คืน mask แบบ text (กรณีใช้ masked input)
        /// </summary>
        public static string? maskOf(string? cssColType) => cssColType switch
        {
            col.Integer  => mask.maskInteger,
            col.Integer2 => mask.maskIntegerNegative,   // col-integer2 = ติดลบได้
            col.Decimal  => mask.maskDecimal,
            col.Decimal2 => mask.maskDecimalNegative,    // col-decimal2 = ติดลบได้
            col.Decimal3 => mask.maskDecimal3,
            col.Year     => mask.maskYear,
            col.Month    => mask.maskInteger,
            col.Date     => mask.maskDate,
            col.DateTime => mask.maskDateTime,
            _            => null,
        };

        public struct col
        {
            public const string col_   = "col-";
            public const string combo_ = "combo-";

            public const string Date         = "col-date";
            public const string DateTime     = "col-datetime";
            public const string Integer      = "col-integer";
            public const string Integer2     = "col-integer2";
            public const string Decimal      = "col-decimal";
            public const string Decimal2     = "col-decimal2";
            public const string Decimal3     = "col-decimal3";
            public const string Year         = "col-year";
            public const string Month        = "col-month";
            public const string DepositAccNo = "col-depositaccno";
            public const string save         = "save";
            public const string notSave      = "notsave";
            public const string valid        = "valid";
        }
    }
}
