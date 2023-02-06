using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SettingsNGoals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaloriesIntakeGoal",
                table: "Measurements",
                type: "integer",
                maxLength: 250,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "WeightGoal",
                table: "Measurements",
                type: "double precision",
                maxLength: 200,
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloriesIntakeGoal",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "WeightGoal",
                table: "Measurements");
        }
    }
}
