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
            var model = new CvVm();
            model.EducationVmList.Add(new EducationVm{EducationLevel = string.Empty, EducationStatus = string.Empty, Faculty = string.Empty, Name = string.Empty, Period = 0, StudyProgram = string.Empty});
            return View("AddPersonInfo", model);
        }

        [HttpPost] 
        public ActionResult AddPersonInfo(CvVm cvVm)
        {
            if (!ModelState.IsValid)
                return View(cvVm);
            var personInfo = new PersonInfo()
            {
                FirstName = cvVm.PersonInfo.FirstName,
                LastName = cvVm.PersonInfo.LastName,
                Email = cvVm.PersonInfo.Email,
                PhoneNumber = cvVm.PersonInfo.PhoneNumber,
                ProfileInfo = cvVm.PersonInfo.ProfileInfo,
            };
            var address = new Address()
            {
                City = cvVm.Address.City,
                Country = cvVm.Address.Country,
                PostCode = cvVm.Address.PostCode,
                Street = cvVm.Address.Street,
                StreetNumber = cvVm.Address.StreetNumber
            };
            var educationList = new List<Education>();
            cvVm.EducationVmList.ForEach(education =>
            {
                var newEducation = new Education()
                {
                    EducationLevel = education.EducationLevel,
                    Faculty = education.Faculty,
                    Name = education.Name,
                    Period = education.Period,
                    StudyProgram = education.StudyProgram,
                    EducationStatus = education.EducationStatus
                };

                educationList.Add(newEducation);
            });
            var interestList = new List<Interest>();
            cvVm.InterestVmList.ForEach(interest =>
            {
                var newInterest = new Interest()
                {
                    Hobby = interest.Hobby
                };
                interestList.Add(newInterest);
            });
            var skillList = new List<Skill>();
            cvVm.SkillVmList.ForEach(skill =>
            {
                var newSkill = new Skill()
                {
                    Achievement = skill.Achievement,
                    Description = skill.Description,
                    Name = skill.Name
                };
                skillList.Add(newSkill);
            });
            var workExperienceList = new List<WorkExperience>();
            cvVm.WorkExperienceVmList.ForEach(workExperience =>
            {
                var newWorkExperience = new WorkExperience()
                {
                    Name = workExperience.Name,
                    Position = workExperience.Position,
                    Schedule = workExperience.Schedule,
                    WorkStart = workExperience.WorkStart,
                    WorkFinished = workExperience.WorkFinished,
                };
                workExperienceList.Add(newWorkExperience);
            });
         
            var createdCv = new Cv()
            {
                PersonInfo = personInfo,
                Address = address,
                EducationList = educationList,
                InterestList = interestList,
                SkillList = skillList,
                WorkExperienceList = workExperienceList
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

        [Route("http://localhost:8080/Customer/DeleteCv"), HttpGet]
        public ActionResult DeleteCvById(int id)
        {
            _entityDbService.Delete<Cv>(id);
            return RedirectToAction("GetCvList");
        }

        private static CvVm MapToVm(Cv cv)
        {
            var personInfoVm = new PersonInfoVm()
            {
                Email = cv.PersonInfo.Email,
                FirstName = cv.PersonInfo.FirstName,
                LastName = cv.PersonInfo.LastName,
                PhoneNumber = cv.PersonInfo.PhoneNumber,
                ProfileInfo = cv.PersonInfo.ProfileInfo
            };
            var addressVm = new AddressVm()
            {
                City = cv.Address.City,
                Country = cv.Address.Country,
                PostCode = cv.Address.PostCode,
                Street = cv.Address.Street,
                StreetNumber = cv.Address.StreetNumber
            };
            var educationVmList = new List<EducationVm>();
            cv.EducationList.ForEach(education =>
            {
                var newEducationVm = new EducationVm()
                {
                    EducationLevel = education.EducationLevel,
                    Faculty = education.Faculty,
                    Name = education.Name,
                    Period = education.Period,
                    StudyProgram = education.StudyProgram,
                    EducationStatus = education.EducationStatus
                };

                educationVmList.Add(newEducationVm);
            });
            var interestVmList = new List<InterestVm>();
            cv.InterestList.ForEach(interest =>
            {
                var newInterestVm = new InterestVm()
                {
                    Hobby = interest.Hobby
                };
                interestVmList.Add(newInterestVm);
            });
            var skillVmList = new List<SkillVm>();
            cv.SkillList.ForEach(skill =>
            {
                var newSkillVm = new SkillVm()
                {
                    Achievement = skill.Achievement,
                    Description = skill.Description,
                    Name = skill.Name
                };
                skillVmList.Add(newSkillVm);
            });
            var workExperienceVmList = new List<WorkExperienceVm>();
            cv.WorkExperienceList.ForEach(workExperience =>
            {
                var newWorkExperienceVm = new WorkExperienceVm()
                {
                    Name = workExperience.Name,
                    Position = workExperience.Position,
                    Schedule = workExperience.Schedule,
                    WorkStart = workExperience.WorkStart,
                    WorkFinished = workExperience.WorkFinished
                };
                workExperienceVmList.Add(newWorkExperienceVm);
            });

            var cvVm = new CvVm()
            {
                Id = cv.Id,
                Address = addressVm,
                PersonInfo = personInfoVm,
                EducationVmList = educationVmList,
                InterestVmList = interestVmList,
                SkillVmList = skillVmList,
                WorkExperienceVmList = workExperienceVmList
            };

            //var cvVm = new CvVm
            //{
            //    Id = cv.Id,
            //    PersonInfo =
            //        new PersonInfoVm
            //        {
            //            FirstName = cv.PersonInfo.FirstName,
            //            LastName = cv.PersonInfo.LastName,
            //            Email = cv.PersonInfo.Email,
            //            PhoneNumber = cv.PersonInfo.PhoneNumber,
            //            ProfileInfo = cv.PersonInfo.ProfileInfo
            //        },
            //    Address =
            //        new AddressVm
            //        {
            //            City = cv.Address.City,
            //            Country = cv.Address.Country,
            //            PostCode = cv.Address.PostCode,
            //            Street = cv.Address.Street,
            //            StreetNumber = cv.Address.StreetNumber
            //        }
            //    ,
            //    EducationVmList = { 
                    //new EducationVm()
            //{
            //    EducationStatus = cv.EducationList.ForEach(education => education.EducationStatus == ed),
            //    EducationLevel = ,
            //    Faculty = ,
            //    Name = ,
            //    Period = ,
            //    StudyProgram = 
            //}

            //},
            //Interest = new InterestVm {Hobby = cv.Interest.Hobby},
            //Skill = new SkillVm
            //{
            //    Achievement = cv.Skill.Achievement, Description = cv.Skill.Description, Name = cv.Skill.Name
            //},
            //WorkExperience = new WorkExperienceVm
            //{
            //    Name = cv.WorkExperience.Name,
            //    Position = cv.WorkExperience.Position,
            //    Schedule = cv.WorkExperience.Schedule,
            //    WorkStart = cv.WorkExperience.WorkStart,
            //    WorkFinished = cv.WorkExperience.WorkFinished
            //}
        //};
            return cvVm;
        }
    }
}