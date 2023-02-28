using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping_center.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductDetails",
                table: "Products",
                type: "Nvarchar(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(300)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductDetails",
                table: "Products",
                type: "Nvarchar(300)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Nvarchar(300)");
        }
    }
}
