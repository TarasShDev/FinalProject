using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;

namespace WebApplication.Controllers
{
    [Authorize(Roles ="admin")]
    public class AnswersController : ApiController
    {
        IAnswerService _answerService;

        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await _answerService.GetByIdAsync(id);
            if (result == null)
                return StatusCode(HttpStatusCode.NotFound);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddAnswer([FromBody] AnswerDTO answer)
        {
            if (answer == null)
                return StatusCode(HttpStatusCode.BadRequest);
            try
            {
                await _answerService.CreateAsync(answer);
            }
            catch(ArgumentNullException exc)
            {
                return BadRequest(exc.Message);
            }
            catch(FormatException exc)
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
        public async Task<IHttpActionResult> ChangeAnswer(int id, [FromBody] AnswerDTO answer)
        {
            if (answer == null)
                return StatusCode(HttpStatusCode.BadRequest);
            try
            {
                answer.Id = id;
                await _answerService.CreateAsync(answer);
            }
            catch (ArgumentNullException exc)
            {
                return BadRequest(exc.Message);
            }
            catch (FormatException exc)
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
        public async Task<IHttpActionResult> DeleteAnswer(int id)
        {
            try
            {
                await _answerService.DeleteAsync(id);
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return StatusCode(HttpStatusCode.OK);
        }
    }
}
