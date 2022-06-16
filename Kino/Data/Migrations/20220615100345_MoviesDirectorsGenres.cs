using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Data.Migrations
{
    public partial class MoviesDirectorsGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AwardsNumber",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwardsNumber",
                table: "Directors");
        }
    }
}
