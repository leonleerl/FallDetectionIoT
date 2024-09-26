using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FallDetectionIoT.WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FallDetecionTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FallDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accelX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accelY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accelZ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FallDetecionTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FallDetecionTable");
        }
    }
}
