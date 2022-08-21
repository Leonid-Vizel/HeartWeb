using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeartWeb.Migrations
{
    public partial class ModifiedUserAndForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthTime",
                table: "FormResults",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ChildSex",
                table: "FormResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "FormResults",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "FormResults",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "FormResults",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthTime",
                table: "FormResults");

            migrationBuilder.DropColumn(
                name: "ChildSex",
                table: "FormResults");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "FormResults");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "FormResults");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "FormResults");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
