using DogNet.Immo.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DogNet.Immo.Data
{
    public interface IRealtyRepository
    {
        Task<IEnumerable<Realty>> FindAsync(RealtySearchParameters searchParameters);
        Task<Realty> GetByIdAsync(int id);
        Task<Realty> CreateAsync(Realty realty);
        Task<Realty> UpdateAsync(Realty realty);
        Task DeleteAsync(int id);
        Task<bool> Exist(int id);
        Task AddAccessRightAsync(int id, int userIdInt);
    }
}
