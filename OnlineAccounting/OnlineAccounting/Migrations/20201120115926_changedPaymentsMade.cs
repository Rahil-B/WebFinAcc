using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAccounting.Migrations
{
    public partial class changedPaymentsMade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinancialAccountId",
                table: "vendors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentFromAccountId",
                table: "paymentsMades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentToAccountId",
                table: "paymentsMades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_paymentsMades_PaymentFromAccountId",
                table: "paymentsMades",
                column: "PaymentFromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_paymentsMades_PaymentToAccountId",
                table: "paymentsMades",
                column: "PaymentToAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_paymentsMades_FinancialAccounts_PaymentFromAccountId",
                table: "paymentsMades",
                column: "PaymentFromAccountId",
                principalTable: "FinancialAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_paymentsMades_FinancialAccounts_PaymentToAccountId",
                table: "paymentsMades",
                column: "PaymentToAccountId",
                principalTable: "FinancialAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paymentsMades_FinancialAccounts_PaymentFromAccountId",
                table: "paymentsMades");

            migrationBuilder.DropForeignKey(
                name: "FK_paymentsMades_FinancialAccounts_PaymentToAccountId",
                table: "paymentsMades");

            migrationBuilder.DropIndex(
                name: "IX_paymentsMades_PaymentFromAccountId",
                table: "paymentsMades");

            migrationBuilder.DropIndex(
                name: "IX_paymentsMades_PaymentToAccountId",
                table: "paymentsMades");

            migrationBuilder.DropColumn(
                name: "FinancialAccountId",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "PaymentFromAccountId",
                table: "paymentsMades");

            migrationBuilder.DropColumn(
                name: "PaymentToAccountId",
                table: "paymentsMades");
        }
    }
}
