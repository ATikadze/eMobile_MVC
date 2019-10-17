using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Service
{
    using Domain;
    using Domain.ServiceInterfaces;
    using Repository;
    public class MobileService : ServiceBase<Mobile>, IMobileService
    {
        public MobileService(eMobileDbContext context) : base(context)
        {
        }

        public override Mobile Find(int id)
        {
            return _unitOfWork.RepositoryMobile.Value.Set().SingleOrDefault(s => s.ID == id);
        }

        public override void Remove(Mobile entity)
        {
            _unitOfWork.RepositoryMobile.Value.Remove(entity);
        }

        public override void Save(Mobile entity)
        {
            _unitOfWork.RepositoryMobile.Value.Save(entity);
        }

        public override IEnumerable<Mobile> Set()
        {
            return _unitOfWork.RepositoryMobile.Value.Set();
        }
    }
}
