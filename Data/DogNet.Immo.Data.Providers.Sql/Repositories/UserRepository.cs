using AutoMapper;
using DogNet.Immo.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DogNet.Immo.Data.Providers.Sql.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DogNetImmoDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DogNetImmoDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<User> CreateAsync(User user)
        {
            var userDb = this._mapper.Map<Models.User>(user);
            this._context.Users.Add(userDb);
            await this._context.SaveChangesAsync();
            user.Id = userDb.Id;
            return user;
        }

        public async Task<bool> Exist(int id)
        {
            return await this._context.Users.AsNoTracking().AnyAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var userDb = await this._context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email.Equals(email));
            return this._mapper.Map<User>(userDb);
        }
    }
}