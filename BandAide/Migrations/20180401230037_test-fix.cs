using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BandAide.Migrations
{
    public partial class testfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandSearches_AspNetUsers_AppUserId",
                table: "BandSearches");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_MemberSearches_BandId_InstrumentId",
                table: "MemberSearches");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_BandSearches_AppUserId_PreferredInstrumentId",
                table: "BandSearches");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "BandSearches",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_MemberSearches_BandId",
                table: "MemberSearches",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_BandSearches_AppUserId",
                table: "BandSearches",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BandSearches_AspNetUsers_AppUserId",
                table: "BandSearches",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandSearches_AspNetUsers_AppUserId",
                table: "BandSearches");

            migrationBuilder.DropIndex(
                name: "IX_MemberSearches_BandId",
                table: "MemberSearches");

            migrationBuilder.DropIndex(
                name: "IX_BandSearches_AppUserId",
                table: "BandSearches");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "BandSearches",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_MemberSearches_BandId_InstrumentId",
                table: "MemberSearches",
                columns: new[] { "BandId", "InstrumentId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_BandSearches_AppUserId_PreferredInstrumentId",
                table: "BandSearches",
                columns: new[] { "AppUserId", "PreferredInstrumentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BandSearches_AspNetUsers_AppUserId",
                table: "BandSearches",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
