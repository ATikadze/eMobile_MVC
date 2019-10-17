using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    using Domain;
    using Domain.RepositoryInterfaces;
    public class ManufacturerRepository : RepositoryBase<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(eMobileDbContext context) : base(context)
        {
        }
    }
}
