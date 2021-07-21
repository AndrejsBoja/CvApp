namespace CvStorage.Core
{
    public class Education : Entity
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string StudyProgram { get; set; }
        public string EducationLevel { get; set; }
        public int Period { get; set; }
        public string EducationStatus { get; set; }
        public int CvId { get; set; }
        public virtual Cv Cv { get; set; }
    }
}