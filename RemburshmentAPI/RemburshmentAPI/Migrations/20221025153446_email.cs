using Microsoft.EntityFrameworkCore.Migrations;

namespace RemburshmentAPI.Migrations
{
    public partial class email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DashboardModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Dashboard",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurrencyTypeModel",
                columns: table => new
                {
                    CurrencyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTypeModel", x => x.CurrencyID);
                });

            migrationBuilder.CreateTable(
                name: "RemburshmentTypeMode",
                columns: table => new
                {
                    RemburshmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemburshmentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemburshmentTypeMode", x => x.RemburshmentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyTypeModel");

            migrationBuilder.DropTable(
                name: "RemburshmentTypeMode");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DashboardModel");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Dashboard");
        }
    }
}
