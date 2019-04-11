using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _14NET.ProjetoMasterChef.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> 
        where TEntity : class
    {
        TEntity GetById(Guid id);
        Task<List<TEntity>> GetAll();
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        int SaveChanges();
        void Dispose();
    }
}
