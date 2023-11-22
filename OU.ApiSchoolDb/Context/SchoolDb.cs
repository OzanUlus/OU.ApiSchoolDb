using Microsoft.EntityFrameworkCore;
using OU.ApiSchoolDb.Models;
using System.Collections.Generic;

namespace OU.ApiSchoolDb.Context
{
    public class SchoolDb : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public SchoolDb(DbContextOptions<SchoolDb> options) : base(options)
        {

        }
    }
}
