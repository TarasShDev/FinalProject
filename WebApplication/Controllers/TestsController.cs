using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.DTO;
using BLL.Interfaces;


namespace WebApplication.Controllers
{
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
            bool isUser=true;
            if(isUser)
            {
                var result = await _testService.GetAllOpenedAsync();
                if (result==null)
                    return NotFound();
                return Ok(result);
            }
            else
            {
                var result = await _testService.GetAllAsync();
                if (result==null)
                    return NotFound();
                return Ok(result);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            bool isUser = true;
            var result = await _testService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            if (isUser)
            {
                if (result.IsOpened == false)
                    return StatusCode(HttpStatusCode.Forbidden);
                return Ok(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByName(string name)
        {
            bool isUser = true;
            if (isUser)
            {
                var result = await _testService.FindOpenedByNameAsync(name);
                if (result == null)
                    return NotFound();
                else
                    return Ok(result);
            }
            else
            {
                var result = await _testService.FindByNameAsync(name);
                if (result == null)
                    return NotFound();
                else
                    return Ok(result);
            }
        }

        [Route("api/tests/{id:int}/start")]
        public async Task<IHttpActionResult> GetFullTestById(int id)
        {
            bool isUser = true;
            if (isUser)
            {
                var result = await _testService.GetByIdDetailedForUserAsync(id);
                if (result == null)
                    return NotFound();
                if (result.IsOpened == false)
                    return StatusCode(HttpStatusCode.Forbidden);
                return Ok(result);
            }
            else
            {
                var result = await _testService.GetByIdDetailedForAdminAsync(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
        }

        [HttpPost]
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
