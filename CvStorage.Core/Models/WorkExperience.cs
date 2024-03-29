﻿namespace CvStorage.Core
{
    public class WorkExperience : Entity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Schedule { get; set; }
        public string WorkStart { get; set; }
        public string WorkFinished { get; set; }
        public int CvId { get; set; }
        public virtual Cv Cv { get; set; }
    }
}