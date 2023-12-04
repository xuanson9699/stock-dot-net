using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAppWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addEtfQuotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EtfQuotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtfId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentChange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalVolume = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtfQuotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtfQuotes_Etfs_EtfId",
                        column: x => x.EtfId,
                        principalTable: "Etfs",
                        principalColumn: "EtfId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtfQuotes_EtfId",
                table: "EtfQuotes",
                column: "EtfId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtfQuotes");
        }
    }
}
