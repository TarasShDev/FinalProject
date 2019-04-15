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
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [Authorize]
    public class QuestionsController : ApiController
    {
        private IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await _questionService.GetByIdAsync(id);
            if (result == null)
                return StatusCode(HttpStatusCode.NotFound);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> AddQuestion([FromBody] QuestionDTO question)
        {
            if (question == null)
                return StatusCode(HttpStatusCode.BadRequest);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
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
                return BadRequest();
            }
            return StatusCode(HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> ChangeQuestion(int id, [FromBody] QuestionDTO question)
        {
            if (question == null)
                return StatusCode(HttpStatusCode.BadRequest);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                question.Id = id;
                await _questionService.UpdateAsync(question);
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
        [Authorize(Roles = "admin")]
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
