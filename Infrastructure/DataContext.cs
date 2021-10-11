using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
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


            /*TypeUser typeUser = new TypeUser
            {
                Id = Guid.NewGuid(),
                nameType = "User",
            } ;
            modelBuilder.Entity<TypeUser>().HasData(typeUser);
                
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "test",
                    Password = "test",
                    Numero = "0618053929",
                    TypeUser = typeUser
                });*/
        }
        public DbSet<Commande> Commande { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<ItemPaymentMethode> ItemPaymentMethode { get; set; }
    }
}
