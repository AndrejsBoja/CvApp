using System.Collections.Generic;

namespace CvStorage.Core
{
    public class Cv : Entity 
    {
        public Cv()
        {
            EducationList = new List<Education>();
            WorkExperienceList = new List<WorkExperience>();
            SkillList = new List<Skill>();
            InterestList = new List<Interest>();
        }

        public virtual PersonInfo PersonInfo { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Education> EducationList { get; set; }
        public virtual List<WorkExperience> WorkExperienceList { get; set; }
        public virtual List<Skill> SkillList { get; set; } 
        public virtual List<Interest> InterestList { get; set; }
    }
}