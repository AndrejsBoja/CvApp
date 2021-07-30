using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CvStorage.Api.ViewModels;
using CvStorage.Core;
using CvStorage.Services;

namespace CvStorage.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICvService _cvService;

        public CustomerController(ICvService cvService)
        {
            _cvService = cvService;
        }

        [HttpGet]
        public ActionResult CreateCv()
        {
            var model = new CvVm();
            return View("AddPersonInfo", model);
        }

        [HttpPost] 
        public ActionResult AddPersonInfo(CvVm cvVm)
        {
            //if (!ModelState.IsValid)  // Nevaru create cv, kaut vai validacijas nekur nav.. 
            //    return View(cvVm);

            var personInfo = new PersonInfo()
            {
                Id = cvVm.PersonInfo.Id,
                FirstName = cvVm.PersonInfo.FirstName,
                LastName = cvVm.PersonInfo.LastName,
                Email = cvVm.PersonInfo.Email,
                PhoneNumber = cvVm.PersonInfo.PhoneNumber,
                ProfileInfo = cvVm.PersonInfo.ProfileInfo
            };
            var address = new Address()
            {
                Id = cvVm.Address.Id,
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
                    CvId = cvVm.Id, 
                    Id = education.Id,
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
                    CvId = cvVm.Id,
                    Id = interest.Id, 
                    Hobby = interest.Hobby
                };
                interestList.Add(newInterest);
            });
            var skillList = new List<Skill>();
            cvVm.SkillVmList.ForEach(skill =>
            {
                var newSkill = new Skill()
                {
                    CvId = cvVm.Id,
                    Id = skill.Id,
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
                    CvId = cvVm.Id,
                    Id = workExperience.Id,
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
                Id = cvVm.Id,
                PersonInfo = personInfo,
                Address = address,
                EducationList = educationList,
                InterestList = interestList,
                SkillList = skillList,
                WorkExperienceList = workExperienceList
            };

            if (cvVm.Id == 0)
            {
                _cvService.Create(createdCv);
            }
            else
            {
                _cvService.UpdateCv(createdCv); 
            }

            return RedirectToAction("GetCvList");
        }

        [HttpGet]
        public ActionResult GetCvList()
        {
            var cvList = _cvService.Get<Cv>();
            var cvVmList = cvList.Select(MapToVm).ToList();

            return View(cvVmList);
        }

        [HttpGet]
        public ActionResult EditCv(int id)
        {
            var cv = _cvService.GetById<Cv>(id);
            var model = MapToVm(cv);
            return View("AddPersonInfo", model);
        }

        public ActionResult ViewCv(int id) // bez atributa strada 
        {
            var cv = _cvService.GetById<Cv>(id);
            return View(MapToVm(cv));
        }

        //[HttpGet]
        //public ActionResult UpdateCvById(int id)
        //{
        //    var cv = _cvService.GetById<Cv>(id);
        //    var model = MapToVm(cv);
        //    return View("AddPersonInfo", model);
        //}

        [Route("http://localhost:8080/Customer/DeleteCv"), HttpGet]
        public ActionResult DeleteCvById(int id)
        {
            _cvService.Delete<Cv>(id);
            return RedirectToAction("GetCvList");
        }

        private static CvVm MapToVm(Cv cv)
        {
            var personInfoVm = new PersonInfoVm()
            {
                Id = cv.PersonInfo.Id,
                Email = cv.PersonInfo.Email,
                FirstName = cv.PersonInfo.FirstName,
                LastName = cv.PersonInfo.LastName,
                PhoneNumber = cv.PersonInfo.PhoneNumber,
                ProfileInfo = cv.PersonInfo.ProfileInfo
            };
            var addressVm = new AddressVm()
            {
                Id = cv.Address.Id,
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
                    Id = education.Id,
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
                    Id = interest.Id,
                    Hobby = interest.Hobby
                };
                interestVmList.Add(newInterestVm);
            });
            var skillVmList = new List<SkillVm>();
            cv.SkillList.ForEach(skill =>
            {
                var newSkillVm = new SkillVm()
                {
                    Id = skill.Id,
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
                    Id = workExperience.Id,
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

            return cvVm;
        }
    }
}