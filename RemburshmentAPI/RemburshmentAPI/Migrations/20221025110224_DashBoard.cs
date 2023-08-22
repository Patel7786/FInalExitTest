using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RemburshmentAPI.Migrations
{
    public partial class DashBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyType",
                columns: table => new
                {
                    CurrencyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyType", x => x.CurrencyID);
                });

            migrationBuilder.CreateTable(
                name: "Dashboard",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    RequestedValue = table.Column<int>(nullable: false),
                    RemburshmentID = table.Column<int>(nullable: false),
                    CurrencyID = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ApprovedBy = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboard", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DashboardModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    RequestedValue = table.Column<int>(nullable: false),
                    RemburshmentID = table.Column<int>(nullable: false),
                    CurrencyID = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ApprovedBy = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RemburshmentType",
                columns: table => new
                {
                    RemburshmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemburshmentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemburshmentType", x => x.RemburshmentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyType");

            migrationBuilder.DropTable(
                name: "Dashboard");

            migrationBuilder.DropTable(
                name: "DashboardModel");

            migrationBuilder.DropTable(
                name: "RemburshmentType");
        }
    }
}
