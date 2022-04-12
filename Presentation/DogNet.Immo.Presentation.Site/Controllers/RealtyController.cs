using AutoMapper;
using DogNet.Immo.Business;
using DogNet.Immo.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DogNet.Immo.Presentation.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealtyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly RealtyDomain _realtyDomain;

        public RealtyController(RealtyDomain realtyDomain, IMapper mapper)
        {
            this._mapper = mapper;
            this._realtyDomain = realtyDomain;
        }

        [HttpGet]
        public async Task<IActionResult> FindAsync([FromQuery] string city, [FromQuery] decimal? priceFrom, [FromQuery] decimal? priceTo,
                                                   [FromQuery] int? areaMin, [FromQuery] bool? forSale)
        {
            try
            {
                var searchParams = new RealtySearchParameters
                {
                    AreaMin = areaMin,
                    City = city,
                    ForSale = forSale,
                    PriceFrom = priceFrom,
                    PriceTo = priceTo
                };

                return this.Ok(this._mapper.Map<IEnumerable<Models.Realty>>(await this._realtyDomain.FindAsync(searchParams)));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return this.Ok(this._mapper.Map<Models.Realty>(await this._realtyDomain.GetByIdAsync(id)));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync([FromBody] Models.Realty realty)
        {
            try
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return this.Ok(this._mapper.Map<Models.Realty>(
                    await this._realtyDomain.CreateAsync(this._mapper.Map<Realty>(realty), userId)));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Models.Realty realty)
        {
            try
            {
                return this.Ok(this._mapper.Map<Models.Realty>(await this._realtyDomain.UpdateAsync(this._mapper.Map<Realty>(realty))));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await this._realtyDomain.DeleteAsync(id);
                return this.Ok();
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
