﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendReview.DAL.Models;

public partial class ReviewDbContext : DbContext
{
    public ReviewDbContext()
    {
    }

    public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Content> Contents { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GamePlatform> GamePlatforms { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Variety> Varieties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Port=3307;Database=ReviewDB;User=nicolas;Password=sdfSDF123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Content>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Content");

            entity.HasIndex(e => e.GamePlatformId, "gamePlatformId");

            entity.HasIndex(e => e.VarietyId, "varietyId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Body)
                .HasColumnType("text")
                .HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("createdAt");
            entity.Property(e => e.GamePlatformId).HasColumnName("gamePlatformId");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.VarietyId).HasColumnName("varietyId");

            entity.HasOne(d => d.GamePlatform).WithMany(p => p.Contents)
                .HasForeignKey(d => d.GamePlatformId)
                .HasConstraintName("Content_ibfk_1");

            entity.HasOne(d => d.Variety).WithMany(p => p.Contents)
                .HasForeignKey(d => d.VarietyId)
                .HasConstraintName("Content_ibfk_2");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Game");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Publisher)
                .HasMaxLength(255)
                .HasColumnName("publisher");
        });

        modelBuilder.Entity<GamePlatform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("GamePlatform");

            entity.HasIndex(e => e.GameId, "gameId");

            entity.HasIndex(e => e.PlatformId, "platformId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("createdAt");
            entity.Property(e => e.GameId).HasColumnName("gameId");
            entity.Property(e => e.PlatformId).HasColumnName("platformId");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("date")
                .HasColumnName("releaseDate");

            entity.HasOne(d => d.Game).WithMany(p => p.GamePlatforms)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("GamePlatform_ibfk_1");

            entity.HasOne(d => d.Platform).WithMany(p => p.GamePlatforms)
                .HasForeignKey(d => d.PlatformId)
                .HasConstraintName("GamePlatform_ibfk_2");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Platform");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Variety>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Variety");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
