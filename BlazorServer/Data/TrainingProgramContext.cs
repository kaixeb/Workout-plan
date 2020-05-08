using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data
{
    public class TrainingProgramContext : DbContext
    {
        public TrainingProgramContext()
        {

        }

        public TrainingProgramContext(DbContextOptions<TrainingProgramContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource=trainingPrograms.db");
        }

        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
