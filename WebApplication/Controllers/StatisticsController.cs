using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTO;
using BLL.Interfaces;

namespace WebApplication.Controllers
{
    public class StatisticsController : ApiController
    {
        private IUserTestService _userTestService;

        public StatisticsController(IUserTestService userTestService)
        {
            _userTestService = userTestService;
        }


    }
}
