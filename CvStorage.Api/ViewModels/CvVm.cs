using System.Collections.Generic;
using CvStorage.Core;

namespace CvStorage.Api.ViewModels
{
    public class CvVm 
    {
        public CvVm()
        {
            EducationVmList = new List<EducationVm>();
            WorkExperienceVmList = new List<WorkExperienceVm>();
            SkillVmList = new List<SkillVm>();
            InterestVmList = new List<InterestVm>();
        }

        public int Id { get; set; }
        public PersonInfoVm PersonInfo { get; set; }
        public AddressVm Address { get; set; }
        public List<EducationVm> EducationVmList { get; set; }
        public List<WorkExperienceVm> WorkExperienceVmList { get; set; }
        public List<SkillVm> SkillVmList { get; set; }
        public List<InterestVm> InterestVmList { get; set; }

    }
}