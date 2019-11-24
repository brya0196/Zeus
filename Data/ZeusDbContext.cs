using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ZeusDbContext : DbContext
    {
        public ZeusDbContext( DbContextOptions<ZeusDbContext> options ) : base(options)
        {
            
        }

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CoursesUsers> CoursesUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);

            builder.Entity<UserType>().HasKey(e => e.Id);
            builder.Entity<Gender>().HasKey(e => e.Id);
            builder.Entity<Course>().HasKey(e => e.Id);
            builder.Entity<Status>().HasKey(e => e.Id);
            builder.Entity<User>().HasKey(e => e.Id);
            builder.Entity<Subject>().HasKey(e => e.Id);

            builder.Entity<UserType>().HasData(
                new UserType {Id = 1, description = "Participante", created_at = DateTime.Now}
            );
            
            builder.Entity<Gender>().HasData(
                new Gender {Id = 1, description = "Masculino", created_at = DateTime.Now},
                new Gender {Id = 2, description = "Femenino", created_at = DateTime.Now}
            );
            
            builder.Entity<Status>().HasData(
                new Status {Id = 1, description = "Aprobado", created_at = DateTime.Now},
                new Status {Id = 2, description = "Reprobado", created_at = DateTime.Now},
                new Status {Id = 3, description = "En progreso", created_at = DateTime.Now}
            );
        }
    }
}