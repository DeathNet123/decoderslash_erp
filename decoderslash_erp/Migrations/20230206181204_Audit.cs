using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace decoderslasherp.Migrations
{
    /// <inheritdoc />
    public partial class Audit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "UserAdd",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDel",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserMod",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAdd",
                table: "Credentials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDel",
                table: "Credentials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserMod",
                table: "Credentials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Credentials",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserAdd",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserDel",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserMod",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserAdd",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "UserDel",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "UserMod",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Credentials");
        }
    }
}
