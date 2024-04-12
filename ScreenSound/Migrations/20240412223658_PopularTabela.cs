using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artistas", ["Nome", "FotoPerfil", "Bio"],
                ["Yuri", "yuri.png", "Um cara legal, doido."]);

            migrationBuilder.InsertData("Artistas", ["Nome", "FotoPerfil", "Bio"],
                ["Jems", "jems.png", "Um cara gostoso, doido."]);

            migrationBuilder.InsertData("Artistas", ["Nome", "FotoPerfil", "Bio"],
                ["Mateus", "mateus.png", "Um cara femboy, doido."]);

            migrationBuilder.InsertData("Artistas", ["Nome", "FotoPerfil", "Bio"],
                ["Luth", "luth.png", "Um cara arrombado, doido."]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas");
        }
    }
}
