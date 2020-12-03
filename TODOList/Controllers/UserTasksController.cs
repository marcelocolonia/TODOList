using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOList.Repository.Entities;
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
            //  todo: get task from context user
            var tasks = await _userTaskService.GetUserTasks(new User() { Id = 100 });

            return tasks.Select(x => new UserTaskViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                LastUpdate = x.LastUpdate
            });
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(NewUserTaskViewModel newUserTaskViewModel)
        {
            try
            {
                var user = await _userTaskService.GetUserById(100); // todo: fetch user from http context

                var response = await _userTaskService.CreateUserTask(user, newUserTaskViewModel.Description);

                return Ok(response);
            }
            catch (Exception)
            {
                //  todo: return a user-friendly error message
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] UserTaskDeleteViewModel model)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
