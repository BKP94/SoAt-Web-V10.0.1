using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoAt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMemTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sc_cnt_m_coop",
                columns: table => new
                {
                    coop_no = table.Column<string>(type: "text", nullable: false),
                    count_resign = table.Column<int>(type: "integer", nullable: true),
                    auto_approve_newmem = table.Column<string>(type: "text", nullable: true),
                    mem_type_ongroup = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_cnt_m_coop", x => x.coop_no);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_app_address",
                columns: table => new
                {
                    application_form_no = table.Column<string>(type: "text", nullable: false),
                    address_type = table.Column<string>(type: "text", nullable: false),
                    address_no = table.Column<string>(type: "text", nullable: true),
                    moo = table.Column<string>(type: "text", nullable: true),
                    mooban = table.Column<string>(type: "text", nullable: true),
                    soi = table.Column<string>(type: "text", nullable: true),
                    road = table.Column<string>(type: "text", nullable: true),
                    tambol = table.Column<string>(type: "text", nullable: true),
                    district_code = table.Column<string>(type: "text", nullable: true),
                    province_code = table.Column<string>(type: "text", nullable: true),
                    postcode = table.Column<string>(type: "text", nullable: true),
                    telephone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_app_address", x => new { x.application_form_no, x.address_type });
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_application_form",
                columns: table => new
                {
                    application_form_no = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    apply_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    prename_code = table.Column<string>(type: "text", nullable: true),
                    member_name = table.Column<string>(type: "text", nullable: true),
                    member_surname = table.Column<string>(type: "text", nullable: true),
                    member_group_no = table.Column<string>(type: "text", nullable: true),
                    mem_type = table.Column<string>(type: "text", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sex = table.Column<string>(type: "text", nullable: true),
                    appl_type_code = table.Column<string>(type: "text", nullable: true),
                    hum_id = table.Column<string>(type: "text", nullable: true),
                    marriage_status = table.Column<string>(type: "text", nullable: true),
                    nationality_code = table.Column<string>(type: "text", nullable: true),
                    blood_code = table.Column<string>(type: "text", nullable: true),
                    mobile_number = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    remark = table.Column<string>(type: "text", nullable: true),
                    approve_status = table.Column<string>(type: "text", nullable: true),
                    cancel_status = table.Column<string>(type: "text", nullable: true),
                    prename_eng = table.Column<string>(type: "text", nullable: true),
                    name_eng = table.Column<string>(type: "text", nullable: true),
                    surname_eng = table.Column<string>(type: "text", nullable: true),
                    id_card_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    id_card_enddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    id_card_number = table.Column<string>(type: "text", nullable: true),
                    id_card_organize = table.Column<string>(type: "text", nullable: true),
                    election_group = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_application_form", x => x.application_form_no);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_app_member_refer",
                columns: table => new
                {
                    application_form_no = table.Column<string>(type: "text", nullable: false),
                    seq_no = table.Column<int>(type: "integer", nullable: false),
                    membership_no = table.Column<string>(type: "text", nullable: true),
                    member_name = table.Column<string>(type: "text", nullable: true),
                    concern_code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_app_member_refer", x => new { x.application_form_no, x.seq_no });
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_app_picture",
                columns: table => new
                {
                    application_form_no = table.Column<string>(type: "text", nullable: false),
                    app_picture = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_app_picture", x => x.application_form_no);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_app_recrieve_gain",
                columns: table => new
                {
                    application_form_no = table.Column<string>(type: "text", nullable: false),
                    seq_no = table.Column<int>(type: "integer", nullable: false),
                    prename_code = table.Column<string>(type: "text", nullable: true),
                    gain_name = table.Column<string>(type: "text", nullable: true),
                    gain_surname = table.Column<string>(type: "text", nullable: true),
                    concern_code = table.Column<string>(type: "text", nullable: true),
                    wef_type = table.Column<string>(type: "text", nullable: true),
                    gain_percent = table.Column<decimal>(type: "numeric", nullable: true),
                    gain_id_card = table.Column<string>(type: "text", nullable: true),
                    book_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    order_number = table.Column<int>(type: "integer", nullable: true),
                    gain_address = table.Column<string>(type: "text", nullable: true),
                    gain_telephone = table.Column<string>(type: "text", nullable: true),
                    gain_desc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_app_recrieve_gain", x => new { x.application_form_no, x.seq_no });
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_app_share",
                columns: table => new
                {
                    application_form_no = table.Column<string>(type: "text", nullable: false),
                    share_monthly = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_app_share", x => x.application_form_no);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_app_signature",
                columns: table => new
                {
                    application_form_no = table.Column<string>(type: "text", nullable: false),
                    app_signature = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_app_signature", x => x.application_form_no);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_app_work_info",
                columns: table => new
                {
                    application_form_no = table.Column<string>(type: "text", nullable: false),
                    working_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    salary_id = table.Column<string>(type: "text", nullable: true),
                    group_other = table.Column<string>(type: "text", nullable: true),
                    group_position = table.Column<string>(type: "text", nullable: true),
                    position_long = table.Column<string>(type: "text", nullable: true),
                    level_code = table.Column<string>(type: "text", nullable: true),
                    salary_rate_code = table.Column<string>(type: "text", nullable: true),
                    salary_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    academic_salary = table.Column<decimal>(type: "numeric", nullable: true),
                    remuneration_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    salary_real = table.Column<decimal>(type: "numeric", nullable: true),
                    endingcontract_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_app_work_info", x => x.application_form_no);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_application_type",
                columns: table => new
                {
                    appl_type_code = table.Column<string>(type: "text", nullable: false),
                    appl_type_name = table.Column<string>(type: "text", nullable: true),
                    application_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    mem_type_code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_application_type", x => x.appl_type_code);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_blood",
                columns: table => new
                {
                    blood_code = table.Column<string>(type: "text", nullable: false),
                    blood_desc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_blood", x => x.blood_code);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_concern",
                columns: table => new
                {
                    concern_code = table.Column<string>(type: "text", nullable: false),
                    related_na = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_concern", x => x.concern_code);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_district",
                columns: table => new
                {
                    district_code = table.Column<string>(type: "text", nullable: false),
                    district_name = table.Column<string>(type: "text", nullable: true),
                    province_code = table.Column<string>(type: "text", nullable: true),
                    post_code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_district", x => x.district_code);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_election_group",
                columns: table => new
                {
                    election_group = table.Column<string>(type: "text", nullable: false),
                    election_group_name = table.Column<string>(type: "text", nullable: true),
                    election_zone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_election_group", x => x.election_group);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_group_position",
                columns: table => new
                {
                    group_position = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    sort_order = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_group_position", x => x.group_position);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_marriage_status",
                columns: table => new
                {
                    marriage_status_code = table.Column<string>(type: "text", nullable: false),
                    marriage_status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_marriage_status", x => x.marriage_status_code);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_member_group",
                columns: table => new
                {
                    member_group_no = table.Column<string>(type: "text", nullable: false),
                    member_group_name = table.Column<string>(type: "text", nullable: true),
                    mem_type_default = table.Column<string>(type: "text", nullable: true),
                    not_sal = table.Column<string>(type: "text", nullable: true),
                    ingore_dropshr_rule = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_member_group", x => x.member_group_no);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_member_type",
                columns: table => new
                {
                    mem_type_code = table.Column<string>(type: "text", nullable: false),
                    mem_type_desc = table.Column<string>(type: "text", nullable: true),
                    maximun_share = table.Column<decimal>(type: "numeric", nullable: true),
                    not_salary = table.Column<string>(type: "text", nullable: true),
                    mproc_apart = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_member_type", x => x.mem_type_code);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_nationality",
                columns: table => new
                {
                    nationality_code = table.Column<string>(type: "text", nullable: false),
                    nationality_description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_nationality", x => x.nationality_code);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_position",
                columns: table => new
                {
                    position_code = table.Column<string>(type: "text", nullable: false),
                    position_name = table.Column<string>(type: "text", nullable: true),
                    sort_order = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_position", x => x.position_code);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_prename",
                columns: table => new
                {
                    prename_code = table.Column<string>(type: "text", nullable: false),
                    prename = table.Column<string>(type: "text", nullable: true),
                    sex = table.Column<string>(type: "text", nullable: true),
                    marriage_status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_prename", x => x.prename_code);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_province",
                columns: table => new
                {
                    province_code = table.Column<string>(type: "text", nullable: false),
                    province_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_province", x => x.province_code);
                });

            migrationBuilder.CreateTable(
                name: "sc_mem_m_ucf_subdistrict",
                columns: table => new
                {
                    subdistrict_code = table.Column<string>(type: "text", nullable: false),
                    subdistrict_name = table.Column<string>(type: "text", nullable: true),
                    district_code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sc_mem_m_ucf_subdistrict", x => x.subdistrict_code);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sc_cnt_m_coop");

            migrationBuilder.DropTable(
                name: "sc_mem_m_app_address");

            migrationBuilder.DropTable(
                name: "sc_mem_m_application_form");

            migrationBuilder.DropTable(
                name: "sc_mem_m_app_member_refer");

            migrationBuilder.DropTable(
                name: "sc_mem_m_app_picture");

            migrationBuilder.DropTable(
                name: "sc_mem_m_app_recrieve_gain");

            migrationBuilder.DropTable(
                name: "sc_mem_m_app_share");

            migrationBuilder.DropTable(
                name: "sc_mem_m_app_signature");

            migrationBuilder.DropTable(
                name: "sc_mem_m_app_work_info");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_application_type");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_blood");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_concern");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_district");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_election_group");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_group_position");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_marriage_status");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_member_group");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_member_type");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_nationality");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_position");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_prename");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_province");

            migrationBuilder.DropTable(
                name: "sc_mem_m_ucf_subdistrict");
        }
    }
}
