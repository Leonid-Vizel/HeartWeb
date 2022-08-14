﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeartWeb.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prematurity = table.Column<bool>(type: "bit", nullable: false),
                    Aspiration = table.Column<bool>(type: "bit", nullable: false),
                    Apgar = table.Column<byte>(type: "tinyint", nullable: false),
                    StatusDynamics = table.Column<byte>(type: "tinyint", nullable: false),
                    BreathFrequency = table.Column<byte>(type: "tinyint", nullable: false),
                    HeartBeatFrequency = table.Column<byte>(type: "tinyint", nullable: false),
                    SkinColor = table.Column<byte>(type: "tinyint", nullable: false),
                    PerepherialPulse = table.Column<byte>(type: "tinyint", nullable: false),
                    AuskultativePicture = table.Column<byte>(type: "tinyint", nullable: false),
                    NoiseDynamics = table.Column<byte>(type: "tinyint", nullable: false),
                    WeightDynamics = table.Column<byte>(type: "tinyint", nullable: false),
                    Diurez = table.Column<byte>(type: "tinyint", nullable: false),
                    AuskultativeLungPicture = table.Column<byte>(type: "tinyint", nullable: false),
                    CardioDynamics = table.Column<byte>(type: "tinyint", nullable: false),
                    OxygenBreathTest = table.Column<byte>(type: "tinyint", nullable: false),
                    ArterialPressure = table.Column<byte>(type: "tinyint", nullable: false),
                    ECG = table.Column<byte>(type: "tinyint", nullable: false),
                    Rentgenography = table.Column<byte>(type: "tinyint", nullable: false),
                    LungFields = table.Column<byte>(type: "tinyint", nullable: false),
                    Saturation = table.Column<byte>(type: "tinyint", nullable: false),
                    PO2 = table.Column<byte>(type: "tinyint", nullable: false),
                    AcidAlkalineState = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormResults");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
