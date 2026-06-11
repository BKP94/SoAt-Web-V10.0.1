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

        /// <summary>สร้าง sc.db ใหม่ต่อ request (auto-set session vars ถ้ามี loginId/loginBr)</summary>
        public db create(string? loginId = null, string? loginBr = null)
            => new db(_connectionString, loginId, loginBr);
    }
}
