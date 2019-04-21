using CollegeSystem.Models;
using System.Data.Entity;

namespace CollegeSystem.Entity
{
    public class CollegeContext : DbContext
    {
        public CollegeContext(): base("CollegeContext")
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Studant> Studants { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudantGrade> StudantGrades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().
                HasRequired(c => c.Subject)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>().
                HasRequired(c => c.Course)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Studant>().
               HasRequired(c => c.Subject)
               .WithMany()
               .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}