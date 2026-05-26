using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoAt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSiSecurityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "si_security_user",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    user_name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    branch_id = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    passwords = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    close_status = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, defaultValue: "0"),
                    group_id = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    programmer = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    admin_mode = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_si_security_user", x => x.user_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "si_security_user");
        }
    }
}
