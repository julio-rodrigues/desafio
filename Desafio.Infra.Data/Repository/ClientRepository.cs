using Desafio.Domain.Entities;
using Desafio.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Repository {
    public class ClientRepository : IDisposable {
        private DesafioContext DesafioContext = new DesafioContext();

        public void Add(Client client) {
            DesafioContext.Set<Client>().Add(client);
            DesafioContext.SaveChanges();
        }

        public Client GetById(Guid id) {
            return DesafioContext.Client.Find(id);
        }

        public IEnumerable<Client> GetAll() {
            return DesafioContext.Set<Client>().ToList();
        }

        public void Update(Client client) {
            DesafioContext.Entry(client).State = EntityState.Modified;
            DesafioContext.SaveChanges();
        }

        public void Remove(Client client) {
            DesafioContext.Set<Client>().Remove(client);
            DesafioContext.SaveChanges();
        }

        public void Dispose() {
            DesafioContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
