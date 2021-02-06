using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAccounting.Migrations
{
    public partial class ChangedExpense1AndLedgerAndJournal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditLedgerEntryId",
                table: "JournalEntries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DebitLedgerEntryId",
                table: "JournalEntries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JournalEntryId",
                table: "expenses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_CreditLedgerEntryId",
                table: "JournalEntries",
                column: "CreditLedgerEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_DebitLedgerEntryId",
                table: "JournalEntries",
                column: "DebitLedgerEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_JournalEntryId",
                table: "expenses",
                column: "JournalEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_JournalEntries_JournalEntryId",
                table: "expenses",
                column: "JournalEntryId",
                principalTable: "JournalEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_LedgerEntries_CreditLedgerEntryId",
                table: "JournalEntries",
                column: "CreditLedgerEntryId",
                principalTable: "LedgerEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_LedgerEntries_DebitLedgerEntryId",
                table: "JournalEntries",
                column: "DebitLedgerEntryId",
                principalTable: "LedgerEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_JournalEntries_JournalEntryId",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_LedgerEntries_CreditLedgerEntryId",
                table: "JournalEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_LedgerEntries_DebitLedgerEntryId",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_CreditLedgerEntryId",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_DebitLedgerEntryId",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_expenses_JournalEntryId",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "CreditLedgerEntryId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "DebitLedgerEntryId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "JournalEntryId",
                table: "expenses");
        }
    }
}
