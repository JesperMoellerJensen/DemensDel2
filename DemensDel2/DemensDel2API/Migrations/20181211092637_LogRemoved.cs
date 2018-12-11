using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemensDel2API.Migrations
{
    public partial class LogRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSessions_Logs_LogId",
                table: "TrainingSessions");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.RenameColumn(
                name: "LogId",
                table: "TrainingSessions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingSessions_LogId",
                table: "TrainingSessions",
                newName: "IX_TrainingSessions_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSessions_Users_UserId",
                table: "TrainingSessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSessions_Users_UserId",
                table: "TrainingSessions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TrainingSessions",
                newName: "LogId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingSessions_UserId",
                table: "TrainingSessions",
                newName: "IX_TrainingSessions_LogId");

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSessions_Logs_LogId",
                table: "TrainingSessions",
                column: "LogId",
                principalTable: "Logs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
