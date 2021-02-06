using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAccounting.Migrations
{
    public partial class ExpenseChanged1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HSNCode",
                table: "expenses",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "deliveryChallans",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoices_SalesOrderId",
                table: "invoices",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_salesOrders_SalesOrderId",
                table: "invoices",
                column: "SalesOrderId",
                principalTable: "salesOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_salesOrders_SalesOrderId",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_invoices_SalesOrderId",
                table: "invoices");

            migrationBuilder.AlterColumn<string>(
                name: "HSNCode",
                table: "expenses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "deliveryChallans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
