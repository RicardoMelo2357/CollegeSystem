using CollegeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollegeSystem.Entity
{
    public class CourseDAO
    {
        public string AddCourse(Course course)
        {
            using (var context = new CollegeContext())
            {
                var list = ListCourses();
                
                foreach (var item in list)
                {
                    if (item.CourseName.Equals(course.CourseName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return "Course already in the database";
                    }
                }

                try
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                }

                catch (System.Exception)
                {
                    return "Error";
                }
               
                return "Sucess";
            }
        }

        public string UpdateCourse(Course course)
        {
            using (var context = new CollegeContext())
            {
                var result = context.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);

                if (result == null)
                {
                    return "Error";
                }

                result.CourseName = course.CourseName;
                context.SaveChanges();

                return "Sucess";
            }           
        }

        public IList<Course> ListCourses()
        {
            using (var context = new CollegeContext())
            {
                IList<Course> listCourse = context.Courses.ToList();
                return listCourse;
            }
        }

        public string deleteCourse(Course course)
        {
            using (var context = new CollegeContext())
            {
                var result = context.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);

                if (result == null)
                {
                    return "Error";
                }

                context.Courses.Remove(result);
                context.SaveChanges();

                return "Sucess";
            }
        }
    }
}
