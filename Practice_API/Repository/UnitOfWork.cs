using Practice_API.Data;
using Practice_API.IRepository;
using Practice_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private IGenericRepository<User> _users;

        private IGenericRepository<Job> _jobs;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }
        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(context);
        public IGenericRepository<Job> Jobs => _jobs ??= new GenericRepository<Job>(context);

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
            //throw new NotImplementedException();
        }
    }
}
