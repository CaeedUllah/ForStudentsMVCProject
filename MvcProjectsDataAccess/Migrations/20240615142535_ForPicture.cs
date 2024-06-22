using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcProjectsDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ForPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "Students");
        }
    }
}
