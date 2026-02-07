using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskNotes.Api.Data;
using TaskNotes.Api.Dtos;
using TaskNotes.Api.Services;

namespace TaskNotes.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public sealed class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly ITaskService _tasks;

        public TasksController(ILogger<TasksController> logger, ITaskService tasks)
        {
            _logger = logger;
            _tasks = tasks;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemReadDto>>> GetAll(CancellationToken cancellationToken)
        {
            var items = await _tasks.GetAllAsync(cancellationToken);
            return Ok(items);
        }
    }
}