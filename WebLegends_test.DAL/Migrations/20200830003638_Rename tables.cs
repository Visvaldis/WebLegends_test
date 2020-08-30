using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLegends_test.DAL.Migrations
{
    public partial class Renametables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Statuses_StatusId",
                table: "Facilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "FacilityStatuses");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "FacilityLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacilityStatuses",
                table: "FacilityStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacilityLogs",
                table: "FacilityLogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_FacilityStatuses_StatusId",
                table: "Facilities",
                column: "StatusId",
                principalTable: "FacilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_FacilityStatuses_StatusId",
                table: "Facilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacilityStatuses",
                table: "FacilityStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacilityLogs",
                table: "FacilityLogs");

            migrationBuilder.RenameTable(
                name: "FacilityStatuses",
                newName: "Statuses");

            migrationBuilder.RenameTable(
                name: "FacilityLogs",
                newName: "Logs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Statuses_StatusId",
                table: "Facilities",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
