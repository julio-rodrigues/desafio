using Desafio.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Repository {
    public class BaseRepository<TEntity> : IDisposable where TEntity : class{
        protected readonly DesafioContext _desafioContext = new DesafioContext();

        public void Add(TEntity obj) {
            _desafioContext.Set<TEntity>().Add(obj);
            _desafioContext.SaveChanges();
        }

        public TEntity GetById(Guid id) => _desafioContext.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll() => _desafioContext.Set<TEntity>().ToList();

        public void Update(TEntity obj) {
            _desafioContext.Entry(obj).State = EntityState.Modified;
            _desafioContext.SaveChanges();
        }

        public void Remove(TEntity obj) {
            _desafioContext.Set<TEntity>().Remove(obj);
            _desafioContext.SaveChanges();
        }

        public IList<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate) =>_desafioContext.Set<TEntity>().Where(predicate).ToList();

        public int CountAll() => _desafioContext.Set<TEntity>().Count();

        public int CountWhere(Expression<Func<TEntity, bool>> predicate) => _desafioContext.Set<TEntity>().Count(predicate);

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) => _desafioContext.Set<TEntity>().FirstOrDefault(predicate);

        public void Dispose() {
            _desafioContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
