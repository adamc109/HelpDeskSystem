

using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        //pass data back to base class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //Create tables
        DbSet<Ticket> Ticket { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Priority> Priorities { get; set; }
        DbSet<Disscusion> discussions { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //stops ticket being deleted if user is deleted
            builder.Entity<Ticket>()
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            //stops deletion of discussion if ticket is deleted
            builder.Entity<Disscusion>()
                .HasOne(e => e.Ticket)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
    

    
}
