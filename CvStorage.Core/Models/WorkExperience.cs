using System;

namespace CvStorage.Core
{
    public class WorkExperience : Entity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Schedule { get; set; }
        public string WorkStart { get; set; }
        public string WorkFinished { get; set; }
    }   
}