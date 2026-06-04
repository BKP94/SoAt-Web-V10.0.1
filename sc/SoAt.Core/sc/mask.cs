namespace sc
{
    public struct mask
    {
        public const string maskDecimal         = "<0..999999999999g>.<00..99>";
        public const string maskDecimalNegative = "<-999999999999..999999999999g>.<00..99>";
        public const string maskDecimal3        = "<0..999999999999g>.<00..999>";
        public const string maskInteger         = "<0..999999999999g>";
        public const string maskIntegerNegative = "<-999999999999..999999999999g>";
        public const string maskYear            = "<2443..3000>";
        public const string maskIdCard          = "9-9999-99999-99-9";
        public const string maskPercent4        = "<0..100>.<00..9999>%";
        public const string maskPercent2        = "<0..100>.<00..99>%";
        public const string maskDate            = "99/99/9999";
        public const string maskDateTime        = "00/00/0000 00:00:00";
    }
}
