namespace LinksApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LinksEntities : DbContext
    {
        public LinksEntities()
            : base("name=LinksEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
