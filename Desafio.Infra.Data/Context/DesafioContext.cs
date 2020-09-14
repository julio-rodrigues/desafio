using Desafio.Domain.Entities;
using Desafio.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Desafio.Infra.Data.Context {
    public class DesafioContext : DbContext{
        public DesafioContext() : base("DefaultConnection") { }

        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Define que a tabela "Nome+Id" sempre será tratada como chave primaria
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Define o tipo varchar padrão para criação de tabela
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //Define o tamanho padrão para 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new ProductConfig());

            base.OnModelCreating(modelBuilder);
        }


    }
}
