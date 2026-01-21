using explore_pattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace explore_pattern.Domain.Interfaces.Persistences.Repositories
{
    public interface IStoreWriteRepository
    {
        Task AddAsync(Store store);
        void Update(Store store);
        void Remove(Store store);
    }
}
