using E_commerce.Aplication.Interfaces.Repositories;
using E_commerce.Aplication.Interfaces.UnitOfWork;
using E_commerce.Persistence.Context;
using E_commerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        public int Save() => _context.SaveChanges();

        public async Task<int> SaveAsync()=>await _context.SaveChangesAsync();
        
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()=> new ReadRepository<T>(_context);
       
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()=> new WriteRepository<T>(_context);

    }
}
