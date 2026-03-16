using DentalClinic.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DentalClinicDbContext _context;
        public Repository(DentalClinicDbContext context)
        {
            _context = context;
        }
        public Task AddAsync(T entity)
        {
            _context.Add(entity);
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(Guid id)
        {
            _context.Remove(id);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> GetTotalAmountOfRecords()
        {
            return await _context.Set<T>().CountAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
