using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicService.Core.Models;
using MusicService.Core.Models.Connective;
using MusicService.Core.Models.Identity;

namespace MusicService.DAL.Data
{
    public class ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) 
        : IdentityDbContext<ApplicationUser>(options)
    {

        public virtual DbSet<AlbumMelody> AlbumMelodies {  get; set; }
        public virtual DbSet<ApplicationUserMelody> UserMelodies { get; set; }
        public virtual DbSet<GenreAlbum> GenreAlbums { get; set; }
        public virtual DbSet<GenreAuthor> GenreAuthors { get; set; }
        public virtual DbSet<GenreMelody> GenreMelodies { get; set; }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Melody> Melodies { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Album>(entity =>
                entity.HasOne(a => a.Author).WithMany(a => a.Albums)
                .OnDelete(DeleteBehavior.NoAction));
            builder.Entity<Melody>(entity => 
                entity.HasOne(m => m.Author).WithMany(a=>a.Melodies)
                .OnDelete(DeleteBehavior.NoAction));

            builder.Entity<AlbumMelody>(entity =>
            {
                entity.HasOne(a => a.Melody).WithMany(a => a.Albums).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(a => a.Album).WithMany(a => a.Melodies).OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<ApplicationUserMelody>(entity =>
            {
                entity.HasOne(a => a.Melody).WithMany(a => a.ApplicationUsers).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(a => a.ApplicationUser).WithMany(a => a.Melodies).OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<GenreAlbum>(entity =>
            {
                entity.HasOne(a => a.Genre).WithMany(a => a.Albums).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(a => a.Album).WithMany(a => a.Genres).OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<GenreAuthor>(entity =>
            {
                entity.HasOne(a => a.Genre).WithMany(a => a.Authors).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(a => a.Author).WithMany(a => a.Genres).OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<GenreMelody>(entity =>
            {
                entity.HasOne(a => a.Melody).WithMany(a => a.Genres).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(a => a.Genre).WithMany(a => a.Melodies).OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "2",
                Name = "User",
                NormalizedName = "USER"
            });

            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                UserName = "admin123@i.ua",
                NormalizedUserName = "ADMIN123@I.UA",
                Email = "admin123@i.ua",
                NormalizedEmail = "ADMIN123@I.UA",
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin_123");

            builder.Entity<ApplicationUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = adminUser.Id,
            });
        }
    }
}
