using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        Lazy<IMobileRepository> RepositoryMobile { get; }
        Lazy<IManufacturerRepository> RepositoryManufacturer { get; }
        void Commit();
    }
}
