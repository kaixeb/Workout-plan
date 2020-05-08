using System.Collections.Generic;

namespace BlazorServer.Data
{
    public class Training
    {
        public int TrainingId { get; set; }
        public string TrainingName { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
