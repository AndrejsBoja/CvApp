namespace CvStorage.Core
{
    public class Cv : Entity
    {
        public virtual PersonInfo PersonInfo { get; set; }
        public virtual Address Address { get; set; }
        public virtual Education Education { get; set; }
        public virtual WorkExperience WorkExperience { get; set; }
        public virtual Skills Skill { get; set; } // change class name to skill
        public virtual Interest Interest { get; set; } // lazy loading pie pievienosanas validacijas jauztaisa
    }
}