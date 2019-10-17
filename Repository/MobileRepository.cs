using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    using Domain;
    using Domain.RepositoryInterfaces;
    public class MobileRepository : RepositoryBase<Mobile>, IMobileRepository
    {
        public MobileRepository(eMobileDbContext context) : base(context)
        {
        }
    }
}
