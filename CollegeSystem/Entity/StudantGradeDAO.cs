using CollegeSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace CollegeSystem.Entity
{
    public class StudantGradeDAO
    {
        public string AddStudantGrade(StudantGrade studantGrade)
        {
            using (var context = new CollegeContext())
            {
                var list = ListStudantGrade();

                try
                {
                    context.StudantGrades.Add(studantGrade);
                    context.SaveChanges();
                }

                catch (System.Exception)
                {
                    return "Error";
                }

                return "Sucess";
            }
        }

        public string UpdateStudantGrade(StudantGrade studantGrade)
        {
            using (var context = new CollegeContext())
            {
                var result = context.StudantGrades.FirstOrDefault(c => c.StudantGradeId == studantGrade.StudantGradeId);

                if (result == null)
                {
                    return "Error";
                }

                result.Grade = studantGrade.Grade;
                result.StudantId = studantGrade.StudantId;
                result.SubjectId = studantGrade.SubjectId;
                context.SaveChanges();

                return "Sucess";
            }
        }

        public IList<StudantGrade> ListStudantGrade()
        {
            using (var context = new CollegeContext())
            {
                IList<StudantGrade> listStudantGrade = context.StudantGrades.ToList();
                return listStudantGrade;
            }
        }

        public string deleteStudantGrade(StudantGrade studantGrade)
        {
            using (var context = new CollegeContext())
            {
                var result = context.StudantGrades.FirstOrDefault(c => c.StudantGradeId == studantGrade.StudantGradeId);

                if (result == null)
                {
                    return "Error";
                }

                context.StudantGrades.Remove(result);
                context.SaveChanges();

                return "Sucess";
            }
        }
    }
}