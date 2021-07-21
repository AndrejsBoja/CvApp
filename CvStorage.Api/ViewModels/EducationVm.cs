using System.ComponentModel.DataAnnotations;

namespace CvStorage.Api.ViewModels
{
    public class EducationVm 
    {
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Faculty")]
        public string Faculty { get; set; }
        public string StudyProgram { get; set; }
        public string EducationLevel { get; set; }
        public int Period { get; set; }
        public string EducationStatus { get; set; }
    }
}