using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Models.PlaylistManagement;
using MyAnthemsAPI.Models.SongManagement;
using MyAnthemsAPI.Models.UserManagement;

namespace MyAnthemsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Playlist> Playlists => Set<Playlist>();
        public DbSet<Song> Songs => Set<Song>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Playlist>()
                .HasOne<User>()
                .WithMany(u => u.Playlists)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<PlaylistSong>()
                .HasKey(ps => new { ps.PlaylistId, ps.SongId });

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistId);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId);
        }
    }
}