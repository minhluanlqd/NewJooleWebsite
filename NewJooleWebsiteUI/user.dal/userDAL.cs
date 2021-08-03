using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NewJooleWebsiteUI.Models;

namespace NewJooleWebsiteUI.user.dal
{
    //created a new class in NewJooleWebsiteUI since no other project within the solution can reference the UI
    public class userDAL:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("tblUser");

        }

        public DbSet<User> Users { get; set; }
    }
}