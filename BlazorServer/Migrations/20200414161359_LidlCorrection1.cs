using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorServer.Migrations
{
    public partial class LidlCorrection1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainingName",
                table: "Trainings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingProgramName",
                table: "TrainingPrograms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseName",
                table: "Exercises",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingName",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainingProgramName",
                table: "TrainingPrograms");

            migrationBuilder.DropColumn(
                name: "ExerciseName",
                table: "Exercises");
        }
    }
}
