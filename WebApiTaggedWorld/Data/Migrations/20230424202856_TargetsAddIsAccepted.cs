using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiTaggedWorld.Migrations
{
    public partial class TargetsAddIsAccepted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Targets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Targets");
        }
    }
}
