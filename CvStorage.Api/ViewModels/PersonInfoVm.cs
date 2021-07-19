using System.ComponentModel.DataAnnotations;

namespace CvStorage.Api.ViewModels
{
    public class PersonInfoVm 
    {  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.MultilineText)]
        public string ProfileInfo { get; set; }
    }
}