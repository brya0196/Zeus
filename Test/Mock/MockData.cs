using System.Collections.Generic;
using System.Linq;
using Core.Helpers;
using Data.Entities;
using GenFu;

namespace Test.Mock
{
    public class MockData
    {
        public static IEnumerable<User> GetFakeUsers()
        {
            var i = 1;
            var users = A.ListOf<User>(5);
            users.ForEach(x =>
            {
                x.Id = i++;
                x.Password = PasswordHelper.HashPassword(x.Password);
            });
            return users.Select(x => x);
        }

        public static IEnumerable<Section> GetFakeSections()
        {
            var i = 1;
            var sections = A.ListOf<Section>(5);
            sections.ForEach(x => x.Id = i++);
            return sections.Select(x => x);
        }

        public static IEnumerable<Subject> GetFakeSubjects()
        {
            var i = 1;
            var subjects = A.ListOf<Subject>(1);
            subjects.ForEach(x => x.Id = i++);
            return subjects.Select(x => x);
        }

        public static IEnumerable<Career> GetFakeCareer()
        {
            var i = 1;
            var careers = A.ListOf<Career>(1);
            careers.ForEach(x => x.Id = i++);
            return careers.Select(x => x);
        }

        public static IEnumerable<CareerSubject> GetFakeCareerSubject()
        {
            var i = 1;
            var subjects = GetFakeSubjects();
            var careers = GetFakeCareer();
            var careerSubjects = A.ListOf<CareerSubject>(1);
            careerSubjects.ForEach(x =>
            {
                x.Id = i++;
                x.CareerId = careers.First().Id;
                x.SubjectId = subjects.First().Id;
                x.Career = careers.First();
                x.Subject = subjects.First();
            });
            
            return careerSubjects.Select(x => x);
        }

        public static IEnumerable<Period> GetFakePeriod()
        {
            var i = 1;
            var careerSubjects = GetFakeCareerSubject();
            var periods = A.ListOf<Period>();
            periods.ForEach(x =>
            {
                x.Id = i++;
                x.Active = 1;
                x.CareerSubjects = careerSubjects;
            });

            return periods.Select(x => x);
        }
    }
}