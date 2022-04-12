using DogNet.Immo.Core.Models;
using System.Threading.Tasks;

namespace DogNet.Immo.Data
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> Exist(int id);
    }
}
