using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valego_Consulting.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdentityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Temp_Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temp_Announcements", x => x.Id);
                });

            migrationBuilder.Sql("INSERT INTO Temp_Announcements (Id, Link, Title, Content, Date) SELECT Id, Link, Title, Content, Date FROM Announcements;");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.RenameTable(
                name: "Temp_Announcements",
                newName: "Announcements");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Announcements",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
