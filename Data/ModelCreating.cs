using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ModelCreating
    {
        public static void SetIdFromEntities(ModelBuilder builder)
        {
            builder.Entity<UserType>().HasKey(e => e.Id);
            builder.Entity<Gender>().HasKey(e => e.Id);
            builder.Entity<Course>().HasKey(e => e.Id);
            builder.Entity<Status>().HasKey(e => e.Id);
            builder.Entity<Career>().HasKey(e => e.Id);
            builder.Entity<User>().HasKey(e => e.Id);
            builder.Entity<Subject>().HasKey(e => e.Id);
            builder.Entity<CareerSubject>().HasKey(e => e.Id);
            builder.Entity<Period>().HasKey(e => e.Id);
        }

        public static void SetValueGeneratedOnAdd(ModelBuilder builder)
        {
            builder.Entity<UserType>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<Gender>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<Course>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<Status>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<User>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<Subject>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<Career>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            builder.Entity<CareerSubject>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();
            
            builder.Entity<Period>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();
        }

        public static void SetManyToManyRelationships(ModelBuilder builder)
        {
            builder.Entity<CareerSubject>().HasOne(x => x.Career)
                .WithMany(x => x.CareerSubjects)
                .HasForeignKey(x => x.CareerId);
            builder.Entity<CareerSubject>().HasOne(x => x.Subject)
                .WithMany(x => x.CareerSubjects)
                .HasForeignKey(x => x.SubjectId);
        }
    }
}