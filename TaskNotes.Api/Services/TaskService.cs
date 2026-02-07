using Microsoft.EntityFrameworkCore;
using TaskNotes.Api.Models;
using TaskNotes.Api.Data;
using TaskNotes.Api.Dtos;

namespace TaskNotes.Api.Services;

public sealed class TaskService : ITaskService
{
    private readonly AppDbContext _db;

    public TaskService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<TaskItemReadDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var items = await _db.TaskItems
            .AsNoTracking()
            .OrderByDescending(item => item.CreatedAtUtc)
            .Select(item => new TaskItemReadDto
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted,
                CreatedAtUtc = item.CreatedAtUtc,
                DueAtUtc = item.DueAtUtc
            })
            .ToListAsync(cancellationToken);

        return items;
    }

}