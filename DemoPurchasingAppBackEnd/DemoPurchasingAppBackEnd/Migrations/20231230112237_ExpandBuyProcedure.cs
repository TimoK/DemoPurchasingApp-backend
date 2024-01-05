using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoPurchasingAppBackEnd.Migrations
{
    public partial class ExpandBuyProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxPrice",
                table: "BuyProcedures",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "CostEnumerationType",
                table: "BuyProcedures",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostEnumerationType",
                table: "BuyProcedures");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "BuyProcedures",
                newName: "MaxPrice");
        }
    }
}
