using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TrainingPlanChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_ExerciseWorkouts_ExerciseId_WorkoutId",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkoutSessions_Users_UserId",
                table: "UserWorkoutSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkoutSessions_Workouts_WorkoutId",
                table: "UserWorkoutSessions");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkoutSessions_WorkoutId",
                table: "UserWorkoutSessions");

            migrationBuilder.DropIndex(
                name: "IX_Sets_ExerciseId_WorkoutId",
                table: "Sets");

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "UserWorkoutSessions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "TrainingPlans",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_ExerciseId_WorkoutId",
                table: "Sets",
                columns: new[] { "ExerciseId", "WorkoutId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_ExerciseWorkouts_ExerciseId_WorkoutId",
                table: "Sets",
                columns: new[] { "WorkoutId", "ExerciseId" },
                principalTable: "ExerciseWorkouts",
                principalColumns: new[] { "WorkoutId", "ExerciseId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkoutSessions_UserWorkouts_UserId_WorkoutId",
                table: "UserWorkoutSessions",
                columns: new[] { "UserId", "WorkoutId" },
                principalTable: "UserWorkouts",
                principalColumns: new[] { "UserId", "WorkoutId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_ExerciseWorkouts_ExerciseId_WorkoutId",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkoutSessions_UserWorkouts_UserId_WorkoutId",
                table: "UserWorkoutSessions");

            migrationBuilder.DropIndex(
                name: "IX_Sets_ExerciseId_WorkoutId",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "UserWorkoutSessions");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "TrainingPlans");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkoutSessions_WorkoutId",
                table: "UserWorkoutSessions",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_WorkoutId_ExerciseId",
                table: "Sets",
                columns: new[] { "WorkoutId", "ExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_ExerciseWorkouts_WorkoutId_ExerciseId",
                table: "Sets",
                columns: new[] { "WorkoutId", "ExerciseId" },
                principalTable: "ExerciseWorkouts",
                principalColumns: new[] { "WorkoutId", "ExerciseId" },
                onDelete: ReferentialAction.Cascade);

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
    }
}
