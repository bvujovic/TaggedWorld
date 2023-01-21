using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiTaggedWorld.Migrations
{
    /// <summary></summary>
    public partial class TargetsDropTitleType : Migration
    {
        /// <summary></summary>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Targets");
        }

        /// <summary></summary>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Targets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Targets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
