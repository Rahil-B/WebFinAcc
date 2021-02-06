using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAccounting.Migrations
{
    public partial class changedBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "billItemDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "billItemDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bills_VendorId",
                table: "bills",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_billItemDetails_CustomerID",
                table: "billItemDetails",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_billItemDetails_ItemId",
                table: "billItemDetails",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_billItemDetails_customers_CustomerID",
                table: "billItemDetails",
                column: "CustomerID",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_billItemDetails_Items_ItemId",
                table: "billItemDetails",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bills_vendors_VendorId",
                table: "bills",
                column: "VendorId",
                principalTable: "vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_billItemDetails_customers_CustomerID",
                table: "billItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_billItemDetails_Items_ItemId",
                table: "billItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_bills_vendors_VendorId",
                table: "bills");

            migrationBuilder.DropIndex(
                name: "IX_bills_VendorId",
                table: "bills");

            migrationBuilder.DropIndex(
                name: "IX_billItemDetails_CustomerID",
                table: "billItemDetails");

            migrationBuilder.DropIndex(
                name: "IX_billItemDetails_ItemId",
                table: "billItemDetails");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "billItemDetails");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "billItemDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
