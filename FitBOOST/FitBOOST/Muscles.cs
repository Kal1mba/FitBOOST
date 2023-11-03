using FitBOOST;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FitBOOST
{
    internal class Muscles
    {
        public string IdName { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Category MuscleCategory { get; set; }
        public enum Category
        {
            Arms,
            Legs,
            Core
        }
        
    }
}
