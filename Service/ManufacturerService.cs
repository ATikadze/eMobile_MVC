using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Service
{
    using Domain;
    using Domain.ServiceInterfaces;
    using Repository;
    public class ManufacturerService : ServiceBase<Manufacturer>, IManufacturerService
    {
        public ManufacturerService(eMobileDbContext context) : base(context)
        {
        }

        public override Manufacturer Find(int id)
        {
            return _unitOfWork.RepositoryManufacturer.Value.Set().SingleOrDefault(s => s.ID == id);
        }

        public override void Remove(Manufacturer entity)
        {
            _unitOfWork.RepositoryManufacturer.Value.Remove(entity);
        }

        public override void Save(Manufacturer entity)
        {
            _unitOfWork.RepositoryManufacturer.Value.Save(entity);
        }

        public override IEnumerable<Manufacturer> Set()
        {
            return _unitOfWork.RepositoryManufacturer.Value.Set();
        }
    }
}
