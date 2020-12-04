using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOList.Helpers;
using TODOList.Service.Interfaces;
using TODOList.ViewModels;

namespace TODOList.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserTasksController : ControllerBase
    {
        private readonly ILogger<UserTasksController> _logger;
        private readonly IUserTaskService _userTaskService;

        public UserTasksController(ILogger<UserTasksController> logger,
            IUserTaskService userTaskService
            )
        {
            _logger = logger;
            _userTaskService = userTaskService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserTaskViewModel>> Get()
        {
            try
            {
                var userId = HttpContext.User.GetUserId();

                var tasks = await _userTaskService.GetUserTasks(userId);

                return tasks.Select(x => new UserTaskViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    LastUpdate = x.LastUpdate
                });
            }
            catch (Exception)
            {
                return default;
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(NewUserTaskViewModel newUserTaskViewModel)
        {
            try
            {
                var userId = HttpContext.User.GetUserId();

                var response = await _userTaskService.CreateUserTask(userId, newUserTaskViewModel.Description);

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
                var userId = HttpContext.User.GetUserId();

                await _userTaskService.DeleteUserTask(userId, model.Ids);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
