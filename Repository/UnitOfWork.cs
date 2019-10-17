using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    using Domain.RepositoryInterfaces;
    public class UnitOfWork : IUnitOfWork
    {
        private eMobileDbContext _context;
        public UnitOfWork(eMobileDbContext context)
        {
            _context = context;
            RepositoryMobile = new Lazy<IMobileRepository>(new MobileRepository(_context));
            RepositoryManufacturer = new Lazy<IManufacturerRepository>(new ManufacturerRepository(_context));
        }

        public Lazy<IMobileRepository> RepositoryMobile { get; private set; }

        public Lazy<IManufacturerRepository> RepositoryManufacturer { get; private set; }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
