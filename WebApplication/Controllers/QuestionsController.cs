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
    [Authorize(Roles ="admin")]
    public class QuestionsController : ApiController
    {
        private IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await _questionService.GetByIdAsync(id);
            if (result == null)
                return StatusCode(HttpStatusCode.NotFound);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddQuestion([FromBody] QuestionDTO question)
        {
            if (question == null)
                return StatusCode(HttpStatusCode.BadRequest);
            try
            {
                await _questionService.CreateAsync(question);
            }
            catch (ArgumentNullException exc)
            {
                return BadRequest(exc.Message);
            }
            catch(ArgumentOutOfRangeException exc)
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
            return StatusCode(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IHttpActionResult> ChangeQuestion(int id, [FromBody] QuestionDTO question)
        {
            if (question == null)
                return StatusCode(HttpStatusCode.BadRequest);
            try
            {
                question.Id = id;
                await _questionService.CreateAsync(question);
            }
            catch (ArgumentNullException exc)
            {
                return BadRequest(exc.Message);
            }
            catch (ArgumentOutOfRangeException exc)
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
        public async Task<IHttpActionResult> DeleteQuestion(int id)
        {
            try
            {
                await _questionService.DeleteAsync(id);
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return StatusCode(HttpStatusCode.OK);
        }
    }
}
