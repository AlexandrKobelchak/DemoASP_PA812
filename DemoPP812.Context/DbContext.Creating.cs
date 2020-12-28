using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainContext
{
    public partial class MyDbContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
               .HasOne(f => f.Faculty)
               .WithMany(p => p.Groups)
               .HasForeignKey(pt => pt.FacultyId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(st => st.Students)
                .HasForeignKey(stu => stu.GroupId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Faculty>().HasData(
               new Faculty { Id = 1, Name = "Программирования" },
               new Faculty { Id = 2, Name = "Администрирования" },
               new Faculty { Id = 3, Name = "Графики" });

            modelBuilder.Entity<Group>().HasData(
              new Group { Id = 1, Name = "СПВ22-01", FacultyId = 1 },
              new Group { Id = 2, Name = "СПД22-21", FacultyId = 3 },
              new Group { Id = 3, Name = "СПУ20-01", FacultyId = 1 });

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Василий", MiddleName = "Иванович", LastName = "Пупкин", GroupId = 1 },
                new Student { Id = 2, FirstName = "Олег", MiddleName = "Петрович", LastName = "Иванов", GroupId = 3 },
                new Student { Id = 3, FirstName = "Ольга", MiddleName = "Ивановна", LastName = "Петрова", GroupId = 1 },
                new Student { Id = 4, FirstName = "Татьяна", MiddleName = "Владимировна", LastName = "Сидорова", GroupId = 3 },
                new Student { Id = 5, FirstName = "Светлана", MiddleName = "Петровна", LastName = "Иванова", GroupId = 2 },
                new Student { Id = 6, FirstName = "Владимир", MiddleName = "Владимирович", LastName = "Петров", GroupId = 2 },
                new Student { Id = 7, FirstName = "Николай", MiddleName = "Иванович", LastName = "Павлов", GroupId = 1 },
                new Student { Id = 8, FirstName = "Петр", MiddleName = "Дмитриевич", LastName = "Иванов", GroupId = 3 });

        }
    }
}
