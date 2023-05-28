using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEventsTable_UserEvent_UserEventId",
                table: "UserEventsTable");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEventsTable_User_UserId",
                table: "UserEventsTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEventsTable",
                table: "UserEventsTable");

            migrationBuilder.RenameTable(
                name: "UserEventsTable",
                newName: "UserEventTable");

            migrationBuilder.RenameIndex(
                name: "IX_UserEventsTable_UserId",
                table: "UserEventTable",
                newName: "IX_UserEventTable_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserEventTable",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEventTable",
                table: "UserEventTable",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventTable_UserEventId",
                table: "UserEventTable",
                column: "UserEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEventTable_UserEvent_UserEventId",
                table: "UserEventTable",
                column: "UserEventId",
                principalTable: "UserEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEventTable_User_UserId",
                table: "UserEventTable",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEventTable_UserEvent_UserEventId",
                table: "UserEventTable");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEventTable_User_UserId",
                table: "UserEventTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEventTable",
                table: "UserEventTable");

            migrationBuilder.DropIndex(
                name: "IX_UserEventTable_UserEventId",
                table: "UserEventTable");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserEventTable");

            migrationBuilder.RenameTable(
                name: "UserEventTable",
                newName: "UserEventsTable");

            migrationBuilder.RenameIndex(
                name: "IX_UserEventTable_UserId",
                table: "UserEventsTable",
                newName: "IX_UserEventsTable_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEventsTable",
                table: "UserEventsTable",
                columns: new[] { "UserEventId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserEventsTable_UserEvent_UserEventId",
                table: "UserEventsTable",
                column: "UserEventId",
                principalTable: "UserEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEventsTable_User_UserId",
                table: "UserEventsTable",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
