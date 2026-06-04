using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoAt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIconNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
UPDATE si_security_apps SET icon_name = CASE app_name
  WHEN 'scTeller'      THEN 'Teller.png'
  WHEN 'scApprove'     THEN 'Approve.png'
  WHEN 'scDeposit'     THEN 'Deposit.png'
  WHEN 'scFinance'     THEN 'Finance.png'
  WHEN 'scKeeping'     THEN 'Keeping.png'
  WHEN 'scAccount'     THEN 'Account.png'
  WHEN 'scReport'      THEN 'Report.png'
  WHEN 'scAdmin'       THEN 'Administrator.png'
  WHEN 'scCenter'      THEN 'web.png'
  WHEN 'scTransbank'   THEN 'Transbank.png'
  WHEN 'scEstate'      THEN 'Estate.png'
  WHEN 'scAtm'         THEN 'ATM.png'
  WHEN 'scLaw'         THEN 'LAW.png'
  WHEN 'scWelfare'     THEN 'Welfare.png'
  WHEN 'scCoordinate'  THEN 'Coordinate.png'
  WHEN 'scMobile'      THEN 'MobileRegis.png'
  WHEN 'scElections'   THEN 'Elections.png'
  WHEN 'scPermit'      THEN 'Permission.png'
  WHEN 'scProDATA'     THEN 'ProDATA.png'
  WHEN 'scInsurance'   THEN 'Insurance.png'
  WHEN 'scExp'         THEN 'Exp.png'
  WHEN 'scFund'        THEN 'Fund.png'
  WHEN 'scKeepcoll'    THEN 'KeepColl.png'
  WHEN 'scBillpayment' THEN 'BillPayment.png'
  WHEN 'scHr'          THEN 'Human-Resources.png'
  WHEN 'scEdocument'   THEN 'e-document.png'
  WHEN 'scStock'       THEN 'Stock-Resources.png'
  WHEN 'scEoffice'     THEN 'e-Office.png'
  WHEN 'scInvestment'  THEN 'Finance.png'
  WHEN 'scRing2Me'     THEN 'Ring2ME.png'
  WHEN 'scScholarship' THEN 'Scholarship.png'
  WHEN 'scCremation'   THEN 'Cremation.png'
  ELSE icon_name
END
WHERE i_level = 1;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE si_security_apps SET icon_name = NULL WHERE i_level = 1;");
        }
    }
}
