using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    using Domain.ServiceInterfaces;
    using Repository;
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity>
        where TEntity : class
    {
        protected UnitOfWork _unitOfWork;
        public ServiceBase(eMobileDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public abstract TEntity Find(int id);
        public abstract void Remove(TEntity entity);
        public abstract void Save(TEntity entity);
        public abstract IEnumerable<TEntity> Set();

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
