namespace Blog_HHoang.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext()
            : base("name=BlogDbContext")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Entry> Entrys { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>()
                .Property(e => e.UrlImg)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.pass)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UrlImg)
                .IsUnicode(false);
        }
    }
}
