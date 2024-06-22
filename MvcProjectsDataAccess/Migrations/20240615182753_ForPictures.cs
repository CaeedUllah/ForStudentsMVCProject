using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcProjectsDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ForPictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "Students");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Students",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
