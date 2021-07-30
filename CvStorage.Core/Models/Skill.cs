namespace CvStorage.Core
{
    public class Skill : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Achievement { get; set; }
        public int CvId { get; set; }
        public virtual Cv Cv { get; set; } // var atri atlasit CV
    }
}