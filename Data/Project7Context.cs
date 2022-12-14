using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project7.Models;

namespace Project7.Data
{
    public class Project7Context : DbContext
    {
        public Project7Context (DbContextOptions<Project7Context> options)
            : base(options)
        {
        }

        public DbSet<Project7.Models.UserModel> UserModel { get; set; } = default!;

        public DbSet<Project7.Models.TaskModel> TaskModel { get; set; } = default!;
    }
}
