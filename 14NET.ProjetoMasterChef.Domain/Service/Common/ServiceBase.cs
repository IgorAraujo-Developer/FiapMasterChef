using _14NET.ProjetoMasterChef.Domain.Interfaces.Repository;
using _14NET.ProjetoMasterChef.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _14NET.ProjetoMasterChef.Domain.Service.Common
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>
        where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }        

        public TEntity Create(TEntity entity)
        {
            return _repository.Create(entity);
        }

        public void Delete(Guid id)
        {
            var obj = this.GetById(id);

            _repository.Delete(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public Task<List<TEntity>> GetAll()
        {            
            return _repository.GetAll();
        }

        public TEntity GetById(Guid id)
        {
           return _repository.GetById(id);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
