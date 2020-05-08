using System.Collections.Generic;

namespace BlazorServer.Data
{
    public class TrainingProgram
    {
        public int TrainingProgramId { get; set; }
        public string TrainingProgramName { get; set; }
        public List<Training> Trainings { get; set; }

    }
}
