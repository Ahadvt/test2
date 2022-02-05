using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class createdsettingandslider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(maxLength: 100, nullable: false),
                    SearchIcon = table.Column<string>(maxLength: 100, nullable: false),
                    InfoTitle = table.Column<string>(maxLength: 100, nullable: false),
                    InfoDescriptionTop = table.Column<string>(maxLength: 300, nullable: true),
                    InfoDescriptionBottom = table.Column<string>(maxLength: 300, nullable: true),
                    InfoImg = table.Column<string>(maxLength: 100, nullable: false),
                    InfoLink = table.Column<string>(maxLength: 200, nullable: true),
                    FooterLogo = table.Column<string>(maxLength: 100, nullable: false),
                    FooterDedcription = table.Column<string>(maxLength: 250, nullable: false),
                    PhoneNumber1 = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber2 = table.Column<string>(maxLength: 50, nullable: true),
                    Mail = table.Column<string>(maxLength: 100, nullable: true),
                    WebAddress = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderImg = table.Column<string>(maxLength: 80, nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Descrtiption = table.Column<string>(maxLength: 250, nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
