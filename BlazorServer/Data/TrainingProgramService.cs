using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.Data
{
    public class TrainingProgramService
    {
        private readonly TrainingProgramContext _context;

        public TrainingProgramService(TrainingProgramContext context)
        {
            _context = context;
        }

        public async Task<List<TrainingProgram>> GetTrainingProgramsAsync()
        {
            List<TrainingProgram> trainingPrograms;
            return trainingPrograms = await _context.TrainingPrograms.Include(tp => tp.Trainings).ThenInclude(t => t.Exercises).ToListAsync();
        }

        public async ValueTask<TrainingProgram> GetTrainingProgramByIdAsync(int tpId)
        {
            TrainingProgram trainingProgram = await _context.TrainingPrograms.Include(trp => trp.Trainings)
                                                             .ThenInclude(t => t.Exercises)
                                                             .SingleAsync(tp => tp.TrainingProgramId == tpId);
            return trainingProgram;
        }

        public void CreateTrainingProgram(TrainingProgram tp)
        {
            _context.Add(tp);
            SaveTrainingProgramChanges();
        }

        public void DeleteProgram(TrainingProgram tp)
        {
            _context.Remove(tp);
            SaveTrainingProgramChanges();
        }

        public void SaveTrainingProgramChanges()
        {
            _context.SaveChanges();
        }
        
    }
}



//public async Task UpdateTrainingProgramAsync(int tpId, TrainingProgram newTp)
//{
//TrainingProgram oldTp = await GetTrainingProgramByIdAsync(tpId);
//_context.Entry(oldTp).CurrentValues.SetValues(newTp); //set new property values in old training program, complex types are not updated by this
//_context.Entry(oldTp).Entity.Trainings = newTp.Trainings; //check this

//foreach (var oldTr in oldTp.Trainings)
//{
//    if (!newTp.Trainings.Any(tp => tp.TrainingId == oldTr.TrainingId)) //checking if any complex type item has been deleted, if so, remove it from db
//    {
//        _context.Trainings.Remove(oldTr);
//    }
//    else
//    {
//        //check his exercises
//        Training newTr = newTp.Trainings.Find(tr => tr.TrainingId == oldTr.TrainingId);
//        foreach (var oldEx in oldTr.Exercises)
//        {
//            if (!newTr.Exercises.Any(ex => ex.ExerciseId == oldEx.ExerciseId))
//            {
//                _context.Trainings.Find(oldTr.TrainingId).Exercises.Remove(oldEx);
//            }
//        }
//    }
//}

//Update or insert complex items that are not contained in oldTp but are in newTp
//foreach (var newTr in newTp.Trainings)
//{
//    var changedTr = oldTp.Trainings.Where(tr => tr.TrainingId == newTr.TrainingId).SingleOrDefault();
//    if (changedTr != null) //if item has been changed but not deleted
//    {
//        _context.Entry(changedTr).CurrentValues.SetValues(newTr);
//        _context.Entry(changedTr).Entity.Exercises = newTr.Exercises;                    
//    }
//    else //if item is not contained in oldTp but is in newTp
//    {
//        var training = new Training
//        {
//            TrainingId = newTr.TrainingId,
//            TrainingName = newTr.TrainingName,
//            Exercises = newTr.Exercises
//        };
//        _context.Trainings.Add(training);
//        //_context.Exercises.AddRange(newTr.Exercises);
//        //oldTp.Trainings.Add(training);
//    }
//}
//    _context.SaveChanges();
//}