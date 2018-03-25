using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventManager.Domain.Migrations
{
    public partial class adding_user_to_event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Events_EventId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_SimpleUser_UserId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureUser_Lectures_LectureId",
                table: "LectureUser");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureUser_SimpleUser_UserId",
                table: "LectureUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Lectures_LectureId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_SimpleUser_ReviewerId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SimpleUser",
                table: "SimpleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LectureUser",
                table: "LectureUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventUser",
                table: "EventUser");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "SimpleUser",
                newName: "SimpleUsers");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "LectureUser",
                newName: "LectureUsers");

            migrationBuilder.RenameTable(
                name: "EventUser",
                newName: "EventUsers");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ReviewerId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_LectureId",
                table: "Reviews",
                newName: "IX_Reviews_LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureUser_UserId",
                table: "LectureUsers",
                newName: "IX_LectureUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureUser_LectureId",
                table: "LectureUsers",
                newName: "IX_LectureUsers_LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_UserId",
                table: "EventUsers",
                newName: "IX_EventUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_EventId",
                table: "EventUsers",
                newName: "IX_EventUsers_EventId");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Events",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimpleUsers",
                table: "SimpleUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LectureUsers",
                table: "LectureUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventUsers",
                table: "EventUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OwnerId",
                table: "Events",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_SimpleUsers_OwnerId",
                table: "Events",
                column: "OwnerId",
                principalTable: "SimpleUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUsers_Events_EventId",
                table: "EventUsers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUsers_SimpleUsers_UserId",
                table: "EventUsers",
                column: "UserId",
                principalTable: "SimpleUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureUsers_Lectures_LectureId",
                table: "LectureUsers",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureUsers_SimpleUsers_UserId",
                table: "LectureUsers",
                column: "UserId",
                principalTable: "SimpleUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Lectures_LectureId",
                table: "Reviews",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_SimpleUsers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "SimpleUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_SimpleUsers_OwnerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUsers_Events_EventId",
                table: "EventUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUsers_SimpleUsers_UserId",
                table: "EventUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureUsers_Lectures_LectureId",
                table: "LectureUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureUsers_SimpleUsers_UserId",
                table: "LectureUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Lectures_LectureId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_SimpleUsers_ReviewerId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SimpleUsers",
                table: "SimpleUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LectureUsers",
                table: "LectureUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventUsers",
                table: "EventUsers");

            migrationBuilder.DropIndex(
                name: "IX_Events_OwnerId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "SimpleUsers",
                newName: "SimpleUser");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "LectureUsers",
                newName: "LectureUser");

            migrationBuilder.RenameTable(
                name: "EventUsers",
                newName: "EventUser");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Review",
                newName: "IX_Review_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_LectureId",
                table: "Review",
                newName: "IX_Review_LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureUsers_UserId",
                table: "LectureUser",
                newName: "IX_LectureUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureUsers_LectureId",
                table: "LectureUser",
                newName: "IX_LectureUser_LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUsers_UserId",
                table: "EventUser",
                newName: "IX_EventUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUsers_EventId",
                table: "EventUser",
                newName: "IX_EventUser_EventId");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Events",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimpleUser",
                table: "SimpleUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LectureUser",
                table: "LectureUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventUser",
                table: "EventUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Events_EventId",
                table: "EventUser",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_SimpleUser_UserId",
                table: "EventUser",
                column: "UserId",
                principalTable: "SimpleUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureUser_Lectures_LectureId",
                table: "LectureUser",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureUser_SimpleUser_UserId",
                table: "LectureUser",
                column: "UserId",
                principalTable: "SimpleUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Lectures_LectureId",
                table: "Review",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_SimpleUser_ReviewerId",
                table: "Review",
                column: "ReviewerId",
                principalTable: "SimpleUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
