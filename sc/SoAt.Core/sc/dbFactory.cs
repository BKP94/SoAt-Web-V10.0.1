using Microsoft.Extensions.Configuration;

namespace sc
{
    /// <summary>
    /// sc.dbFactory — สร้าง sc.db instance พร้อม connection string
    /// Register เป็น Scoped ใน DI (เดิม Singleton — เปลี่ยนเพราะต้อง inject scoped sc.appUser
    ///   เพื่อ fallback loginId/loginBr เป็น ambient current-user; cache programmer เป็น static
    ///   อยู่แล้วจึงไม่เสีย perf จากการเปลี่ยน lifetime)
    /// Usage: dbFactory.create(userId, branchId) — ถ้าไม่ส่ง จะดึงจาก sc.appUser (ambient) ให้อัตโนมัติ
    /// </summary>
    public class dbFactory
    {
        private readonly string _connectionString;
        private readonly appUser? _user;

        public dbFactory(string connectionString, appUser? user = null)
        {
            _connectionString = connectionString;
            _user = user;
        }

        /// <summary>ชื่อ database ของ PG (Database= ใน connection string จาก appsettings.json)</summary>
        public string Database
            => new Npgsql.NpgsqlConnectionStringBuilder(_connectionString).Database ?? "";

        /// <summary>สร้าง sc.db ใหม่ต่อ request (auto-set session vars ถ้ามี loginId/loginBr/loginPc)</summary>
        /// <remarks>loginPc = client_pc (รหัสเครื่อง) → current_setting('app.login_pc') ใช้แยก scope
        /// sc_kep_m_monthly_mtarget ตอนประมวลผลส่งหัก (pka_com_function.fp_login_pc)</remarks>
        public db create(string? loginId = null, string? loginBr = null, string? loginPc = null)
        {
            // ไม่ส่ง user มา → ใช้ ambient current-user ต่อ circuit (sc.appUser จาก cookie claims)
            //   เลียน legacy ที่อ่าน sc.app.loginUser ได้ทุกที่โดยไม่ต้อง threading userId ผ่าน signature
            loginId ??= _user?.Id;
            loginBr ??= _user?.Br;
            loginPc ??= _user?.Pc;

            // log file gate ตาม legacy sc\log.cs setActive():
            //   select programmer from si_security_user where user_id = ... → เขียน log เฉพาะ programmer
            sc.log.setUserActive(isProgrammer(loginId));
            return new db(_connectionString, loginId, loginBr, loginPc);
        }

        // cache ผล programmer ต่อ user (query ครั้งแรกครั้งเดียว) — ไม่ cache ตอน query fail
        // เพื่อให้ DB กลับมาแล้วตรวจใหม่ได้ ไม่ติด false ค้าง
        private static readonly System.Collections.Concurrent.ConcurrentDictionary<string, bool> _programmerCache = new();

        private bool isProgrammer(string? loginId)
        {
            if (string.IsNullOrWhiteSpace(loginId)) return false;
            if (_programmerCache.TryGetValue(loginId, out var cached)) return cached;

            try
            {
                using var conn = new Npgsql.NpgsqlConnection(_connectionString);
                conn.Open();
                using var cmd = new Npgsql.NpgsqlCommand(
                    "select programmer from si_security_user where user_id = @id", conn);
                cmd.Parameters.AddWithValue("id", loginId);
                var flag = sc.value.toBoolean(cmd.ExecuteScalar());
                _programmerCache.TryAdd(loginId, flag);
                return flag;
            }
            catch
            {
                // DB ยังไม่พร้อม → ปิด log ไว้ก่อน (ไม่ cache) — อย่าให้ create ล้มเพราะ log gate
                return false;
            }
        }
    }
}
