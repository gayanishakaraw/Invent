using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DbContext Context { get; set; }

        public GenericRepository(DbContext context)
        {
            Context = context;
        }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = Context.Set<TEntity>();
                return _dbSet;
            }
        }

        private DbSet<TEntity> _dbSet;

        #region Regular Members
        public virtual IList<TEntity> GetAll()
        {
            return this.DbSet.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetIQueryable()
        {
            return this.DbSet.AsQueryable<TEntity>();
        }

        public virtual IList<TEntity> GetAllPaged(int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = this.DbSet.Count();
            return this.DbSet.Skip(pageSize * pageIndex).Take(pageSize).ToList();
        }

        public int Count()
        {
            return this.DbSet.Count();
        }

        public virtual object Insert(TEntity entity, bool saveChanges = false)
        {
            var rtn = this.DbSet.Add(entity);
            if (saveChanges)
            {
                Context.SaveChanges();
            }
            return rtn;
        }

        public virtual void Delete(object id, bool saveChanges = false)
        {
            this.DbSet.Remove(GetById(id));
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }

        public virtual void Delete(TEntity entity, bool saveChanges = false)
        {
            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }

        public virtual void Update(TEntity entity, bool saveChanges = false)
        {
            var entry = Context.Entry(entity);
            this.DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }

        public virtual TEntity Update(TEntity entity, object key, bool saveChanges = false)
        {
            if (entity == null)
                return null;
            var exist = this.DbSet.Find(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(entity);
                if (saveChanges)
                {
                    Context.SaveChanges();
                }
            }
            return exist;
        }

        public virtual void Commit()
        {
            Context.SaveChanges();
        }
        #endregion

        #region Async Members
        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id).ConfigureAwait(false);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await DbSet.SingleOrDefaultAsync(match).ConfigureAwait(false);
        }

        public async Task<int> CountAsync()
        {
            return await DbSet.CountAsync().ConfigureAwait(false);
        }

        public virtual async Task<object> InsertAsync(TEntity entity, bool saveChanges = false)
        {
            var rtn = await DbSet.AddAsync(entity).ConfigureAwait(false);
            if (saveChanges)
            {
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
            return rtn;
        }

        public virtual async Task DeleteAsync(object id, bool saveChanges = false)
        {
            this.DbSet.Remove(GetById(id));
            if (saveChanges)
            {
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public virtual async Task DeleteAsync(TEntity entity, bool saveChanges = false)
        {
            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
            if (saveChanges)
            {
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public virtual async Task UpdateAsync(TEntity entity, bool saveChanges = false)
        {
            var entry = Context.Entry(entity);
            this.DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
            {
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, object key, bool saveChanges = false)
        {
            if (entity == null)
                return null;
            var exist = await DbSet.FindAsync(key).ConfigureAwait(false);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(entity);
                if (saveChanges)
                {
                    await Context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            return exist;
        }
        #endregion

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose() => Dispose(true);

        public IList<TEntity> GetAllMatched(Expression<Func<TEntity, bool>> match)
        {
            return this.DbSet.Where(match).ToList();
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = this.DbSet;
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<TEntity, object>(includeProperty);
            }
            return queryable;
        }

        public TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return this.DbSet.SingleOrDefault(match);
        }

        IQueryable<TEntity> IGenericRepository<TEntity>.GetIQueryable()
        {
            throw new NotImplementedException();
        }

        async Task<IList<TEntity>> IGenericRepository<TEntity>.GetAllAsync()
        {
            return await this.DbSet.ToListAsync();
        }

        public virtual async Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await DbSet.Where(match).ToListAsync().ConfigureAwait(false);
        }

        async Task<TEntity> IGenericRepository<TEntity>.GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id).ConfigureAwait(false);
        }

        Task<int> IGenericRepository<TEntity>.CountAsync()
        {
            throw new NotImplementedException();
        }

        Task<object> IGenericRepository<TEntity>.InsertAsync(TEntity entity, bool saveChanges)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<TEntity>.DeleteAsync(object id, bool saveChanges)
        {
            await Task.Run(() =>
            {
                this.DbSet.Remove(GetById(id));
                if (saveChanges)
                {
                    Context.SaveChanges();
                }
            });
        }

        Task IGenericRepository<TEntity>.DeleteAsync(TEntity entity, bool saveChanges)
        {
            throw new NotImplementedException();
        }

        Task IGenericRepository<TEntity>.UpdateAsync(TEntity entity, bool saveChanges)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IGenericRepository<TEntity>.UpdateAsync(TEntity entity, object key, bool saveChanges)
        {
            throw new NotImplementedException();
        }

        Task IGenericRepository<TEntity>.CommitAsync()
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IGenericRepository<TEntity>.GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public bool IsActive(TEntity entiry, object key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsActiveAsync(TEntity entity, object key)
        {
            throw new NotImplementedException();
        }
    }
}
