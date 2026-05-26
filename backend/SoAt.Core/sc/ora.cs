namespace sc
{
    // CHANGED: constructor was ora(sc.page page) — sc.page is ASP.NET Web Forms
    // CHANGED: isActive() was db.getSessionTable().Rows.Find() → direct db.getValue()
    // REMOVED: all Oracle registry helpers (GetOracleHomes, GetOracleHomePath, LoadTNSNames) — commented out in original
    public class ora : sc.service
    {
        public ora(sc.db db) : base(db) { }

        public bool isActive(string status_code)
            => sc.value.toBoolean(db.getValue(
                "select active_status from sc_cnt_m_status_active where status_code = {0}",
                status_code));
    }
}
