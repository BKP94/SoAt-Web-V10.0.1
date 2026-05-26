using System.Data;
using Npgsql;

namespace SoAt.Infrastructure.Persistence;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateAsync(string? loginId = null, string? branchId = null);
}

public class NpgsqlConnectionFactory(string connectionString) : IDbConnectionFactory
{
    public async Task<IDbConnection> CreateAsync(string? loginId = null, string? branchId = null)
    {
        var conn = new NpgsqlConnection(connectionString);
        await conn.OpenAsync();

        // Set session variables for trigger audit (แทน Oracle pka_com_login package)
        if (loginId is not null)
        {
            await using var cmd = new NpgsqlCommand($"SET LOCAL app.login_id = '{loginId}'", conn);
            await cmd.ExecuteNonQueryAsync();
        }
        if (branchId is not null)
        {
            await using var cmd = new NpgsqlCommand($"SET LOCAL app.login_br = '{branchId}'", conn);
            await cmd.ExecuteNonQueryAsync();
        }

        return conn;
    }
}
