using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Other;

namespace WebApplication.Controllers
{
    [Authorize]
    [RoutePrefix("api/statistics")]
    public class StatisticsController : ApiController
    {
        private IUserTestService _userTestService;
        private IUserService _userService;

        public StatisticsController(IUserTestService userTestService, IUserService userService)
        {
            _userTestService = userTestService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUserStatistics()
        {
            string userName = User.Identity.Name;
            var user = await _userService.FindUserByName(userName);
            if (user == null)
                return NotFound();
            return Ok(await _userTestService.FindAsync(new SearchParameters() { userId = user.Id }));
        }

        [HttpGet]
        [Route("findall")]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> FindAllStatistics([FromUri]SearchParameters parameters)
        {
            if (parameters == null)
                return Ok(await _userTestService.GetAllAsync());
            return Ok(_userTestService.FindAsync(parameters));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> AddStatistic(UserTestDTO userTest)
        {
            if (userTest == null)
                return BadRequest();
            string userName = User.Identity.Name;
            var user = await _userService.FindUserByName(userName);
            if (user == null)
                return BadRequest();
            try
            {
                await _userTestService.AddAsync(userTest, user.Id);
            }
            catch(ArgumentNullException)
            {
                return BadRequest("Сталася помилка");
            }
            catch(Exception)
            {
                return BadRequest("Сталася помилка");
            }
            return StatusCode(HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> ChangeStatistic(int id, UserTestDTO userTest)
        {
            if (id < 0)
                return BadRequest("Невалідний ідентифікатор");
            if (userTest == null)
                return BadRequest();
            try
            {
                userTest.Id = id;
                await _userTestService.UpdateAsync(userTest);
            }
            catch(ArgumentNullException)
            {
                return BadRequest("Сталася помилка");
            }
            catch(Exception)
            {
                return BadRequest("Сталася помилка");
            }
            return StatusCode(HttpStatusCode.Accepted);
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> DeleteStatistic(int id)
        {
            if(id<0)
                return BadRequest("Невалідний ідентифікатор");
            try
            {
                await _userTestService.DeleteAsync(id);
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return Ok();
        }
    }
}
