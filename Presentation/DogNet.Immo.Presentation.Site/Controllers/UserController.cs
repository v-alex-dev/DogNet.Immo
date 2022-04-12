using AutoMapper;
using DogNet.Immo.Business;
using DogNet.Immo.Core.Models;
using DogNet.Immo.Presentation.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DogNet.Immo.Presentation.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDomain _userDomain;
        private readonly IMapper _mapper;
        public UserController(UserDomain userDomain, IMapper mapper)
        {
            this._userDomain = userDomain;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserCreate user)
        {
            try
            {
                var userCore = this._mapper.Map<User>(user);
                var result = await this._userDomain.CreateAsync(userCore);
                return this.Ok(this._mapper.Map<Models.UserData>(result));
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
