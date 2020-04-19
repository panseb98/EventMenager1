using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class addInvitation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    INVI_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INVI_EVENT_ID = table.Column<int>(nullable: false),
                    INVI_SENDER_ID = table.Column<int>(nullable: false),
                    INVI_RECIP_ID = table.Column<int>(nullable: false),
                    INVI_IS_NEW = table.Column<bool>(nullable: false),
                    INVI_IS_ACCEPTED = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.INVI_ID);
                    table.ForeignKey(
                        name: "FK_Invitations_Events_INVI_EVENT_ID",
                        column: x => x.INVI_EVENT_ID,
                        principalTable: "Events",
                        principalColumn: "EVENT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invitations_User_INVI_RECIP_ID",
                        column: x => x.INVI_RECIP_ID,
                        principalTable: "User",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_Invitations_User_INVI_SENDER_ID",
                        column: x => x.INVI_SENDER_ID,
                        principalTable: "User",
                        principalColumn: "USER_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_INVI_EVENT_ID",
                table: "Invitations",
                column: "INVI_EVENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_INVI_RECIP_ID",
                table: "Invitations",
                column: "INVI_RECIP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_INVI_SENDER_ID",
                table: "Invitations",
                column: "INVI_SENDER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitations");
        }
    }
}
