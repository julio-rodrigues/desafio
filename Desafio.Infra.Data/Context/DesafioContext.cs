using Desafio.Domain.Entities;
using Desafio.Infra.Data.EntityConfig;
using System.Data.Entity;

namespace Desafio.Infra.Data.Context {
    public class DesafioContext : DbContext{
        public DesafioContext() : base("DefaultConnection") { }

        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Configurations.Add(new ClientConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
