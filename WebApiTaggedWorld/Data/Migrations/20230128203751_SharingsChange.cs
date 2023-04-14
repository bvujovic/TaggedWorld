using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiTaggedWorld.Migrations
{
    public partial class SharingsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sharing");

            migrationBuilder.AddColumn<DateTime>(
                name: "SharedDate",
                table: "Targets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SharedOnGroupId",
                table: "Targets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserSenderId",
                table: "Targets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Targets_SharedOnGroupId",
                table: "Targets",
                column: "SharedOnGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_UserSenderId",
                table: "Targets",
                column: "UserSenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Group_SharedOnGroupId",
                table: "Targets",
                column: "SharedOnGroupId",
                principalTable: "Group",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Users_UserSenderId",
                table: "Targets",
                column: "UserSenderId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Group_SharedOnGroupId",
                table: "Targets");

            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Users_UserSenderId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Targets_SharedOnGroupId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Targets_UserSenderId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "SharedDate",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "SharedOnGroupId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "UserSenderId",
                table: "Targets");

            migrationBuilder.CreateTable(
                name: "Sharing",
                columns: table => new
                {
                    TargetId = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    SharedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sharing", x => new { x.TargetId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_Sharing_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sharing_Targets_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Targets",
                        principalColumn: "TargetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sharing_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sharing_GroupId",
                table: "Sharing",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Sharing_UserId",
                table: "Sharing",
                column: "UserId");
        }
    }
}
