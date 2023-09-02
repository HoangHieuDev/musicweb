using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using music_app_model;

namespace music_web_app.Data
{
    public class music_web_app_DBContext : DbContext
    {
        public music_web_app_DBContext(DbContextOptions<music_web_app_DBContext> options) : base(options) { }
        public DbSet<CategorySong> CategorySong { get; set; } = default!;
        public DbSet<History> History { get; set; } = default!;
        public DbSet<ListDetail> ListDetail { get; set; } = default!;
        public DbSet<PlayList> PlayList { get; set; } = default!;
        public DbSet<Singer> Singer { get; set; } = default!;
        public DbSet<Song> Song { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategorySong>().ToTable("CategorySong");
            modelBuilder.Entity<History>().ToTable("History");
            modelBuilder.Entity<ListDetail>().ToTable("ListDetail");
            modelBuilder.Entity<PlayList>().ToTable("PlayList");
            modelBuilder.Entity<Song>().ToTable("Song");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
