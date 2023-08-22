using Microsoft.EntityFrameworkCore.Migrations;

namespace BookEvent.Migrations
{
    public partial class AddedEventType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTypeModel_TypeID",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventTypeModel");

            migrationBuilder.DropIndex(
                name: "IX_Events_TypeID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventTypeID",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeID",
                table: "Events",
                column: "EventTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventTypes_EventTypeID",
                table: "Events",
                column: "EventTypeID",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTypes_EventTypeID",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventTypeID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventTypeID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventTypeModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypeModel", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_TypeID",
                table: "Events",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventTypeModel_TypeID",
                table: "Events",
                column: "TypeID",
                principalTable: "EventTypeModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
