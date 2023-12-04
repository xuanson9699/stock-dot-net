using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAppWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addtableconstituent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndexConstituents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndexId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexConstituents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndexConstituents_MarketIndexs_IndexId",
                        column: x => x.IndexId,
                        principalTable: "MarketIndexs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndexConstituents_stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "stocks",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndexConstituents_IndexId",
                table: "IndexConstituents",
                column: "IndexId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexConstituents_StockId",
                table: "IndexConstituents",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndexConstituents");
        }
    }
}
