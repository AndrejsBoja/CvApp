using System.Data.Entity;
using System.Linq;
using CvStorage.Core;
using CvStorage.Data;

namespace CvStorage.Services
{
    public class CvService : EntityDbService, ICvService
    {
        public CvService(CvStorageDbContext context) : base(context)
        {
        }

        public void UpdateCv(Cv cv)
        {
            EntityContext.Entry(cv.PersonInfo).State = EntityState.Modified;
            EntityContext.Entry(cv.Address).State = EntityState.Modified;

            var educationList = EntityContext.Educations.Where(e => e.CvId == cv.Id).ToList();
            if (educationList.Count != 0)
            {
                EntityContext.Educations.RemoveRange(educationList);
            }

            foreach (var education in cv.EducationList)
            {
                if (education.Name != null && education.EducationStatus != null)
                {
                    EntityContext.Educations.Add(education);
                }
            }

            var workExperienceList = EntityContext.WorkExperiences.Where(w => w.CvId == cv.Id).ToList();
            if (workExperienceList.Count != 0)
            {
                EntityContext.WorkExperiences.RemoveRange(workExperienceList);
            }

            foreach (var work in cv.WorkExperienceList)
            {
                if (work.Name != null && work.Position != null && work.WorkStart != null && work.WorkFinished != null)
                {
                    EntityContext.WorkExperiences.Add(work);
                }
            }

            var skillList = EntityContext.Skills.Where(s => s.CvId == cv.Id).ToList();
            if (skillList.Count != 0)
            {
                EntityContext.Skills.RemoveRange(skillList);
            }

            foreach (var skill in cv.SkillList)
            {
                if (skill.Name != null && skill.Achievement != null && skill.Description != null)
                {
                    EntityContext.Skills.Add(skill);
                }
            }

            var interestList = EntityContext.Interests.Where(i => i.CvId == cv.Id).ToList();
            if (interestList.Count != 0)
            {
                EntityContext.Interests.RemoveRange(interestList);
            }

            foreach (var interest in cv.InterestList)
            {
                if (interest.Hobby != null)
                {
                    EntityContext.Interests.Add(interest);
                }
            }

            EntityContext.SaveChanges();
        }
    }
}