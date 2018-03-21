using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventManager.Domain.Migrations
{
    public partial class RepairedUserIdInEventUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_SimpleUser_UserId",
                table: "EventUser");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "EventUser",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_SimpleUser_UserId",
                table: "EventUser",
                column: "UserId",
                principalTable: "SimpleUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_SimpleUser_UserId",
                table: "EventUser");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "EventUser",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_SimpleUser_UserId",
                table: "EventUser",
                column: "UserId",
                principalTable: "SimpleUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
