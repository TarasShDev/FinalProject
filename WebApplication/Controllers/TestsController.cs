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
        public async Task<IEnumerable<TestDTO>> GetAllTests()
        {
            return (await _testService.GetAllAsync()).ToList();
        }
    }
}
