﻿using E_commerce.Aplication.Interfaces.Repositories;
using E_commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Aplication.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase,new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase,new();
        Task<int> SaveAsync();
        int Save();
    }
}
