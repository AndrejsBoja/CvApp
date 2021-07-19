namespace CvStorage.Api.ViewModels
{
    public class EducationVm 
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string StudyProgram { get; set; }
        public string EducationLevel { get; set; }
        public int Period { get; set; }
        public enum EducationStatus
        {
            Studying = 1,
            Break = 2,
            Unfinished = 3,
            Finished = 4
        }
    }
}