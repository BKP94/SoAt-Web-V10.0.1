using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoAt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFinTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sc_com_m_branch",
                columns: table => new
                {
                    branch_id = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    branch_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    base_status = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: true),
                    postto_fin = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: true),
                    account_control = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    picture_2file = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: true),
                    finance_branch = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_com_m_branch", x => x.branch_id);
                });

            migrationBuilder.CreateTable(
                name: "sc_fin_journal_head",
                columns: table => new
                {
                    branch_fin = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    journal_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    entry_fin = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    open_no = table.Column<decimal>(type: "numeric(15,0)", nullable: false),
                    fin_book = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: false),
                    balance_begin = table.Column<decimal>(type: "numeric(15,2)", nullable: true),
                    total_receive = table.Column<decimal>(type: "numeric(15,2)", nullable: true),
                    total_payment = table.Column<decimal>(type: "numeric(15,2)", nullable: true),
                    balance_forward = table.Column<decimal>(type: "numeric(15,2)", nullable: true),
                    main_counter = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: true),
                    close_day = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: true),
                    close_id = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    close_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    close_client_id = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_fin_journal_head", x => new { x.branch_fin, x.journal_date, x.entry_fin, x.open_no, x.fin_book });
                });

            migrationBuilder.CreateTable(
                name: "sc_fin_m_constant",
                columns: table => new
                {
                    coop_no = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    finance_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_fin_m_constant", x => x.coop_no);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sc_com_m_branch");

            migrationBuilder.DropTable(
                name: "sc_fin_journal_head");

            migrationBuilder.DropTable(
                name: "sc_fin_m_constant");
        }
    }
}
