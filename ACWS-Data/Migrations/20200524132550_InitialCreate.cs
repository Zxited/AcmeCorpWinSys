using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACWS_Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    LastName = table.Column<string>(maxLength: 64, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    ToSPP = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ParticipantID);
                });

            migrationBuilder.CreateTable(
                name: "PrizePool",
                columns: table => new
                {
                    PrizePoolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrizePoolName = table.Column<string>(nullable: true),
                    PrizePoolDescription = table.Column<string>(nullable: true),
                    PrizePoolImage = table.Column<string>(nullable: true),
                    PrizePoolQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrizePool", x => x.PrizePoolID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    AvailableQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "SerialNumber",
                columns: table => new
                {
                    SerialNumberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantID = table.Column<int>(nullable: false),
                    SerialKey = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumber", x => x.SerialNumberID);
                    table.ForeignKey(
                        name: "FK_SerialNumber_Participant_ParticipantID",
                        column: x => x.ParticipantID,
                        principalTable: "Participant",
                        principalColumn: "ParticipantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prize",
                columns: table => new
                {
                    PrizePoolID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prize", x => new { x.PrizePoolID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Prize_PrizePool_PrizePoolID",
                        column: x => x.PrizePoolID,
                        principalTable: "PrizePool",
                        principalColumn: "PrizePoolID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prize_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoolEntry",
                columns: table => new
                {
                    PrizePoolID = table.Column<int>(nullable: false),
                    SerialNumberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolEntry", x => new { x.PrizePoolID, x.SerialNumberID });
                    table.ForeignKey(
                        name: "FK_PoolEntry_PrizePool_PrizePoolID",
                        column: x => x.PrizePoolID,
                        principalTable: "PrizePool",
                        principalColumn: "PrizePoolID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoolEntry_SerialNumber_SerialNumberID",
                        column: x => x.SerialNumberID,
                        principalTable: "SerialNumber",
                        principalColumn: "SerialNumberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoolEntry_SerialNumberID",
                table: "PoolEntry",
                column: "SerialNumberID");

            migrationBuilder.CreateIndex(
                name: "IX_Prize_ProductID",
                table: "Prize",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumber_ParticipantID",
                table: "SerialNumber",
                column: "ParticipantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoolEntry");

            migrationBuilder.DropTable(
                name: "Prize");

            migrationBuilder.DropTable(
                name: "SerialNumber");

            migrationBuilder.DropTable(
                name: "PrizePool");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Participant");
        }
    }
}
