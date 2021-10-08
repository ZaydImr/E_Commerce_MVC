﻿using Web.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Commande>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Commande>().HasData(
                new Commande
                {
                    Id = Guid.NewGuid(),
                    DateCommande = DateTime.Now,
                    QteCommande = 100,
                    priceCommande = 100.15
                }) ;
        }
        public DbSet<Commande> Commande { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<ItemPaymentMethode> ItemPaymentMethode { get; set; }
    }
}
