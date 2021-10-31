using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Space.Imdb.DB.Contracts.Entities;
using Space.Imdb.Infrastructure.Contracts.Models.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Infrastructure.Infrastructre
{
    public class ImdbMovieContext : DbContext
    {
        public ImdbMovieContext(DbContextOptions<ImdbMovieContext> options)
              : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviePoster> Posters { get; set; }
        public DbSet<MovieWikiShort> WikiShort { get; set; }
        public DbSet<Watchlist> Watchlist { get; set; }
        public DbSet<Notifications> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Primary Keys*/
            modelBuilder.Entity<Movie>().HasKey(m => m.Id).HasName("PrimaryKey_MovieId");
            modelBuilder.Entity<MoviePoster>().HasKey(mp => mp.Id).HasName("PrimaryKey_MoviePosterId");
            modelBuilder.Entity<MovieWikiShort>().HasKey(mw => mw.Id).HasName("PrimaryKey_MovieWikiShortId");
            modelBuilder.Entity<Watchlist>().HasKey(wl => wl.Id).HasName("PrimaryKey_WatchListId");
            modelBuilder.Entity<Users>().HasKey(u => u.Id).HasName("PrimaryKey_UserId");
            modelBuilder.Entity<Notifications>().HasKey(n => n.Id).HasName("PrimaryKey_NotificationId");

            /*Default Values*/
            modelBuilder.Entity<Movie>().Property(p => p.CreateDate).HasDefaultValueSql("DATEADD (hh,4,GETUTCDATE())");

            modelBuilder.Entity<Watchlist>().Property(p=>p.CreateDate).HasDefaultValueSql("DATEADD (hh,4,GETUTCDATE())");
            modelBuilder.Entity<Watchlist>().Property(p => p.IsWatched).HasDefaultValue(false);
            modelBuilder.Entity<Watchlist>().Property(p => p.Date).HasDefaultValue(DateTime.UtcNow.AddHours(4).ToString("yyyy-MM-dd"));

            modelBuilder.Entity<Notifications>().Property(p => p.CreateDate).HasDefaultValueSql("DATEADD (hh,4,GETUTCDATE())");
            modelBuilder.Entity<Notifications>().Property(p => p.Date).HasDefaultValue(DateTime.UtcNow.AddHours(4).ToString("yyyy-MM-dd"));


            /*Relations*/
            modelBuilder.Entity<Movie>().HasMany(m => m.Posters).WithOne(p => p.Movie).HasForeignKey(p=>p.MovieId);
            modelBuilder.Entity<MovieWikiShort>().HasOne(m => m.Movie).WithOne(w => w.Wikipedia).HasForeignKey<MovieWikiShort>(w=>w.MovieId);
            modelBuilder.Entity<Watchlist>().HasMany(wl => wl.Notifications).WithOne(n => n.Watchlist).HasForeignKey(f=>f.WatchListId);
            modelBuilder.Entity<Watchlist>().HasOne(wl => wl.Users).WithMany(u => u.Watchlist).HasForeignKey(wl => wl.UserId);
            modelBuilder.Entity<Watchlist>().HasOne(wl => wl.Movie).WithMany(m => m.Watchlist).HasForeignKey(wl => wl.MovieId);

            /*Init Data*/
            modelBuilder.Entity<Users>().HasData
             (
                  new Users()
                  {
                      Id = 1,
                      UserName = "User_One"
                  },
                  new Users()
                  {
                      Id = 2,
                      UserName = "User_Two"
                  },
                  new Users()
                  {
                      Id = 3,
                      UserName = "User_Three"
                  }
             );
        }
    }
}
