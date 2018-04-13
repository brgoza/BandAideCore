using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BandAide.Migrations
{
    public partial class ChangedPreferredInstrumntToInstrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandSearches_Instruments_PreferredInstrumentId",
                table: "BandSearches");

            migrationBuilder.RenameColumn(
                name: "PreferredInstrumentId",
                table: "BandSearches",
                newName: "InstrumentId");

            migrationBuilder.RenameIndex(
                name: "IX_BandSearches_PreferredInstrumentId",
                table: "BandSearches",
                newName: "IX_BandSearches_InstrumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BandSearches_Instruments_InstrumentId",
                table: "BandSearches",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandSearches_Instruments_InstrumentId",
                table: "BandSearches");

            migrationBuilder.RenameColumn(
                name: "InstrumentId",
                table: "BandSearches",
                newName: "PreferredInstrumentId");

            migrationBuilder.RenameIndex(
                name: "IX_BandSearches_InstrumentId",
                table: "BandSearches",
                newName: "IX_BandSearches_PreferredInstrumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BandSearches_Instruments_PreferredInstrumentId",
                table: "BandSearches",
                column: "PreferredInstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
