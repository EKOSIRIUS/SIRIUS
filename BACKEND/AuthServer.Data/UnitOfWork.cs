using AuthServer.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        void IUnitOfWork.Commit()
        {
            _context.SaveChanges();
        }

        Task IUnitOfWork.CommitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
