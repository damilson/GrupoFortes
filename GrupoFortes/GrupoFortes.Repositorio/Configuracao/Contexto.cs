using GrupoFortes.Entidades.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GrupoFortes.Repositorio.Configuracao
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("GrupoFortes")
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}