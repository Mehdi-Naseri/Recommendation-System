using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecSys.Data.Migrations
{
    public partial class AddCollaborativfitering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollaborativeRecommendation",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Item1 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating1 = table.Column<double>(nullable: true),
                    Item2 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating2 = table.Column<double>(nullable: true),
                    Item3 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating3 = table.Column<double>(nullable: true),
                    Item4 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating4 = table.Column<double>(nullable: true),
                    Item5 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating5 = table.Column<double>(nullable: true),
                    Item6 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating6 = table.Column<double>(nullable: true),
                    Item7 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating7 = table.Column<double>(nullable: true),
                    Item8 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating8 = table.Column<double>(nullable: true),
                    Item9 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating9 = table.Column<double>(nullable: true),
                    Item10 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating10 = table.Column<double>(nullable: true),
                    Item11 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating11 = table.Column<double>(nullable: true),
                    Item12 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating12 = table.Column<double>(nullable: true),
                    Item13 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating13 = table.Column<double>(nullable: true),
                    Item14 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating14 = table.Column<double>(nullable: true),
                    Item15 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating15 = table.Column<double>(nullable: true),
                    Item16 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating16 = table.Column<double>(nullable: true),
                    Item17 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating17 = table.Column<double>(nullable: true),
                    Item18 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating18 = table.Column<double>(nullable: true),
                    Item19 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating19 = table.Column<double>(nullable: true),
                    Item20 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating20 = table.Column<double>(nullable: true),
                    Item21 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating21 = table.Column<double>(nullable: true),
                    Item22 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating22 = table.Column<double>(nullable: true),
                    Item23 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating23 = table.Column<double>(nullable: true),
                    Item24 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating24 = table.Column<double>(nullable: true),
                    Item25 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating25 = table.Column<double>(nullable: true),
                    Item26 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating26 = table.Column<double>(nullable: true),
                    Item27 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating27 = table.Column<double>(nullable: true),
                    Item28 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating28 = table.Column<double>(nullable: true),
                    Item29 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating29 = table.Column<double>(nullable: true),
                    Item30 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating30 = table.Column<double>(nullable: true),
                    Item31 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating31 = table.Column<double>(nullable: true),
                    Item32 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating32 = table.Column<double>(nullable: true),
                    Item33 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating33 = table.Column<double>(nullable: true),
                    Item34 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating34 = table.Column<double>(nullable: true),
                    Item35 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating35 = table.Column<double>(nullable: true),
                    Item36 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating36 = table.Column<double>(nullable: true),
                    Item37 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating37 = table.Column<double>(nullable: true),
                    Item38 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating38 = table.Column<double>(nullable: true),
                    Item39 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating39 = table.Column<double>(nullable: true),
                    Item40 = table.Column<string>(maxLength: 10, nullable: true),
                    Rating40 = table.Column<double>(nullable: true),
                    Item41 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating41 = table.Column<double>(nullable: true),
                    Item42 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating42 = table.Column<double>(nullable: true),
                    Item43 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating43 = table.Column<double>(nullable: true),
                    Item44 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating44 = table.Column<double>(nullable: true),
                    Item45 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating45 = table.Column<double>(nullable: true),
                    Item46 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating46 = table.Column<double>(nullable: true),
                    Item47 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating47 = table.Column<double>(nullable: true),
                    Item48 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating48 = table.Column<double>(nullable: true),
                    Item49 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating49 = table.Column<double>(nullable: true),
                    Item50 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating50 = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborativeRecommendation", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaborativeRecommendation");
        }
    }
}
