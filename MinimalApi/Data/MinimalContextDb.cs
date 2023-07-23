using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi.Data
{
    public class MinimalContextDb : DbContext
    {
        public MinimalContextDb(DbContextOptions<MinimalContextDb> options) : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedor>().HasKey(f => f.Id);
            modelBuilder.Entity<Fornecedor>().Property(f => f.Nome).HasMaxLength(100);
            modelBuilder.Entity<Fornecedor>().Property(f => f.Documento).HasMaxLength(14);
            modelBuilder.Entity<Fornecedor>().Property(f => f.Ativo).HasDefaultValue(true);

            base.OnModelCreating(modelBuilder);
        }
    }	
}