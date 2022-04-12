using DogNet.Immo.Core.Exceptions;
using DogNet.Immo.Core.Models;
using DogNet.Immo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DogNet.Immo.Business
{
    public class RealtyDomain
    {
        private readonly IRealtyRepository _realtyRepository;
        private readonly UserDomain _userDomain;

        public RealtyDomain(UserDomain userDomain, IRealtyRepository realtyRepository)
        {
            this._realtyRepository = realtyRepository;
            this._userDomain = userDomain;
        }

        public async Task<Realty> CreateAsync(Realty realty, string userId)
        {
            var userIdInt = int.Parse(userId);

            await this._userDomain.ExistOrThrowAsync(userIdInt);

            var realtyDb = await this._realtyRepository.CreateAsync(realty);

            await this._realtyRepository.AddAccessRightAsync(realtyDb.Id, userIdInt);

            return realtyDb;
        }

        public async Task DeleteAsync(int id)
        {
            await this.Exist(id);
            await this._realtyRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Realty>> FindAsync(RealtySearchParameters searchParameters)
        {
            return await this._realtyRepository.FindAsync(searchParameters);
        }

        public async Task<Realty> GetByIdAsync(int id)
        {
            return await this._realtyRepository.GetByIdAsync(id);
        }

        public async Task<Realty> UpdateAsync(Realty realty)
        {
            await this.Exist(realty.Id);
            return await this._realtyRepository.UpdateAsync(realty);
        }

        private async Task Exist(int id)
        {
            if (!await this._realtyRepository.Exist(id))
            {
                throw new EntityNotFoundException(typeof(Realty).Name, id);
            }
        }
    }
}
