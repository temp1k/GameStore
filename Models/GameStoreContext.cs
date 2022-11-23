using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameStoreASP_Net.Models
{
    public partial class GameStoreContext : DbContext
    {
        public GameStoreContext()
        {
        }

        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CombinationUserGame> CombinationUserGames { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;
        public virtual DbSet<Theme> Themes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.IdCart)
                    .HasName("PK__Cart__C71FE3171B83B0F4");

                entity.ToTable("Cart");

                entity.Property(e => e.IdCart).HasColumnName("id_cart");

                entity.Property(e => e.CombinationUserGameId).HasColumnName("combinationUserGame_id");

                entity.HasOne(d => d.CombinationUserGame)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CombinationUserGameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_combinationUserGame_id");
            });

            modelBuilder.Entity<CombinationUserGame>(entity =>
            {
                entity.HasKey(e => e.IdCombinationUserGame)
                    .HasName("PK__Combinat__787D485DF50A4482");

                entity.ToTable("CombinationUserGame");

                entity.Property(e => e.IdCombinationUserGame).HasColumnName("id_combinationUserGame");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.CombinationUserGames)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_game_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CombinationUserGames)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_id");
            });

            modelBuilder.Entity<Game>(entity =>
            {           
                entity.HasKey(e => e.IdGame)
                    .HasName("PK__Game__0E819B2C6472C6A7");

                entity.ToTable("Game");

                entity.Property(e => e.IdGame).HasColumnName("id_game");

                entity.Property(e => e.GameDescription)
                    .IsUnicode(false)
                    .HasColumnName("game_description")
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.ImageGame)
                    .IsUnicode(false)
                    .HasColumnName("image_game");

                entity.Property(e => e.NameGame)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_game");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_genre_id");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdGenre)
                    .HasName("PK__Genre__CB767C69AF58C1AA");

                entity.ToTable("Genre");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.NameGenre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name_genre");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.IdLanguage)
                    .HasName("PK__Language__1D196341A760DFE8");

                entity.ToTable("Language");

                entity.Property(e => e.IdLanguage).HasColumnName("id_language");

                entity.Property(e => e.NameLanguage)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name_language");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.IdSettings)
                    .HasName("PK__Settings__B0A17973A2528EE4");

                entity.Property(e => e.IdSettings).HasColumnName("id_settings");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.ThemeId).HasColumnName("theme_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_language_id");

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.ThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_theme_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_id");
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.HasKey(e => e.IdTheme)
                    .HasName("PK__Theme__F949191F062B0C08");

                entity.ToTable("Theme");

                entity.Property(e => e.IdTheme).HasColumnName("id_theme");

                entity.Property(e => e.NameTheme)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_theme");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__D2D14637AAC56D2D");

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.ImageUser)
                    .IsUnicode(false)
                    .HasColumnName("image_user")
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.LoginUser)
                    .HasMaxLength(50)
                    .HasColumnName("login_user")
                    .IsUnicode(false);

                entity.Property(e => e.PasswordUser)
                    .HasMaxLength(50)
                    .HasColumnName("password_user")
                    .IsUnicode(false);  
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
