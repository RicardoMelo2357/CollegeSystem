using System;
using System.Collections.Generic;
using System.Linq;
using CollegeSystem.Models;

namespace CollegeSystem.Entity
{
    public class SubjectDAO
    {
        public string AddSubject(Subject subject)
        {
            using (var context = new CollegeContext())
            {
                var list = ListSubject();

                foreach (var item in list)
                {
                    if (item.SubjectName.Equals(subject.SubjectName, StringComparison.InvariantCultureIgnoreCase) &&
                        item.CourseId == subject.CourseId)
                    {
                        return "Subject already in the database";
                    }
                }

                try
                {
                    context.Subjects.Add(subject);
                    context.SaveChanges();
                }

                catch (Exception)
                {
                    return "Error";
                }

                return "Sucess";
            }
        }

        public IList<Subject> ListSubject()
        {
            using (var context = new CollegeContext())
            {
                IList<Subject> listSubject = context.Subjects.ToList();
                IList<Course> listCourse = context.Courses.ToList();

                foreach (var item in listSubject)
                {
                    
                }

                return listSubject;
            }
        }

        public string UpdateSubject(Subject subject)
        {
            using (var context = new CollegeContext())
            {
                var result = context.Subjects.FirstOrDefault(c => c.SubjectName == subject.SubjectName);

                if (result == null)
                {
                    return "Error";
                }

                result.CourseId = subject.CourseId;
                result.SubjectName = subject.SubjectName;
                context.SaveChanges();

                return "Sucess";
            }
        }

        public string deleteSubject(Subject subject)
        {
            using (var context = new CollegeContext())
            {
                var result = context.Subjects.FirstOrDefault(c => c.SubjectId == subject.SubjectId);

                if (result == null)
                {
                    return "Error";
                }

                context.Subjects.Remove(result);
                context.SaveChanges();

                return "Sucess";
            }
        }
    }
}