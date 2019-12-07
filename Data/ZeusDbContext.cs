using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ZeusDbContext : DbContext
    {
        public ZeusDbContext(DbContextOptions<ZeusDbContext> options) : base(options)
        {
        }

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<CoursesUsers> CoursesUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CareerSubject> CareerSubjects { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Section> Sections { get; set; }
        
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ModelCreating.SetIdFromEntities(builder);
            ModelCreating.SetValueGeneratedOnAdd(builder);
            ModelCreating.SetManyToManyRelationships(builder);
            ModelCreating.SeedDatabase(builder);
        }
    }
}