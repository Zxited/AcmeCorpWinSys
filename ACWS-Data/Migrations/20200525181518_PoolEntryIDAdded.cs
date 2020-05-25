using Microsoft.EntityFrameworkCore.Migrations;

namespace ACWS_Data.Migrations
{
    public partial class PoolEntryIDAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialNumber_Participant_ParticipantID",
                table: "SerialNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoolEntry",
                table: "PoolEntry");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipantID",
                table: "SerialNumber",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PoolEntryID",
                table: "PoolEntry",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoolEntry",
                table: "PoolEntry",
                column: "PoolEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_PoolEntry_PrizePoolID",
                table: "PoolEntry",
                column: "PrizePoolID");

            migrationBuilder.AddForeignKey(
                name: "FK_SerialNumber_Participant_ParticipantID",
                table: "SerialNumber",
                column: "ParticipantID",
                principalTable: "Participant",
                principalColumn: "ParticipantID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialNumber_Participant_ParticipantID",
                table: "SerialNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoolEntry",
                table: "PoolEntry");

            migrationBuilder.DropIndex(
                name: "IX_PoolEntry_PrizePoolID",
                table: "PoolEntry");

            migrationBuilder.DropColumn(
                name: "PoolEntryID",
                table: "PoolEntry");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipantID",
                table: "SerialNumber",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoolEntry",
                table: "PoolEntry",
                columns: new[] { "PrizePoolID", "SerialNumberID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SerialNumber_Participant_ParticipantID",
                table: "SerialNumber",
                column: "ParticipantID",
                principalTable: "Participant",
                principalColumn: "ParticipantID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
