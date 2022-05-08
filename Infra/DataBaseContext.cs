using Microsoft.EntityFrameworkCore;
using Infra.Models;

namespace Infra;

public class DataBaseContext : DbContext
{
    
    
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {        
    }

    public DbSet<CombinacoesEntradaModel> CombinacoesEntrada {get;set;}
    public DbSet<CombinacoesSaidaModel> CombinacoesSaida {get;set;}           
    

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
      optionsBuilder.EnableSensitiveDataLogging();     
}

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {

   modelBuilder.Entity<CombinacoesEntradaModel>(f =>
            {
                f.HasKey(e => e.Id);
                f.HasIndex(e => new { e.Id });
            });

   modelBuilder.Entity<CombinacoesSaidaModel>(g =>
            {
                g.HasIndex(i => new { i.Id});
            });  
 } 


}

