using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BandAide.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandSearches_Instruments_PreferredInstrumentId",
                table: "BandSearches");

            migrationBuilder.DropForeignKey(
                name: "FK_BandSearches_AspNetUsers_UserId",
                table: "BandSearches");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberSearches_Bands_BandId",
                table: "MemberSearches");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberSearches_Instruments_InstrumentId",
                table: "MemberSearches");

            migrationBuilder.DropIndex(
                name: "IX_MemberSearches_BandId",
                table: "MemberSearches");

            migrationBuilder.DropIndex(
                name: "IX_BandSearches_UserId",
                table: "BandSearches");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BandSearches");

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentId",
                table: "MemberSearches",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "MemberSearches",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PreferredInstrumentId",
                table: "BandSearches",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "BandSearches",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BandSearches_Instruments_PreferredInstrumentId",
                table: "BandSearches",
                column: "PreferredInstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSearches_Bands_BandId",
                table: "MemberSearches",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSearches_Instruments_InstrumentId",
                table: "MemberSearches",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandSearches_AspNetUsers_AppUserId",
                table: "BandSearches");

            migrationBuilder.DropForeignKey(
                name: "FK_BandSearches_Instruments_PreferredInstrumentId",
                table: "BandSearches");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberSearches_Bands_BandId",
                table: "MemberSearches");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberSearches_Instruments_InstrumentId",
                table: "MemberSearches");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_MemberSearches_BandId_InstrumentId",
                table: "MemberSearches");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_BandSearches_AppUserId_PreferredInstrumentId",
                table: "BandSearches");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BandSearches");

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentId",
                table: "MemberSearches",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BandId",
                table: "MemberSearches",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PreferredInstrumentId",
                table: "BandSearches",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BandSearches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberSearches_BandId",
                table: "MemberSearches",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_BandSearches_UserId",
                table: "BandSearches",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BandSearches_Instruments_PreferredInstrumentId",
                table: "BandSearches",
                column: "PreferredInstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BandSearches_AspNetUsers_UserId",
                table: "BandSearches",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSearches_Bands_BandId",
                table: "MemberSearches",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSearches_Instruments_InstrumentId",
                table: "MemberSearches",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
