using CollegeSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace CollegeSystem.Entity
{
    public class StudantDAO
    {
        public string AddStudant(Studant studant)
        {
            using (var context = new CollegeContext())
            {
                try
                {
                    if (context.Studants.FirstOrDefault(x=>x.RegistrationNumber == studant.RegistrationNumber) != null)
                    {
                        return "Registration number is already in the database";
                    }

                    context.Studants.Add(studant);
                    context.SaveChanges();
                }

                catch (System.Exception)
                {
                    return "Error";
                }

                return "Sucess";
            }
        }

        public string UpdateStudant(Studant studant)
        {
            using (var context = new CollegeContext())
            {
                var result = context.Studants.FirstOrDefault(c => c.StudantId == studant.StudantId);

                if (result == null)
                {
                    return "Error";
                }


                result.Name = studant.Name;
                result.SubjectId = studant.SubjectId;
                context.SaveChanges();

                return "Sucess";
            }
        }

        public IList<Studant> ListStudant()
        {
            using (var context = new CollegeContext())
            {
                IList<Studant> listStudant = context.Studants.ToList();
                return listStudant;
            }
        }

        public string deleteStudant(Studant studant)
        {
            using (var context = new CollegeContext())
            {
                var result = context.Studants.FirstOrDefault(c => c.StudantId == studant.StudantId);

                if (result == null)
                {
                    return "Error";
                }

                context.Studants.Remove(result);
                context.SaveChanges();

                return "Sucess";
            }
        }
    }
}