using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace decoderslasherp.Migrations
{
    /// <inheritdoc />
    public partial class newColumnInTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "Tasks");
        }
    }
}
