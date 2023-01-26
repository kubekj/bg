using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserWorkoutSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "UserWorkouts");

            migrationBuilder.CreateTable(
                name: "UserWorkoutSession",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserWorkoutSessionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkoutSession", x => new { x.UserId, x.WorkoutId, x.Date });
                    table.ForeignKey(
                        name: "FK_UserWorkoutSession_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWorkoutSession_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkoutSession_WorkoutId",
                table: "UserWorkoutSession",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWorkoutSession");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "UserWorkouts",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}
