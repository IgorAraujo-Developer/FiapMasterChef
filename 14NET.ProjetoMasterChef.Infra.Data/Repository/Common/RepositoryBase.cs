using _14NET.ProjetoMasterChef.Domain.Interfaces.Repository;
using _14NET.ProjetoMasterChef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _14NET.ProjetoMasterChef.Infra.Data.Repository.Common
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        protected MasterChefContext _context;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(MasterChefContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }
        public virtual TEntity Create(TEntity entity)
        {
            var obj = DbSet.Add(entity);
            SaveChanges();
            return obj.Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            return DbSet.ToListAsync();
        }

        public virtual  TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
            SaveChanges();
        }
    }
}
