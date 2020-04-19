using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    EVENT_TYPE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EVENT_TYPE_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.EVENT_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    USER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_NAME = table.Column<string>(nullable: true),
                    USER_SURNAME = table.Column<string>(nullable: true),
                    USER_NICK = table.Column<string>(nullable: true),
                    USER_EMAIL = table.Column<string>(nullable: true),
                    USER_PASSWORD = table.Column<byte[]>(nullable: true),
                    USER_PASSWORD_SALT = table.Column<byte[]>(nullable: true),
                    USER_BIRTH = table.Column<DateTime>(nullable: false),
                    USER_CITY = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EVENT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EVENT_NAME = table.Column<string>(nullable: true),
                    EVENT_LOCATION = table.Column<string>(nullable: true),
                    EVENT_DESC = table.Column<string>(nullable: true),
                    EVENT_TYPE_ID = table.Column<int>(nullable: false),
                    EVENT_CREATION = table.Column<DateTime>(nullable: false),
                    ECENT_DATE = table.Column<DateTime>(nullable: false),
                    EVENT_USER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EVENT_ID);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EVENT_TYPE_ID",
                        column: x => x.EVENT_TYPE_ID,
                        principalTable: "EventTypes",
                        principalColumn: "EVENT_TYPE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_User_EVENT_USER_ID",
                        column: x => x.EVENT_USER_ID,
                        principalTable: "User",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    RECEIPT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECEIPT_USER_ID = table.Column<int>(nullable: false),
                    RECEIPT_EVENT_ID = table.Column<int>(nullable: false)
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
                        principalColumn: "USER_ID"
                        );
                });

            migrationBuilder.CreateTable(
                name: "ReceiptItems",
                columns: table => new
                {
                    RECEIPT_PROD_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECEIPT_PROD_NAME = table.Column<string>(nullable: true),
                    RECEIPT_PROD_AMOUNT = table.Column<int>(nullable: false),
                    RECEIPT_PROD_PRICE = table.Column<double>(nullable: false),
                    RECEIPT_PROD_REC_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptItems", x => x.RECEIPT_PROD_ID);
                    table.ForeignKey(
                        name: "FK_ReceiptItems_Receipts_RECEIPT_PROD_REC_ID",
                        column: x => x.RECEIPT_PROD_REC_ID,
                        principalTable: "Receipts",
                        principalColumn: "RECEIPT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EVENT_TYPE_ID",
                table: "Events",
                column: "EVENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EVENT_USER_ID",
                table: "Events",
                column: "EVENT_USER_ID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiptItems");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
