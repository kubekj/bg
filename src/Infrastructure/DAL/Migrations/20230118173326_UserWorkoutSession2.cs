using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserWorkoutSession2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkoutSession_Users_UserId",
                table: "UserWorkoutSession");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkoutSession_Workouts_WorkoutId",
                table: "UserWorkoutSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWorkoutSession",
                table: "UserWorkoutSession");

            migrationBuilder.DropColumn(
                name: "UserWorkoutSessionId",
                table: "UserWorkoutSession");

            migrationBuilder.RenameTable(
                name: "UserWorkoutSession",
                newName: "UserWorkoutSessions");

            migrationBuilder.RenameIndex(
                name: "IX_UserWorkoutSession_WorkoutId",
                table: "UserWorkoutSessions",
                newName: "IX_UserWorkoutSessions_WorkoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWorkoutSessions",
                table: "UserWorkoutSessions",
                columns: new[] { "UserId", "WorkoutId", "Date" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkoutSessions_Users_UserId",
                table: "UserWorkoutSessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkoutSessions_Workouts_WorkoutId",
                table: "UserWorkoutSessions",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkoutSessions_Users_UserId",
                table: "UserWorkoutSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkoutSessions_Workouts_WorkoutId",
                table: "UserWorkoutSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWorkoutSessions",
                table: "UserWorkoutSessions");

            migrationBuilder.RenameTable(
                name: "UserWorkoutSessions",
                newName: "UserWorkoutSession");

            migrationBuilder.RenameIndex(
                name: "IX_UserWorkoutSessions_WorkoutId",
                table: "UserWorkoutSession",
                newName: "IX_UserWorkoutSession_WorkoutId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserWorkoutSessionId",
                table: "UserWorkoutSession",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWorkoutSession",
                table: "UserWorkoutSession",
                columns: new[] { "UserId", "WorkoutId", "Date" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkoutSession_Users_UserId",
                table: "UserWorkoutSession",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkoutSession_Workouts_WorkoutId",
                table: "UserWorkoutSession",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
