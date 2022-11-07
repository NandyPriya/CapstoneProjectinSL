using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAl
{
    public class AdminInfo
    {
        [Key]
        [Required]

        public string EmailId { get; set; }

        public string Password { get; set; }

    }
    public class EmpInfo
    {
        [Key]
        [Required]
        public string EmailId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfJoining { get; set; }
        public int PassCode { get; set; }

    }
    public class BlogInfo
    {
        [Key]
        [Required]
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string BlogUrl { get; set; }
        public string EmpEmailId { get; set; }

    }
    public class MyContext : DbContext
    {
        public virtual DbSet<AdminInfo> AdminInfoTable { get; set; }
        public virtual DbSet<EmpInfo> EmpInfoTable { get; set; }

        public virtual DbSet<BlogInfo> BlogInfoTable { get; set; }


    }
    public class AdminInfoDbInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            var depts = new List<AdminInfo> {
                new AdminInfo { EmailId = "nandhini@gmail.com", Password = "N@ndhu"},
                new AdminInfo { EmailId = "narmatha@gmail.com", Password = "N@rmadha" },
                new AdminInfo { EmailId = "shibiya@gmail.com", Password = "Shibiy@" }

            };
            depts.ForEach(s => context.AdminInfoTable.Add(s));
            context.SaveChanges();
        }
    }

}
