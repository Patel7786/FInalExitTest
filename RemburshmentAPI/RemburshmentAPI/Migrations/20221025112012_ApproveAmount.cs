using Microsoft.EntityFrameworkCore.Migrations;

namespace RemburshmentAPI.Migrations
{
    public partial class ApproveAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedValue",
                table: "DashboardModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedValue",
                table: "Dashboard",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedValue",
                table: "DashboardModel");

            migrationBuilder.DropColumn(
                name: "ApprovedValue",
                table: "Dashboard");
        }
    }
}
