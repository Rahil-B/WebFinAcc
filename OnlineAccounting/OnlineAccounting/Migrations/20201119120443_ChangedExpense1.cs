using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAccounting.Migrations
{
    public partial class ChangedExpense1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "expenses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "expenses");
        }
    }
}
