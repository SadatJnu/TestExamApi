using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestExamApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiseaseInformations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseInformations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PatientInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeseaseId = table.Column<int>(type: "int", nullable: false),
                    EpilepsyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientInfoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Allergies_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NCDs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientInfoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NCDs_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Allergies_Details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    AllergisID = table.Column<int>(type: "int", nullable: false),
                    AllergiesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Allergies_Details_Allergies_AllergiesID",
                        column: x => x.AllergiesID,
                        principalTable: "Allergies",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NCD_Details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    NCDID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NCD_Details_NCDs_NCDID",
                        column: x => x.NCDID,
                        principalTable: "NCDs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_PatientInfoID",
                table: "Allergies",
                column: "PatientInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Details_AllergiesID",
                table: "Allergies_Details",
                column: "AllergiesID");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_NCDID",
                table: "NCD_Details",
                column: "NCDID");

            migrationBuilder.CreateIndex(
                name: "IX_NCDs_PatientInfoID",
                table: "NCDs",
                column: "PatientInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies_Details");

            migrationBuilder.DropTable(
                name: "DiseaseInformations");

            migrationBuilder.DropTable(
                name: "NCD_Details");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "NCDs");

            migrationBuilder.DropTable(
                name: "PatientInfos");
        }
    }
}
