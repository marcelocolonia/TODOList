using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOList.Service.Interfaces;
using TODOList.ViewModels;

namespace TODOList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTasksController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserTaskService _userTaskService;

        public UserTasksController(ILogger<WeatherForecastController> logger,
            IUserTaskService userTaskService
            )
        {
            _logger = logger;
            _userTaskService = userTaskService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserTaskViewModel>> Get()
        {
            var tasks = await _userTaskService.GetUserTasks(new Core.User() { Id = 100 });

            return tasks.Select(x => new UserTaskViewModel()
            {
                Description = x.Description,
                LastUpdate = x.LastUpdate
            });
        }
    }
}
