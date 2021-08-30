using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace GQLExample.Migrations
{
    public partial class AddBrightnessSaturationAndColorToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brightnesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    LocalValue = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brightnesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saturations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    LocalValue = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saturations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HEX = table.Column<string>(type: "text", nullable: false),
                    Association = table.Column<string>(type: "text", nullable: true),
                    BrightnessId = table.Column<int>(type: "int", nullable: false),
                    SaturationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colors_Brightnesses_BrightnessId",
                        column: x => x.BrightnessId,
                        principalTable: "Brightnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colors_Saturations_SaturationId",
                        column: x => x.SaturationId,
                        principalTable: "Saturations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorShade",
                columns: table => new{
                    ColorsColorId = table.Column<int>(type: "int", nullable: false),
                    ShadesShadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ColorShade", x => new {x.ColorsColorId, x.ShadesShadeId});
                    table.ForeignKey(
                        name: "FK_ColorShade_Colors_ColorsColorId",
                        column: x => x.ColorsColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ColorShade_Shades_ShadesShadeId",
                        column: x => x.ShadesShadeId,
                        principalTable: "Shades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Colors_BrightnessId",
                table: "Colors",
                column: "BrightnessId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_SaturationId",
                table: "Colors",
                column: "SaturationId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorShade_ShadesId",
                table: "ColorShade",
                column: "ShadesShadeId");

            migrationBuilder.InsertData(
                table: "Brightnesses",
                columns: new []{"Value", "LocalValue"},
                values: new [,] {{"Light","Светлый"},{"Average","Средний"},{"Dark","Темный"}}
            );

            migrationBuilder.InsertData(
                table: "Saturations",
                columns: new []{"Value", "LocalValue"},
                values: new [,] {{"Pale","Бледный"},{"Midsaturated","Средне-насыщенный"},{"Saturated","Насыщенный"}}
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorShade");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Brightnesses");

            migrationBuilder.DropTable(
                name: "Saturations");
        }
    }
}
