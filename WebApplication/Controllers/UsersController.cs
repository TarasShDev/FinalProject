using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using System.Web.Http.Cors;

namespace WebApplication.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [Authorize(Roles = "admin")]
    public class UsersController : ApiController
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> FindByName(string name)
        {
            if (name == null)
                return await GetAll();
            return Ok(_userService.FindByNameAsync(name));
        }

        [HttpGet]
        public async Task<IHttpActionResult> FindById(int id)
        {
            if (id<0)
                return BadRequest("Невалідний ідентифікатор");
            var result = await _userService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
