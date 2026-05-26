using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoAt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSiSecurityApps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "si_security_apps",
                columns: table => new
                {
                    i_menu_id = table.Column<int>(type: "integer", nullable: false),
                    app_name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    app_text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    app_text_english = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    i_level = table.Column<int>(type: "integer", nullable: false),
                    i_sequence = table.Column<int>(type: "integer", nullable: false),
                    order_no = table.Column<int>(type: "integer", nullable: false),
                    shot_app = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    icon_name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    s_url = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    i_parent_id = table.Column<int>(type: "integer", nullable: true),
                    sub_app_name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    remark = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_si_security_apps", x => x.i_menu_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "si_security_apps");
        }
    }
}
