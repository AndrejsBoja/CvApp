using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CvStorage.Api.ViewModels;
using CvStorage.Core;
using CvStorage.Core.Services;

namespace CvStorage.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IEntityDbService _entityDbService; 

        public CustomerController(IEntityDbService entityDbService)
        {
            _entityDbService = entityDbService;
        }

        [HttpGet]
        public ActionResult CreateCv()
        {
            return View("AddPersonInfo");
        }

        [HttpPost] 
        public ActionResult AddPersonInfo(PersonInfoVm personInfoVm, AddressVm addressVm, EducationVm educationVm,
            InterestVm interestVm, SkillsVm skillsVm, WorkExperienceVm workExperienceVm)
        {
            var personInfo = new PersonInfo()
            {
                FirstName = personInfoVm.FirstName,
                LastName = personInfoVm.LastName,
                Email = personInfoVm.Email,
                PhoneNumber = personInfoVm.PhoneNumber,
                ProfileInfo = personInfoVm.ProfileInfo,
            };
            var address = new Address()
            {
                City = addressVm.City,
                Country = addressVm.Country,
                PostCode = addressVm.PostCode,
                Street = addressVm.Street,
                StreetNumber = addressVm.StreetNumber
            };
            var education = new Education()
            {
                EducationLevel = educationVm.EducationLevel,
                Faculty = educationVm.Faculty,
                Name = educationVm.Name,
                Period = educationVm.Period,
                StudyProgram = educationVm.StudyProgram
            };
            var interest = new Interest()
            {
                Hobby = interestVm.Hobby
            };
            var skill = new Skills()
            {
                Achievement = skillsVm.Achievement,
                Description = skillsVm.Description,
                Name = skillsVm.Name
            };
            var workExperience = new WorkExperience()
            {
                Name = workExperienceVm.Name,
                Position = workExperienceVm.Position,
                Schedule = workExperienceVm.Schedule,
                WorkStart = workExperienceVm.WorkStart,
                WorkFinished = workExperienceVm.WorkFinished,

            };

            var createdCv = new Cv()
            {
                PersonInfo = personInfo,
                Address = address,
                Education = education,
                Interest = interest,
                Skill = skill,
                WorkExperience = workExperience
            };

            _entityDbService.Create(createdCv);

            return RedirectToAction("GetCvList");
        }

        [Route("http://localhost:8080/"), HttpGet]
        public ActionResult GetCvList()
        {
            var cvList = _entityDbService.Get<Cv>();
            var cvVmList = cvList.Select(MapToVm).ToList();

            return View(cvVmList);
        }

        public ActionResult ViewCv(int id)
        {
            var cv = _entityDbService.GetById<Cv>(id);
            return View(MapToVm(cv));
        }
        //[Route("http://localhost:8080/Customer/UpdateCv"), HttpGet]
        //public ActionResult UpdateCv()
        //{

        //    return ViewCv();
        //}

        //[Route("http://localhost:8080/Customer/DeleteCv"), HttpGet]
        //public ActionResult DeleteCv()
        //{

        //    return ViewCv();
        //}

        private static CvVm MapToVm(Cv cv)
        {
            var cvVm = new CvVm
            {
                Id = cv.Id,
                PersonInfo =
                    new PersonInfoVm
                    {
                        FirstName = cv.PersonInfo.FirstName,
                        LastName = cv.PersonInfo.LastName,
                        Email = cv.PersonInfo.Email,
                        PhoneNumber = cv.PersonInfo.PhoneNumber,
                        ProfileInfo = cv.PersonInfo.ProfileInfo
                    },
                Address =
                    new AddressVm
                    {
                        City = cv.Address.City,
                        Country = cv.Address.Country,
                        PostCode = cv.Address.PostCode,
                        Street = cv.Address.Street,
                        StreetNumber = cv.Address.StreetNumber
                    },
                Education =
                    new EducationVm
                    {
                        EducationLevel = cv.Education.EducationLevel,
                        Faculty = cv.Education.Faculty,
                        Name = cv.Education.Name,
                        Period = cv.Education.Period,
                        StudyProgram = cv.Education.StudyProgram
                    },
                Interest = new InterestVm {Hobby = cv.Interest.Hobby},
                Skills = new SkillsVm
                {
                    Achievement = cv.Skill.Achievement, Description = cv.Skill.Description, Name = cv.Skill.Name
                },
                WorkExperience = new WorkExperienceVm
                {
                    Name = cv.WorkExperience.Name,
                    Position = cv.WorkExperience.Position,
                    Schedule = cv.WorkExperience.Schedule,
                    WorkStart = cv.WorkExperience.WorkStart,
                    WorkFinished = cv.WorkExperience.WorkFinished
                }
            };
            return cvVm;
        }
    }
}