using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAccounting.Migrations
{
    public partial class addedPurchaseOrderItemDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemDetails_purchaseOrders_PurchaseOrderId",
                table: "itemDetails");

            migrationBuilder.DropIndex(
                name: "IX_itemDetails_PurchaseOrderId",
                table: "itemDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderId",
                table: "itemDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "purchaseOrders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "POrderItemDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POrderItemDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POrderItemDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_POrderItemDetails_purchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "purchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOrders_VendorId",
                table: "purchaseOrders",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_POrderItemDetails_ItemId",
                table: "POrderItemDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_POrderItemDetails_PurchaseOrderId",
                table: "POrderItemDetails",
                column: "PurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseOrders_vendors_VendorId",
                table: "purchaseOrders",
                column: "VendorId",
                principalTable: "vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchaseOrders_vendors_VendorId",
                table: "purchaseOrders");

            migrationBuilder.DropTable(
                name: "POrderItemDetails");

            migrationBuilder.DropIndex(
                name: "IX_purchaseOrders_VendorId",
                table: "purchaseOrders");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "purchaseOrders");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderId",
                table: "itemDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_itemDetails_PurchaseOrderId",
                table: "itemDetails",
                column: "PurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_itemDetails_purchaseOrders_PurchaseOrderId",
                table: "itemDetails",
                column: "PurchaseOrderId",
                principalTable: "purchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
