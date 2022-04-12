using DogNet.Immo.Core.Exceptions;
using DogNet.Immo.Core.Models;
using DogNet.Immo.Data;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DogNet.Immo.Business
{
    public class UserDomain
    {
        private readonly IUserRepository _userRepository;
        public UserDomain(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<User> CreateAsync(User user)
        {
            if (await this._userRepository.GetUserByEmailAsync(user.Email) != null)
            {
                throw new BusinessException("Cet email est déjà utilisé.");
            }

            var length = 1000;
            var iteration = 10000;
            var salt = GenerateSalt(length);
            var encodedPassword = Encoding.ASCII.GetBytes(user.Password);
            var hash = GenerateHash(encodedPassword, salt, iteration, length);

            user.Salt = Convert.ToBase64String(salt);
            user.Password = Convert.ToBase64String(hash);
            user.RoleId = (int)RoleEnum.User;

            return await this._userRepository.CreateAsync(user);
        }

        public async Task<UserData> Login(Credentials credentials)
        {
            var user = await this._userRepository.GetUserByEmailAsync(credentials.Email);
            if (user == null)
            {
                return null;
            }

            var length = 1000;
            var iteration = 10000;
            var encodedPassword = Encoding.ASCII.GetBytes(credentials.Password);
            var hash = GenerateHash(encodedPassword, Convert.FromBase64String(user.Salt), iteration, length);
            var hashToCompare = Convert.ToBase64String(hash);

            if (user.Password != hashToCompare)
            {
                return null;
            }

            var userData = new UserData
            {
                Id = user.Id,
                Email = user.Email,
                RoleId = user.RoleId,
            };

            return userData;
        }

        public async Task ExistOrThrowAsync(int userId)
        {
            if (!await this._userRepository.Exist(userId))
            {
                throw new EntityNotFoundException(typeof(User).Name, userId);
            }
        }

        private static byte[] GenerateSalt(int length)
        {
            var bytes = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return bytes;
        }

        private static byte[] GenerateHash(byte[] password, byte[] salt, int iterations, int length)
        {
            using var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations);
            return deriveBytes.GetBytes(length);
        }
    }
}
