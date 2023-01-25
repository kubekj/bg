using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserFKChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_Id",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Users_Id",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_Id",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sets_ExerciseWorkouts_ExerciseId_WorkoutId",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_Users_Id",
                table: "TrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_Sets_ExerciseId_WorkoutId",
                table: "Sets");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_AuthorId",
                table: "TrainingPlans",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_WorkoutId_ExerciseId",
                table: "Sets",
                columns: new[] { "WorkoutId", "ExerciseId" });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_UserId",
                table: "Measurements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserId",
                table: "Goals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Users_UserId",
                table: "Measurements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_ExerciseWorkouts_WorkoutId_ExerciseId",
                table: "Sets",
                columns: new[] { "WorkoutId", "ExerciseId" },
                principalTable: "ExerciseWorkouts",
                principalColumns: new[] { "WorkoutId", "ExerciseId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Users_AuthorId",
                table: "TrainingPlans",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Users_UserId",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sets_ExerciseWorkouts_WorkoutId_ExerciseId",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPlans_Users_AuthorId",
                table: "TrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_TrainingPlans_AuthorId",
                table: "TrainingPlans");

            migrationBuilder.DropIndex(
                name: "IX_Sets_WorkoutId_ExerciseId",
                table: "Sets");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_UserId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Goals_UserId",
                table: "Goals");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_ExerciseId_WorkoutId",
                table: "Sets",
                columns: new[] { "ExerciseId", "WorkoutId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_Id",
                table: "Goals",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Users_Id",
                table: "Measurements",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_Id",
                table: "Ratings",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_ExerciseWorkouts_ExerciseId_WorkoutId",
                table: "Sets",
                columns: new[] { "ExerciseId", "WorkoutId" },
                principalTable: "ExerciseWorkouts",
                principalColumns: new[] { "WorkoutId", "ExerciseId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPlans_Users_Id",
                table: "TrainingPlans",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
