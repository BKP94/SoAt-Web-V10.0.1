namespace sc
{
    public class att
    {
        public struct datatype
        {
            public const string Date     = "date";
            public const string DateTime = "datetime";
            public const string Integer  = "integer";
            public const string Integer2 = "integer2";
            public const string Decimal  = "decimal";
            public const string Decimal2 = "decimal2";
            public const string Decimal3 = "decimal3";
            public const string Unbound  = "unbound";
            public const string String   = "string";
            public const string Boolean  = "boolean";
            // ส่งมาจาก JavaScript
            public const string jsUndefined = "U";
            public const string jsNumber    = "N";
            public const string jsArray     = "A";
            public const string jsDate      = "D";
            public const string jsString    = "S";
            public const string jsBoolean   = "B";
        }

        public struct column
        {
            public const string id       = "id";
            public const string type     = "type";
            public const string key      = "key";
            public const string master   = "master";
            public const string uniqueID = "uniqueID";
            public const string valid    = "valid";
            public const string special  = "special";
            public const string update   = "update";
            public const string negative = "negative";
            public const string combo    = "combo";
            public const string control  = "control";
        }

        public struct datawindow
        {
            public const string update = "update";
            public const string master = "master";
            public const string table  = "table";
            public const string tabID  = "tabID";
        }

        public struct special
        {
            public const string memno   = "memno";
            public const string idcard  = "idcard";
            public const string precent2 = "percent2";
            public const string percent4 = "percent4";
            public const string year    = "year";
            public const string month   = "month";
            public const string conno   = "conno";
            public const string depno   = "depno";
            public const string bankno  = "bankno";
        }

        public struct session
        {
            public const string LoginUser    = "Login-user_id";
            public const string LoginBranch  = "Login-branch_id";
            public const string LoginSite    = "Login-site_target";
            public const string dbConnString   = "db-ConnString";
            public const string dbConnProvider = "db-Provider";
            public const string dbConnName     = "db-Name";
            public const string ComFinanceDate  = "Com-FinanceDate";
            public const string ComUserPicture  = "Com-UserPicture";
            public const string ComAppVersion   = "Com-AppVersion";
            public const string repArguments    = "rep-Arguments";
            public const string repNestLogs     = "rep-NestLogs";
            public const string DepositAccFormat = "Deposit-AccFormat";
            public const string isProgrammer    = "isProgrammer-SOAT";
        }
    }
}
