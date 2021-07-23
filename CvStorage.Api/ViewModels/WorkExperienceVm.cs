using System.Collections.Generic;

namespace CvStorage.Api.ViewModels
{
    public class WorkExperienceVm 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Schedule { get; set; }
        public string WorkStart { get; set; }
        public string WorkFinished { get; set; }
    }
}