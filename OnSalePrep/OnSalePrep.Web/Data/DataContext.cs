﻿using Microsoft.EntityFrameworkCore;
using OnSalePrep.Web.Data.Entities;

namespace OnSalePrep.Web.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }


    public DbSet<Category> Categories { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<State> States { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<State>().HasIndex("Name","CountryId").IsUnique();
        modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();
    }
}
