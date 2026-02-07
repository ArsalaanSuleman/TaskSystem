using Microsoft.AspNetCore.Mvc;
using TaskNotes.Api.Dtos;
using TaskNotes.Api.Services;

namespace TaskNotes.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public sealed class TasksController : ControllerBase
{
    private readonly ITaskService _tasks;

    public TasksController(ITaskService tasks)
    {
        _tasks = tasks;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItemReadDto>>> GetAll(CancellationToken cancellationToken)
    {
        var items = await _tasks.GetAllAsync(cancellationToken);
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TaskItemReadDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var item = await _tasks.GetByIdAsync(id, cancellationToken);
        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<TaskItemReadDto>> Create(TaskItemCreateDto input, CancellationToken cancellationToken)
    {
        var created = await _tasks.CreateAsync(input, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TaskItemReadDto>> Update(int id, TaskItemUpdateDto input, CancellationToken cancellationToken)
    {
        var updated = await _tasks.UpdateAsync(id, input, cancellationToken);
        if (updated is null)
        {
            return NotFound();
        }

        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await _tasks.DeleteAsync(id, cancellationToken);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}