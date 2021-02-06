using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAccounting.Migrations
{
    public partial class addedUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetails_purchaseOrders_PurchaseOrderId",
                table: "ItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetails_salesOrders_SalesOrderId",
                table: "ItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_salesOrders_customers_customerId",
                table: "salesOrders");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemDetails",
                table: "ItemDetails");

            migrationBuilder.RenameTable(
                name: "ItemDetails",
                newName: "itemDetails");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "salesOrders",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_salesOrders_customerId",
                table: "salesOrders",
                newName: "IX_salesOrders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemDetails_SalesOrderId",
                table: "itemDetails",
                newName: "IX_itemDetails_SalesOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemDetails_PurchaseOrderId",
                table: "itemDetails",
                newName: "IX_itemDetails_PurchaseOrderId");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "vendors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "salesOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "purchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "paymentsMades",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "paymentReceiveds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "JournalEntries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FinancialAccounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "expenses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "deliveryChallans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "bills",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_itemDetails",
                table: "itemDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_itemDetails_purchaseOrders_PurchaseOrderId",
                table: "itemDetails",
                column: "PurchaseOrderId",
                principalTable: "purchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_itemDetails_salesOrders_SalesOrderId",
                table: "itemDetails",
                column: "SalesOrderId",
                principalTable: "salesOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_salesOrders_customers_CustomerId",
                table: "salesOrders",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemDetails_purchaseOrders_PurchaseOrderId",
                table: "itemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_itemDetails_salesOrders_SalesOrderId",
                table: "itemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_salesOrders_customers_CustomerId",
                table: "salesOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_itemDetails",
                table: "itemDetails");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "salesOrders");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "purchaseOrders");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "paymentsMades");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "paymentReceiveds");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FinancialAccounts");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "deliveryChallans");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "bills");

            migrationBuilder.RenameTable(
                name: "itemDetails",
                newName: "ItemDetails");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "salesOrders",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_salesOrders_CustomerId",
                table: "salesOrders",
                newName: "IX_salesOrders_customerId");

            migrationBuilder.RenameIndex(
                name: "IX_itemDetails_SalesOrderId",
                table: "ItemDetails",
                newName: "IX_ItemDetails_SalesOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_itemDetails_PurchaseOrderId",
                table: "ItemDetails",
                newName: "IX_ItemDetails_PurchaseOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemDetails",
                table: "ItemDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetails_purchaseOrders_PurchaseOrderId",
                table: "ItemDetails",
                column: "PurchaseOrderId",
                principalTable: "purchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetails_salesOrders_SalesOrderId",
                table: "ItemDetails",
                column: "SalesOrderId",
                principalTable: "salesOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_salesOrders_customers_customerId",
                table: "salesOrders",
                column: "customerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
