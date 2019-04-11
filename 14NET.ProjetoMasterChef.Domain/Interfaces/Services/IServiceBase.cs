using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _14NET.ProjetoMasterChef.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity>
        where TEntity : class
    {
        TEntity GetById(Guid id);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        Task<List<TEntity>> GetAll();
        void Dispose();
    }
}
