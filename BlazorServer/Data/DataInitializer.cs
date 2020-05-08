using Bogus;
using System;
using System.Linq;

namespace BlazorServer.Data
{
    public static class DataInitializer
    {
        public static void Initialize(TrainingProgramContext db)
        {
            Randomizer.Seed = new Random(650931);

            if (db.TrainingPrograms.Count() == 0)
            {
                //Create random exercises
                var exerciseNames = new[] { "Squat", "Push-up", "Press-up", "Pull-up", "Leg press", "Lunge", "Deadlift", "Leg curl", "Chest fly", "Pull-down", "Bent-over row", "Upright row", "Shoulder press", "Shoulder fly", "Pushdown", "Triceps extension", "Biceps curl", "Crunch", "Back extension", "Side plank", "Dumbbell row", "Single-leg deadlift", "Burpee", "Situp", "Glute bridge" };
                var exercises = new Faker<Exercise>()
                    .RuleFor(ex => ex.ExerciseName, f => f.PickRandom(exerciseNames))
                    .RuleFor(ex => ex.NumberOfSets, f => f.Random.Int(1, 10))
                    .RuleFor(ex => ex.NumberOfRepeats, f => f.Random.Int(6, 25))
                    .RuleFor(ex => ex.Weight, f => Math.Round(f.Random.Double(0, 100), 1).ToString() + " kg");

                //Create random trainings with those exercises
                var trainingNames = new[] { "Legs", "Arms", "Back", "Ass", "Fingers", "Neck", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", "Home training", "Gym training", "Abs", "Thighs", "Chest and triceps", "Chest", "Glutes", "Abs and back", "Shoulders", "Chest, shoulders and arms" };
                var trainings = new Faker<Training>()
                    .RuleFor(tr => tr.TrainingName, f => f.PickRandom(trainingNames))
                    .RuleFor(tr => tr.Exercises, f => exercises.Generate(f.Random.Int(1, 6)).ToList());

                //Create random training programs for those trainings
                var tpNames = new[] { "My training program", "Crossfit", "Yoga", "Bodybuilding 30 days", "Casual workout", "Fast 6 pack abs", "Lazy workout", "Full body upgrade", "Road to perfect body", "Instragram model body in 3 months", "Thick ass workout", "Bodyweight workout", "Workout by Bob" };
                var testTrainingPrograms = new Faker<TrainingProgram>()
                    .RuleFor(tp => tp.TrainingProgramName, f => f.PickRandom(tpNames))
                    .RuleFor(tp => tp.Trainings, f => trainings.Generate(f.Random.Int(1, 7)).ToList());
                var trainingPrograms = testTrainingPrograms.Generate(20);

                foreach (TrainingProgram tp in trainingPrograms)
                {
                    db.TrainingPrograms.Add(tp);
                }
                db.SaveChanges();
            }
        }

    }
}
