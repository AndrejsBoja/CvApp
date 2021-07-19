using CvStorage.Core;

namespace CvStorage.Api.ViewModels
{
    public class CvVm 
    {
        public int Id { get; set; }
        public PersonInfoVm PersonInfo { get; set; }
        public AddressVm Address { get; set; }
        public EducationVm Education { get; set; }
        public InterestVm Interest { get; set; }
        public SkillsVm Skills { get; set; }
        public WorkExperienceVm WorkExperience { get; set; }
    }
}