using System;
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
            builder.Entity<Section>().HasKey(e => e.Id);
            builder.Entity<Subscription>().HasKey(e => e.Id);
            builder.Entity<SubscriptionSection>().HasKey(e => e.Id);
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

            builder.Entity<Section>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();
            
            builder.Entity<Subscription>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();
            
            builder.Entity<SubscriptionSection>()
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
            
            builder.Entity<SubscriptionSection>().HasOne(x => x.Section)
                .WithMany(x => x.SubscriptionSections)
                .HasForeignKey(x => x.SectionId);
            builder.Entity<SubscriptionSection>().HasOne(x => x.Subscription)
                .WithMany(x => x.SubscriptionSections)
                .HasForeignKey(x => x.SubscriptionId);
            builder.Entity<SubscriptionSection>().HasOne(x => x.Status)
                .WithMany(x => x.SubscriptionSections)
                .HasForeignKey(x => x.StatusId);
        }

        public static void SeedDatabase(ModelBuilder builder)
        {
            builder.Entity<UserType>().HasData(
                new UserType {Id = 1, Description = "Participante", CreatedAt = DateTime.Now}
            );

            builder.Entity<Gender>().HasData(
                new Gender {Id = 1, Description = "Masculino", CreatedAt = DateTime.Now},
                new Gender {Id = 2, Description = "Femenino", CreatedAt = DateTime.Now}
            );

            builder.Entity<Status>().HasData(
                new Status {Id = 1, Description = "Aprobado", CreatedAt = DateTime.Now},
                new Status {Id = 2, Description = "Reprobado", CreatedAt = DateTime.Now},
                new Status {Id = 3, Description = "En progreso", CreatedAt = DateTime.Now}
            );

            builder.Entity<Career>().HasData(
                new Career {Id = 1, Description = "Ingenieria de Software", CreatedAt = DateTime.Now}
            );
        }
    }
}