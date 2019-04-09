using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.DTO;
using BLL.Interfaces;
using System.Web.Http.Cors;


namespace WebApplication.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [Authorize]
    [RoutePrefix("api/tests")]
    public class TestsController : ApiController
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTests()
        {
            var result = await _testService.GetAllOpenedAsync();
            if (result==null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("getall")]
        [Authorize(Roles ="admin")]
        public async Task<IHttpActionResult> GetAllTests()
        {
            var result = await _testService.GetAllAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByName(string name)
        {
            var result = await _testService.FindOpenedByNameAsync(name);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpGet]
        [Route("findall")]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> GetAllByName(string name)
        {
            var result = await _testService.FindByNameAsync(name);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpGet]
        [Route("start/{id:int}")]
        public async Task<IHttpActionResult> GetFullTestById(int id)
        {
            var result = await _testService.GetByIdDetailedForUserAsync(id);
            if (result == null)
                return NotFound();
            if (result.IsOpened == false)
                return StatusCode(HttpStatusCode.Forbidden);
            return Ok(result);
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> GetDetailedTestById(int id)
        {
            var result = await _testService.GetByIdDetailedForAdminAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> AddTest([FromBody] TestDTO test)
        {
            if (test == null)
                return BadRequest();
            try
            {
                await _testService.AddAsync(test);
            }
            catch(ArgumentNullException exc)
            {
                return BadRequest(exc.Message);
            }
            catch(FormatException exc)
            {
                return BadRequest(exc.Message);
            }
            catch(ArgumentOutOfRangeException exc)
            {
                return BadRequest(exc.Message);
            }
            catch(Exception)
            {
                return BadRequest("Сталася помилка");
            }
            return StatusCode(HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> ChangeTest(int id,[FromBody] TestDTO test)
        {
            if (test == null)
                return BadRequest();
            try
            {
                test.Id = id;
                await _testService.UpdateAsync(test);
            }
            catch (ArgumentNullException exc)
            {
                return BadRequest(exc.Message);
            }
            catch (FormatException exc)
            {
                return BadRequest(exc.Message);
            }
            catch (ArgumentOutOfRangeException exc)
            {
                return BadRequest(exc.Message);
            }
            catch (Exception)
            {
                return BadRequest("Сталася помилка");
            }
            return StatusCode(HttpStatusCode.Accepted);
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> DeleteTest(int id)
        {
            try
            {
                await _testService.DeleteAsync(id);
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return StatusCode(HttpStatusCode.OK);
        }
    }
}
