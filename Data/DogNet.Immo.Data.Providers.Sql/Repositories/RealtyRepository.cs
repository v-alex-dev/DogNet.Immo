using AutoMapper;
using DogNet.Immo.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogNet.Immo.Data.Providers.Sql.Repositories
{
    public class RealtyRepository : IRealtyRepository
    {
        private readonly DogNetImmoDbContext _dogNetImmoDbContext;
        private readonly IMapper _mapper;

        public RealtyRepository(DogNetImmoDbContext dogNetImmoDbContext, IMapper mapper)
        {
            this._dogNetImmoDbContext = dogNetImmoDbContext;
            this._mapper = mapper;
        }

        public async Task AddAccessRightAsync(int id, int userIdInt)
        {
            var realtyUser = new Models.RealtyUser
            {
                RealtyId = id, 
                UserId = userIdInt
            };

            this._dogNetImmoDbContext.RealtiesUsers.Add(realtyUser);
            await this._dogNetImmoDbContext.SaveChangesAsync();
        }

        public async Task<Realty> CreateAsync(Realty realty)
        {
            var realtyDb = this._mapper.Map<Models.Realty>(realty);
            this._dogNetImmoDbContext.Realties.Add(realtyDb);
            await this._dogNetImmoDbContext.SaveChangesAsync();
            realty.Id = realtyDb.Id;
            return realty;
        }

        public async Task DeleteAsync(int id)
        {
            var realtyDb = new Models.Realty { Id = id };
            this._dogNetImmoDbContext.Entry(realtyDb).State = EntityState.Deleted;
            await this._dogNetImmoDbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            return await this._dogNetImmoDbContext.Realties.AsNoTracking().AnyAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Realty>> FindAsync(RealtySearchParameters searchParameters)
        {
            var sequence = this.ApplyFilters(searchParameters);
            return this._mapper.Map<IEnumerable<Realty>>(await sequence.AsNoTracking().ToListAsync());
        }

        public async Task<Realty> GetByIdAsync(int id)
        {
            return this._mapper.Map<Realty>(await this._dogNetImmoDbContext.Realties.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id));
        }

        public async Task<Realty> UpdateAsync(Realty realty)
        {
            var realtyDb = this._mapper.Map<Models.Realty>(realty);
            this._dogNetImmoDbContext.Attach(realtyDb);
            this._dogNetImmoDbContext.Entry(realtyDb).State = EntityState.Modified;
            await this._dogNetImmoDbContext.SaveChangesAsync();
            return realty;

        }

        private IQueryable<Models.Realty> ApplyFilters(RealtySearchParameters searchParameters)
        {
            var sequence = this._dogNetImmoDbContext.Realties.AsNoTracking();
            if (searchParameters.AreaMin.HasValue)
            {
                sequence = sequence.Where(r => r.Area >= searchParameters.AreaMin);
            }

            if (!string.IsNullOrWhiteSpace(searchParameters.City))
            {
                sequence = sequence.Where(a => a.City.Contains(searchParameters.City));
            }

            if (searchParameters.ForSale.HasValue)
            {
                sequence = searchParameters.ForSale.Value ? sequence.Where(r => r.ForSale) : sequence.Where(r => !r.ForSale);
            }

            if (searchParameters.PriceFrom.HasValue)
            {
                sequence = sequence.Where(r => r.Price >= searchParameters.PriceFrom);
            }

            if (searchParameters.PriceTo.HasValue)
            {
                sequence = sequence.Where(r => r.Price <= searchParameters.PriceTo);
            }

            return sequence;
        }
    }
}
