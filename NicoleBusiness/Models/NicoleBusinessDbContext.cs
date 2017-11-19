using Microsoft.EntityFrameworkCore;

namespace NicoleBusiness.Models
{
    public partial class NicoleBusinessDbContext : DbContext
    {
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }


        public NicoleBusinessDbContext(DbContextOptions<NicoleBusinessDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//                modelBuilder.Entity<>(entity =>
//                {
//                    entity.Property(e => e.Url).IsRequired();
//                });
//
//                modelBuilder.Entity<Post>(entity =>
//                {
//                    entity.HasOne(d => d.Blog)
//                        .WithMany(p => p.Post)
//                        .HasForeignKey(d => d.BlogId);
//                });
        }
    }
}