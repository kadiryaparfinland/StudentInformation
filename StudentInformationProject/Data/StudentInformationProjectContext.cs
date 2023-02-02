using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentInformationProject.Model;

namespace StudentInformationProject.Data
{
    public class StudentInformationProjectContext : DbContext
    {
        public StudentInformationProjectContext (DbContextOptions<StudentInformationProjectContext> options)
            : base(options)
        {
        }

        public DbSet<StudentInformationProject.Model.StudentDetails> StudentDetails { get; set; } = default!;
    }
}
