using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentRelationApi.Models;

namespace StudentRelationApi.Data
{
    public class StudentRelationApiContext : DbContext
    {
        public StudentRelationApiContext (DbContextOptions<StudentRelationApiContext> options)
            : base(options)
        {
        }

        public DbSet<StudentRelationApi.Models.Course> Course { get; set; } = default!;
    }
}
