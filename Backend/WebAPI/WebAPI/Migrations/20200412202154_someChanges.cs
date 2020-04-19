using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class someChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptItems_Receipts_RECEIPT_PROD_REC_ID",
                table: "ReceiptItems");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptItems_RECEIPT_PROD_REC_ID",
                table: "ReceiptItems");

            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "ReceiptItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    PARTICIPANT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARTICIPANT_USER_ID = table.Column<int>(nullable: false),
                    PARTICIPANT_EVENT_ID = table.Column<int>(nullable: false),
                    PARTICIPANT_IS_ADMIN = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.PARTICIPANT_ID);
                    table.ForeignKey(
                        name: "FK_Participants_Events_PARTICIPANT_EVENT_ID",
                        column: x => x.PARTICIPANT_EVENT_ID,
                        principalTable: "Events",
                        principalColumn: "EVENT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_User_PARTICIPANT_USER_ID",
                        column: x => x.PARTICIPANT_USER_ID,
                        principalTable: "User",
                        principalColumn: "USER_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItems_ParticipantId",
                table: "ReceiptItems",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PARTICIPANT_EVENT_ID",
                table: "Participants",
                column: "PARTICIPANT_EVENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PARTICIPANT_USER_ID",
                table: "Participants",
                column: "PARTICIPANT_USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptItems_Participants_ParticipantId",
                table: "ReceiptItems",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "PARTICIPANT_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptItems_Participants_ParticipantId",
                table: "ReceiptItems");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptItems_ParticipantId",
                table: "ReceiptItems");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "ReceiptItems");

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    RECEIPT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECEIPT_EVENT_ID = table.Column<int>(type: "int", nullable: false),
                    RECEIPT_USER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.RECEIPT_ID);
                    table.ForeignKey(
                        name: "FK_Receipts_Events_RECEIPT_EVENT_ID",
                        column: x => x.RECEIPT_EVENT_ID,
                        principalTable: "Events",
                        principalColumn: "EVENT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receipts_User_RECEIPT_USER_ID",
                        column: x => x.RECEIPT_USER_ID,
                        principalTable: "User",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItems_RECEIPT_PROD_REC_ID",
                table: "ReceiptItems",
                column: "RECEIPT_PROD_REC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_RECEIPT_EVENT_ID",
                table: "Receipts",
                column: "RECEIPT_EVENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_RECEIPT_USER_ID",
                table: "Receipts",
                column: "RECEIPT_USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptItems_Receipts_RECEIPT_PROD_REC_ID",
                table: "ReceiptItems",
                column: "RECEIPT_PROD_REC_ID",
                principalTable: "Receipts",
                principalColumn: "RECEIPT_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
