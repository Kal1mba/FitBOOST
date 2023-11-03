using System;
using System.Collections.Generic;
using System.Text;

namespace FitBOOST
{
    internal class DetailedInstructionsModel
    {
        public int Id { get; set; }
        public List<VideoInstructionsSource> VideoInstructions { get; set; }
        public string ExerciseName { get; set; }
        public string Difficulty { get; set; }
        public string MuscleType { get; set; }
        public string TrainersType { get; set; }
        public string Instructions { get; set; }
        
        
    }
}
