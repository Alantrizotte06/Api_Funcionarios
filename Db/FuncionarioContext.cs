using Microsoft.EntityFrameworkCore;
using FuncionarioApi.Models;

namespace FuncionarioApi.Data
{
  public class FuncionarioContext : DbContext
  {
    public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options) { }

    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Gerente> Gerentes { get; set; }
    public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
    public DbSet<Estagiario> Estagiarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Funcionario>().ToTable("Funcionario");
      modelBuilder.Entity<Gerente>().ToTable("Gerente");
      modelBuilder.Entity<Desenvolvedor>().ToTable("Desenvolvedor");
      modelBuilder.Entity<Estagiario>().ToTable("Estagiario");
    }
  }
}
