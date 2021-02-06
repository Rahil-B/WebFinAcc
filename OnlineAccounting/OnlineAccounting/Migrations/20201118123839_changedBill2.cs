using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAccounting.Migrations
{
    public partial class changedBill2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bills_paymentsMades_PaymentID",
                table: "bills");

            migrationBuilder.DropIndex(
                name: "IX_bills_PaymentID",
                table: "bills");

            migrationBuilder.RenameColumn(
                name: "PaymentID",
                table: "bills",
                newName: "PaymentId");

            migrationBuilder.AddColumn<int>(
                name: "PaymentsMadeId",
                table: "bills",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bills_PaymentsMadeId",
                table: "bills",
                column: "PaymentsMadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_bills_paymentsMades_PaymentsMadeId",
                table: "bills",
                column: "PaymentsMadeId",
                principalTable: "paymentsMades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bills_paymentsMades_PaymentsMadeId",
                table: "bills");

            migrationBuilder.DropIndex(
                name: "IX_bills_PaymentsMadeId",
                table: "bills");

            migrationBuilder.DropColumn(
                name: "PaymentsMadeId",
                table: "bills");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "bills",
                newName: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_bills_PaymentID",
                table: "bills",
                column: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_bills_paymentsMades_PaymentID",
                table: "bills",
                column: "PaymentID",
                principalTable: "paymentsMades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
