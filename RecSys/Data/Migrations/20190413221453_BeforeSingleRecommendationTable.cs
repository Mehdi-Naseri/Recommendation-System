using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecSys.Data.Migrations
{
    public partial class BeforeSingleRecommendationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CollaborativeRecommendation",
                table: "CollaborativeRecommendation");

            migrationBuilder.RenameTable(
                name: "CollaborativeRecommendation",
                newName: "SQLexport_CollaborativeFiltering-506user-0similarity");

            migrationBuilder.AlterColumn<string>(
                name: "Item40",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item39",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item38",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item37",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item36",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item35",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item34",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item33",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item32",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item31",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item20",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item19",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item18",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item17",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item16",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item15",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item14",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item13",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item12",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item11",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SQLexport_CollaborativeFiltering-506user-0similarity",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "EnsembleRecommendation",
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
                    Item11 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating11 = table.Column<double>(nullable: true),
                    Item12 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating12 = table.Column<double>(nullable: true),
                    Item13 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating13 = table.Column<double>(nullable: true),
                    Item14 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating14 = table.Column<double>(nullable: true),
                    Item15 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating15 = table.Column<double>(nullable: true),
                    Item16 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating16 = table.Column<double>(nullable: true),
                    Item17 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating17 = table.Column<double>(nullable: true),
                    Item18 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating18 = table.Column<double>(nullable: true),
                    Item19 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating19 = table.Column<double>(nullable: true),
                    Item20 = table.Column<string>(maxLength: 20, nullable: true),
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
                    Item31 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating31 = table.Column<double>(nullable: true),
                    Item32 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating32 = table.Column<double>(nullable: true),
                    Item33 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating33 = table.Column<double>(nullable: true),
                    Item34 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating34 = table.Column<double>(nullable: true),
                    Item35 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating35 = table.Column<double>(nullable: true),
                    Item36 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating36 = table.Column<double>(nullable: true),
                    Item37 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating37 = table.Column<double>(nullable: true),
                    Item38 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating38 = table.Column<double>(nullable: true),
                    Item39 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating39 = table.Column<double>(nullable: true),
                    Item40 = table.Column<string>(maxLength: 20, nullable: true),
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
                    table.PrimaryKey("PK_EnsembleRecommendation", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FrequentSequentialPattern2items-10Months",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sequence = table.Column<string>(nullable: false),
                    Support = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequentSequentialPattern2items-10Months", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseHistoryRecommendation",
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
                    Item11 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating11 = table.Column<double>(nullable: true),
                    Item12 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating12 = table.Column<double>(nullable: true),
                    Item13 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating13 = table.Column<double>(nullable: true),
                    Item14 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating14 = table.Column<double>(nullable: true),
                    Item15 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating15 = table.Column<double>(nullable: true),
                    Item16 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating16 = table.Column<double>(nullable: true),
                    Item17 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating17 = table.Column<double>(nullable: true),
                    Item18 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating18 = table.Column<double>(nullable: true),
                    Item19 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating19 = table.Column<double>(nullable: true),
                    Item20 = table.Column<string>(maxLength: 20, nullable: true),
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
                    Item31 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating31 = table.Column<double>(nullable: true),
                    Item32 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating32 = table.Column<double>(nullable: true),
                    Item33 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating33 = table.Column<double>(nullable: true),
                    Item34 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating34 = table.Column<double>(nullable: true),
                    Item35 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating35 = table.Column<double>(nullable: true),
                    Item36 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating36 = table.Column<double>(nullable: true),
                    Item37 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating37 = table.Column<double>(nullable: true),
                    Item38 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating38 = table.Column<double>(nullable: true),
                    Item39 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating39 = table.Column<double>(nullable: true),
                    Item40 = table.Column<string>(maxLength: 20, nullable: true),
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
                    table.PrimaryKey("PK_PurchaseHistoryRecommendation", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationInfo",
                columns: table => new
                {
                    RecId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationInfo", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "SequentialRecommendation",
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
                    Item11 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating11 = table.Column<double>(nullable: true),
                    Item12 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating12 = table.Column<double>(nullable: true),
                    Item13 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating13 = table.Column<double>(nullable: true),
                    Item14 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating14 = table.Column<double>(nullable: true),
                    Item15 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating15 = table.Column<double>(nullable: true),
                    Item16 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating16 = table.Column<double>(nullable: true),
                    Item17 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating17 = table.Column<double>(nullable: true),
                    Item18 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating18 = table.Column<double>(nullable: true),
                    Item19 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating19 = table.Column<double>(nullable: true),
                    Item20 = table.Column<string>(maxLength: 20, nullable: true),
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
                    Item31 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating31 = table.Column<double>(nullable: true),
                    Item32 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating32 = table.Column<double>(nullable: true),
                    Item33 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating33 = table.Column<double>(nullable: true),
                    Item34 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating34 = table.Column<double>(nullable: true),
                    Item35 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating35 = table.Column<double>(nullable: true),
                    Item36 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating36 = table.Column<double>(nullable: true),
                    Item37 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating37 = table.Column<double>(nullable: true),
                    Item38 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating38 = table.Column<double>(nullable: true),
                    Item39 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating39 = table.Column<double>(nullable: true),
                    Item40 = table.Column<string>(maxLength: 20, nullable: true),
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
                    table.PrimaryKey("PK_SequentialRecommendation", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SQLexport_CollaborativeFiltering-506user-3similarity_NotPurchased",
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
                    Item11 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating11 = table.Column<double>(nullable: true),
                    Item12 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating12 = table.Column<double>(nullable: true),
                    Item13 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating13 = table.Column<double>(nullable: true),
                    Item14 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating14 = table.Column<double>(nullable: true),
                    Item15 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating15 = table.Column<double>(nullable: true),
                    Item16 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating16 = table.Column<double>(nullable: true),
                    Item17 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating17 = table.Column<double>(nullable: true),
                    Item18 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating18 = table.Column<double>(nullable: true),
                    Item19 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating19 = table.Column<double>(nullable: true),
                    Item20 = table.Column<string>(maxLength: 20, nullable: true),
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
                    Item31 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating31 = table.Column<double>(nullable: true),
                    Item32 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating32 = table.Column<double>(nullable: true),
                    Item33 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating33 = table.Column<double>(nullable: true),
                    Item34 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating34 = table.Column<double>(nullable: true),
                    Item35 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating35 = table.Column<double>(nullable: true),
                    Item36 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating36 = table.Column<double>(nullable: true),
                    Item37 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating37 = table.Column<double>(nullable: true),
                    Item38 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating38 = table.Column<double>(nullable: true),
                    Item39 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating39 = table.Column<double>(nullable: true),
                    Item40 = table.Column<string>(maxLength: 20, nullable: true),
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
                    table.PrimaryKey("PK_SQLexport_CollaborativeFiltering-506user-3similarity_NotPurchased", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Recommendation",
                columns: table => new
                {
                    RecommendationInfoId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
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
                    Item11 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating11 = table.Column<double>(nullable: true),
                    Item12 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating12 = table.Column<double>(nullable: true),
                    Item13 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating13 = table.Column<double>(nullable: true),
                    Item14 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating14 = table.Column<double>(nullable: true),
                    Item15 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating15 = table.Column<double>(nullable: true),
                    Item16 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating16 = table.Column<double>(nullable: true),
                    Item17 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating17 = table.Column<double>(nullable: true),
                    Item18 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating18 = table.Column<double>(nullable: true),
                    Item19 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating19 = table.Column<double>(nullable: true),
                    Item20 = table.Column<string>(maxLength: 20, nullable: true),
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
                    Item31 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating31 = table.Column<double>(nullable: true),
                    Item32 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating32 = table.Column<double>(nullable: true),
                    Item33 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating33 = table.Column<double>(nullable: true),
                    Item34 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating34 = table.Column<double>(nullable: true),
                    Item35 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating35 = table.Column<double>(nullable: true),
                    Item36 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating36 = table.Column<double>(nullable: true),
                    Item37 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating37 = table.Column<double>(nullable: true),
                    Item38 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating38 = table.Column<double>(nullable: true),
                    Item39 = table.Column<string>(maxLength: 20, nullable: true),
                    Rating39 = table.Column<double>(nullable: true),
                    Item40 = table.Column<string>(maxLength: 20, nullable: true),
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
                    table.PrimaryKey("PK_Recommendation", x => x.RecommendationInfoId);
                    table.ForeignKey(
                        name: "FK_Recommendation_RecommendationInfo_RecommendationInfoId",
                        column: x => x.RecommendationInfoId,
                        principalTable: "RecommendationInfo",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnsembleRecommendation");

            migrationBuilder.DropTable(
                name: "FrequentSequentialPattern2items-10Months");

            migrationBuilder.DropTable(
                name: "PurchaseHistoryRecommendation");

            migrationBuilder.DropTable(
                name: "Recommendation");

            migrationBuilder.DropTable(
                name: "SequentialRecommendation");

            migrationBuilder.DropTable(
                name: "SQLexport_CollaborativeFiltering-506user-3similarity_NotPurchased");

            migrationBuilder.DropTable(
                name: "RecommendationInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SQLexport_CollaborativeFiltering-506user-0similarity",
                table: "SQLexport_CollaborativeFiltering-506user-0similarity");

            migrationBuilder.RenameTable(
                name: "SQLexport_CollaborativeFiltering-506user-0similarity",
                newName: "CollaborativeRecommendation");

            migrationBuilder.AlterColumn<string>(
                name: "Item40",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item39",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item38",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item37",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item36",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item35",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item34",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item33",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item32",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item31",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item20",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item19",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item18",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item17",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item16",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item15",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item14",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item13",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item12",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Item11",
                table: "CollaborativeRecommendation",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollaborativeRecommendation",
                table: "CollaborativeRecommendation",
                column: "UserId");
        }
    }
}
