using Microsoft.EntityFrameworkCore;
using Livraria.Models;

namespace Livraria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Adicione as DbSets para cada tabela
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<LivroAutor> Livro_Autor { get; set; }
        public DbSet<LivroAssunto> Livro_Assunto { get; set; }
        public DbSet<RelatorioLivro> RelatorioLivro { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Assunto>()
            .HasKey(a => a.CodAs);

        modelBuilder.Entity<Livro>()
            .HasKey(l => l.Codl);

        modelBuilder.Entity<Autor>()
            .HasKey(a => a.CodAu); 

         modelBuilder.Entity<LivroAutor>()
            .HasKey(a => a.Livro_Codl); 

        modelBuilder.Entity<LivroAssunto>()
            .HasKey(a => a.Livro_Codl);

        modelBuilder.Entity<RelatorioLivro>()
            .ToTable("VWRELATORIOLIVROS");

        modelBuilder.Entity<RelatorioLivro>().HasNoKey();


        }
    }

}
