using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Data.Migrations
{
    public partial class Director : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectorID",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorID",
                table: "Movies",
                column: "DirectorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorID",
                table: "Movies",
                column: "DirectorID",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorID",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Movies_DirectorID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "DirectorID",
                table: "Movies");
        }
    }
}
