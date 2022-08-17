using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeartWeb.Migrations
{
    public partial class AddedSaveTimeToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SaveTime",
                table: "FormResults",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaveTime",
                table: "FormResults");
        }
    }
}
