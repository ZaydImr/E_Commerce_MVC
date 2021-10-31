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
            modelBuilder.Entity<Message>().HasOne(m => m.UserProvider)
                                          .WithMany(u => u.messagesSender)
                                          .HasForeignKey(fk => fk.usernameProvider);

            modelBuilder.Entity<Message>().HasOne(m => m.UserReceiver)
                                          .WithMany(u => u.messagesReceiver)
                                          .HasForeignKey(fk => fk.usernameReceiver);
        }

        public DbSet<Commande> Commande { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<ItemPaymentMethode> ItemPaymentMethode { get; set; }
    }
}
