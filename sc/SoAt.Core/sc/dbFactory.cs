using Microsoft.Extensions.Configuration;

namespace sc
{
    /// <summary>
    /// sc.dbFactory — สร้าง sc.db instance พร้อม connection string
    /// Register เป็น Singleton ใน DI
    /// Usage: dbFactory.create(userId, branchId)
    /// </summary>
    public class dbFactory
    {
        private readonly string _connectionString;

        public dbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>ชื่อ database ของ PG (Database= ใน connection string จาก appsettings.json)</summary>
        public string Database
            => new Npgsql.NpgsqlConnectionStringBuilder(_connectionString).Database ?? "";

        /// <summary>สร้าง sc.db ใหม่ต่อ request (auto-set session vars ถ้ามี loginId/loginBr/loginPc)</summary>
        /// <remarks>loginPc = client_pc (รหัสเครื่อง) → current_setting('app.login_pc') ใช้แยก scope
        /// sc_kep_m_monthly_mtarget ตอนประมวลผลส่งหัก (pka_com_function.fp_login_pc)</remarks>
        public db create(string? loginId = null, string? loginBr = null, string? loginPc = null)
            => new db(_connectionString, loginId, loginBr, loginPc);
    }
}
