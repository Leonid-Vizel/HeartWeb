using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HeartWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    SaveTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ChildSex = table.Column<int>(type: "integer", nullable: false),
                    BirthTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DaysPassed = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Region = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Town = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Prematurity = table.Column<bool>(type: "boolean", nullable: false),
                    Aspiration = table.Column<bool>(type: "boolean", nullable: false),
                    Apgar = table.Column<byte>(type: "smallint", nullable: false),
                    StatusDynamics = table.Column<byte>(type: "smallint", nullable: false),
                    BreathFrequency = table.Column<byte>(type: "smallint", nullable: false),
                    HeartBeatFrequency = table.Column<byte>(type: "smallint", nullable: false),
                    SkinColor = table.Column<byte>(type: "smallint", nullable: false),
                    PerepherialPulse = table.Column<byte>(type: "smallint", nullable: false),
                    AuskultativePicture = table.Column<byte>(type: "smallint", nullable: false),
                    NoiseDynamics = table.Column<byte>(type: "smallint", nullable: false),
                    WeightDynamics = table.Column<byte>(type: "smallint", nullable: false),
                    Diurez = table.Column<byte>(type: "smallint", nullable: false),
                    AuskultativeLungPicture = table.Column<byte>(type: "smallint", nullable: false),
                    CardioDynamics = table.Column<byte>(type: "smallint", nullable: false),
                    OxygenBreathTest = table.Column<byte>(type: "smallint", nullable: false),
                    ArterialPressure = table.Column<byte>(type: "smallint", nullable: false),
                    ECG = table.Column<byte>(type: "smallint", nullable: false),
                    Rentgenography = table.Column<byte>(type: "smallint", nullable: false),
                    LungFields = table.Column<byte>(type: "smallint", nullable: false),
                    Saturation = table.Column<byte>(type: "smallint", nullable: false),
                    PO2 = table.Column<byte>(type: "smallint", nullable: false),
                    AcidAlkalineState = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Region = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsFromCity = table.Column<bool>(type: "boolean", nullable: false),
                    Admin = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "FormResults");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
