using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevPloyApiApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvancedForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GitHubProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inspiration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProudProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnjoymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearningMotivation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionAdherence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamExperienceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PythonProficiency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JavaProficiency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSharpProficiency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SQLProficiency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvancedForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GitHub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedProject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgrammingLanguages = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Otp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtpExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillingAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvancedForms");

            migrationBuilder.DropTable(
                name: "BaseForms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
