using CollegeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollegeSystem.Entity
{
    public class TeacherDAO
    {
        public string AddTeacher (Teacher teacher)
        {
            using (var context = new CollegeContext())
            {
                var list = ListTeacher();

                foreach (var item in list)
                {
                    if (item.SubjectId == teacher.SubjectId)
                    {
                        return "One teacher already own this subject";
                    }
                }

                try
                {
                    context.Teachers.Add(teacher);
                    context.SaveChanges();
                }

                catch (Exception)
                {
                    return "Error";
                }

                return "Sucess";
            }
        }

        public IList<Teacher> ListTeacher()
        {
            using (var context = new CollegeContext())
            {
                IList<Teacher> listTeacher= context.Teachers.ToList();
                IList<Subject> listSubject= context.Subjects.ToList();
                IList<Course> listCourse = context.Courses.ToList();
                return listTeacher;
            }
        }

        public string UpdateTeacher(Teacher teacher)
        {
            using (var context = new CollegeContext())
            {
                var result = context.Teachers.FirstOrDefault(c => c.TeacherId == teacher.TeacherId);

                if (result == null)
                {
                    return "Error";
                }

                result.TeacherName = teacher.TeacherName;
                result.Salary = teacher.Salary;
                result.SubjectId = teacher.SubjectId;
                context.SaveChanges();

                return "Sucess";
            }
        }

        public string DeleteTeacher(Teacher teacher)
        {
            using (var context = new CollegeContext())
            {
                var result = context.Teachers.FirstOrDefault(c => c.TeacherId == teacher.TeacherId);

                if (result == null)
                {
                    return "Error";
                }

                context.Teachers.Remove(result);
                context.SaveChanges();

                return "Sucess";
            }
        }
    }
}