using Microsoft.EntityFrameworkCore.Migrations;

namespace bucket_soldier_games.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShoppingCartId = table.Column<string>(type: "TEXT", nullable: true),
                    Gameid = table.Column<int>(type: "INTEGER", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Games_Gameid",
                        column: x => x.Gameid,
                        principalTable: "Games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_Gameid",
                table: "ShoppingCartItems",
                column: "Gameid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");
        }
    }
}
