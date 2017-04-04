using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Test.Model;
using Test.Model.Entities;

namespace Test.Data
{
    public class BloggingContext : DbContext
    {
        public BloggingContext() : base("BloggingDB")
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity 
                    && (x.State == EntityState.Added || x.State == EntityState.Modified));

                var currentUsername = HttpContext.Current != null && HttpContext.Current.User != null
                    ? HttpContext.Current.User.Identity.Name
                    : "System";

                foreach (var entity in entities)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((BaseEntity)entity.Entity).Created = DateTime.Now;
                        ((BaseEntity)entity.Entity).Active = true;
                        ((BaseEntity)entity.Entity).CreatedBy = currentUsername;
                    }

                    ((BaseEntity)entity.Entity).Modified = DateTime.Now;
                    ((BaseEntity)entity.Entity).ModifiedBy = currentUsername;
                }

                return base.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Create/Update failed (context.SaveChanges). Error: " 
                    + ex.Message + " Inner.Inner.Error: " + ex.InnerException.InnerException, ex.InnerException);
            }

        }
    }
}
