using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace decoderslasherp.Migrations
{
    /// <inheritdoc />
    public partial class teamtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    UserAdd = table.Column<int>(type: "int", nullable: true),
                    UserMod = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teams_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamID",
                table: "Employees",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ProjectID",
                table: "Teams",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Teams_TeamID",
                table: "Employees",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Teams_TeamID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TeamID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Employees");
        }
    }
}
