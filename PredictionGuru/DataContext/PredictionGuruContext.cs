using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PredictionGuru.Models;

namespace PredictionGuru.DataContext
{
    public partial class PredictionGuruContext : DbContext
    {
        public virtual DbSet<Continent> Continent { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Ground> Ground { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<MatchResult> MatchResult { get; set; }
        public virtual DbSet<MatchResultPrediction> MatchResultPrediction { get; set; }
        public virtual DbSet<MatchScoreCard> MatchScoreCard { get; set; }
        public virtual DbSet<PlayerForTeam> PlayerForTeam { get; set; }
        public virtual DbSet<PlayerProfile> PlayerProfile { get; set; }
        public virtual DbSet<PlayingPosition> PlayingPosition { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamType> TeamType { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

        public PredictionGuruContext(DbContextOptions<PredictionGuruContext> options) : base(options)
        {

        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS01;Initial Catalog=PredictionGuru;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Country)
                    .HasForeignKey(d => d.ContinentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_Continent");
            });

            modelBuilder.Entity<Ground>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Picture).IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Ground)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ground_Country");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.EndUtcDate).HasColumnType("datetime");

                entity.Property(e => e.StartUtcDate).HasColumnType("datetime");

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.MatchAwayTeam)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Team1");

                entity.HasOne(d => d.Ground)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.GroundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Ground");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.MatchHomeTeam)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Team");
            });

            modelBuilder.Entity<MatchResult>(entity =>
            {
                entity.Property(e => e.MomplayerId).HasColumnName("MOMPlayerId");

                entity.HasOne(d => d.LosingTeam)
                    .WithMany(p => p.MatchResultLosingTeam)
                    .HasForeignKey(d => d.LosingTeamId)
                    .HasConstraintName("FK_MatchResult_Team1");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchResult)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchResult_Match");

                entity.HasOne(d => d.Momplayer)
                    .WithMany(p => p.MatchResult)
                    .HasForeignKey(d => d.MomplayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchResult_PlayerProfile");

                entity.HasOne(d => d.WinningTeam)
                    .WithMany(p => p.MatchResultWinningTeam)
                    .HasForeignKey(d => d.WinningTeamId)
                    .HasConstraintName("FK_MatchResult_Team");
            });

            modelBuilder.Entity<MatchResultPrediction>(entity =>
            {
                entity.HasOne(d => d.LosingTeam)
                    .WithMany(p => p.MatchResultPredictionLosingTeam)
                    .HasForeignKey(d => d.LosingTeamId)
                    .HasConstraintName("FK_MatchResultPrediction_Team1");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchResultPrediction)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchResultPrediction_Match");

                entity.HasOne(d => d.PredictorUser)
                    .WithMany(p => p.MatchResultPrediction)
                    .HasForeignKey(d => d.PredictorUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchResultPrediction_UserProfile");

                entity.HasOne(d => d.WinningTeam)
                    .WithMany(p => p.MatchResultPredictionWinningTeam)
                    .HasForeignKey(d => d.WinningTeamId)
                    .HasConstraintName("FK_MatchResultPrediction_Team");
            });

            modelBuilder.Entity<MatchScoreCard>(entity =>
            {
                entity.Property(e => e.ScoreUtcTime).HasColumnType("datetime");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchScoreCard)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchScoreCard_Match");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.MatchScoreCard)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchScoreCard_PlayerProfile");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.MatchScoreCard)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchScoreCard_Team");
            });

            modelBuilder.Entity<PlayerForTeam>(entity =>
            {
                entity.Property(e => e.JerseyNumber).IsUnicode(false);

                entity.Property(e => e.Picture).IsUnicode(false);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerForTeam)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerForTeam_PlayerProfile");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.PlayerForTeam)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerForTeam_PlayingPosition");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PlayerForTeam)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerForTeam_Team");
            });

            modelBuilder.Entity<PlayerProfile>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.PlayerProfile)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerProfile_Country");
            });

            modelBuilder.Entity<PlayingPosition>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Picture).IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team_Country");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team_TeamType");
            });

            modelBuilder.Entity<TeamType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.JoinUtcDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .IsUnicode(false);
            });
        }
    }
}
