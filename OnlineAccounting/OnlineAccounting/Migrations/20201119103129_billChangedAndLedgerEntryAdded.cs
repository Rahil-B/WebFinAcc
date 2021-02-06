using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAccounting.Migrations
{
    public partial class billChangedAndLedgerEntryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CreditBalance",
                table: "FinancialAccounts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DebitBalance",
                table: "FinancialAccounts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PaidFromAccountId",
                table: "expenses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LedgerEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    TargetAccountId = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LedgerEntries_FinancialAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FinancialAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_paymentsMades_VendorId",
                table: "paymentsMades",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_PaidFromAccountId",
                table: "expenses",
                column: "PaidFromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerEntries_AccountId",
                table: "LedgerEntries",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_FinancialAccounts_PaidFromAccountId",
                table: "expenses",
                column: "PaidFromAccountId",
                principalTable: "FinancialAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_paymentsMades_vendors_VendorId",
                table: "paymentsMades",
                column: "VendorId",
                principalTable: "vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_FinancialAccounts_PaidFromAccountId",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_paymentsMades_vendors_VendorId",
                table: "paymentsMades");

            migrationBuilder.DropTable(
                name: "LedgerEntries");

            migrationBuilder.DropIndex(
                name: "IX_paymentsMades_VendorId",
                table: "paymentsMades");

            migrationBuilder.DropIndex(
                name: "IX_expenses_PaidFromAccountId",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "CreditBalance",
                table: "FinancialAccounts");

            migrationBuilder.DropColumn(
                name: "DebitBalance",
                table: "FinancialAccounts");

            migrationBuilder.DropColumn(
                name: "PaidFromAccountId",
                table: "expenses");
        }
    }
}
