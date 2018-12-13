using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemensDel2API.Migrations
{
    public partial class Jesper1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Users",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TrainingSessions",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ExerciseTypes",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Exercises",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ExerciseTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Exercises");
        }
    }
}
