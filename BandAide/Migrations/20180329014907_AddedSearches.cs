using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BandAide.Migrations
{
    public partial class AddedSearches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BandSearches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PreferredInstrumentId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandSearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BandSearches_Instruments_PreferredInstrumentId",
                        column: x => x.PreferredInstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BandSearches_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberSearches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BandId = table.Column<int>(nullable: true),
                    InstrumentId = table.Column<int>(nullable: true),
                    MinProficiency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberSearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberSearches_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberSearches_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BandSearches_PreferredInstrumentId",
                table: "BandSearches",
                column: "PreferredInstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BandSearches_UserId",
                table: "BandSearches",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberSearches_BandId",
                table: "MemberSearches",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberSearches_InstrumentId",
                table: "MemberSearches",
                column: "InstrumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BandSearches");

            migrationBuilder.DropTable(
                name: "MemberSearches");
        }
    }
}
