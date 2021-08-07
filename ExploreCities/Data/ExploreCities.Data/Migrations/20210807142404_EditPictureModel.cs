namespace ExploreCities.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class EditPictureModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ObjectName",
                table: "Pictures");

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "RemoteImageUrl",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemoteImageUrl",
                table: "Pictures");

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Pictures",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "ObjectName",
                table: "Pictures",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: string.Empty);
        }
    }
}
