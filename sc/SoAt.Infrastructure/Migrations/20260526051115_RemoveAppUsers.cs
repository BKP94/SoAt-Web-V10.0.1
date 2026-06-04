using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoAt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAppUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // IF EXISTS: รองรับกรณีที่ลบ table ออกจาก PostgreSQL ด้วยมือแล้ว
            migrationBuilder.Sql("DROP TABLE IF EXISTS app_users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "app_users",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    branch_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    password_hash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_users", x => x.user_id);
                });
        }
    }
}
