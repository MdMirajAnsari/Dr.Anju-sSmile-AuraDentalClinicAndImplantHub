using DentalClinic.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Persistence.UnitsOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork
    {
        private readonly DentalClinicDbContext _dbContext;

        public UnitOfWorkEFCore(DentalClinicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
