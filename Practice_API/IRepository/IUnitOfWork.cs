using Practice_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_API.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();

        public IGenericRepository<User> Users { get; }

        public IGenericRepository<Job> Jobs { get; }

        
    }
}
