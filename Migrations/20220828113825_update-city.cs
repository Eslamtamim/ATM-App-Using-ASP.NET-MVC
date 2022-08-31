using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcTest1.Migrations
{
    public partial class updatecity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Account",
                newName: "Government");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Government",
                table: "Account",
                newName: "City");
        }
    }
}
