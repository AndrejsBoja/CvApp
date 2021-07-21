using System.Collections.Generic;
using System.Dynamic;

namespace CvStorage.Core
{
    public class Cv : Entity // sealed pieliku
    {
        public Cv()
        {
            EducationList = new List<Education>();
            WorkExperienceList = new List<WorkExperience>();
            SkillList = new List<Skill>();
            InterestList = new List<Interest>();
        }

        public PersonInfo PersonInfo { get; set; }
        public Address Address { get; set; }
        public List<Education> EducationList { get; set; }
        public List<WorkExperience> WorkExperienceList { get; set; }
        public List<Skill> SkillList { get; set; } 
        public List<Interest> InterestList { get; set; }
    }
}