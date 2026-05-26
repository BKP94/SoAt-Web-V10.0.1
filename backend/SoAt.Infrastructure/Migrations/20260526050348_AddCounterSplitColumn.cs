using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoAt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCounterSplitColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "counter_split",
                table: "si_security_user",
                type: "character(1)",
                fixedLength: true,
                maxLength: 1,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "counter_split",
                table: "si_security_user");
        }
    }
}
