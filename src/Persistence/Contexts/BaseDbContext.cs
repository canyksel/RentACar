﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //    base.OnConfiguring(
        //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(b =>
        {
            b.ToTable("Brands").HasKey(k => k.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");
            //Markanın birden fazla modeli var.
            b.HasMany(b => b.Models);
        });

        modelBuilder.Entity<Model>(m =>
        {
            m.ToTable("Models").HasKey(m => m.Id);
            m.Property(m => m.Id).HasColumnName("Id");
            m.Property(m => m.BrandId).HasColumnName("BrandId");
            m.Property(m => m.Name).HasColumnName("Name");
            m.Property(m => m.DailyPrice).HasColumnName("DailyPrice");
            m.Property(m => m.ImageUrl).HasColumnName("ImageUrl");
            //Modelin bir adet markası var.
            m.HasOne(m => m.Brand);
        });

        Brand[] brandEntitySeeds = { new(1, "BMW"), new(2, "Mercedes") };
        modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);

        Model[] modelEntitySeeds = { new(1, 1, "Series 4", 1500, ""),
            new(2,1,"Series 3",1250,""),
            new(3,2,"A180",1100,"") };
        modelBuilder.Entity<Model>().HasData(modelEntitySeeds);
    }
}
