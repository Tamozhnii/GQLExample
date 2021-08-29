using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace GQLExample.Migrations
{
    public partial class AddShadesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LocalName = table.Column<string>(type: "text", nullable: false),
                    HEX = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shades", x => x.Id);
                }
            );

            migrationBuilder.InsertData(
                table: "Shades", 
                columns: new[] {"Name", "LocalName", "HEX"}, 
                values: new[,] {
                    {"Black", "Чёрный", "#000000"}, 
                    {"White", "Белый", "#FFFFFF"},
                    {"Gray", "Серый", "#808080"},
                    {"Red", "Красный", "#FF0000"},
                    {"Orange", "Оранжевый", "#FF4500"},
                    {"Yellow", "Желтый", "#FFFF00"},
                    {"Green", "Зеленый", "#00FF00"},
                    {"Azure", "Голубой", "#00BFFF"},
                    {"Blue", "Синий", "#0000FF"},
                    {"Purple", "Фиолетовый", "#800080"},
                    {"Pink", "Розовый", "#FFC0CB"},
                    {"Brown", "Коричневый", "#964B00"},
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shades");
        }
    }
}
