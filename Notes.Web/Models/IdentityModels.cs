using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Notes.Web.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set;}
        public DbSet<Note> Notes { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}