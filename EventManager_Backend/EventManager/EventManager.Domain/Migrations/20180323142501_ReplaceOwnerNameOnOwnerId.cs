using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventManager.Domain.Migrations
{
    public partial class ReplaceOwnerNameOnOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_SimpleUser_OwnerId",
                table: "Events");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_SimpleUser_OwnerId",
                table: "Events",
                column: "OwnerId",
                principalTable: "SimpleUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_SimpleUser_OwnerId",
                table: "Events");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_SimpleUser_OwnerId",
                table: "Events",
                column: "OwnerId",
                principalTable: "SimpleUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
