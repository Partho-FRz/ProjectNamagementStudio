using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsEntity
{
    public class DataContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<HeadOfSQ> HeadOfSQs { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Feed> Feeds { get; set; }
    }
}
