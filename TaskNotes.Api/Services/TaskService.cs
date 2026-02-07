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

    public async Task<TaskItemReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var item = await _db.TaskItems
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        if (item is null)
        {
            return null;    
        } 

        return new TaskItemReadDto
        {
            Id = item.Id,
            Title = item.Title,
            IsCompleted = item.IsCompleted,
            CreatedAtUtc = item.CreatedAtUtc,
            DueAtUtc = item.DueAtUtc
        };
    }

    public async Task<TaskItemReadDto> CreateAsync(TaskItemCreateDto input, CancellationToken cancellationToken)
    {
        var item = new TaskItem
        {
            Title = input.Title.Trim(),
            IsCompleted = false,
            CreatedAtUtc = DateTime.UtcNow,
            DueAtUtc = input.DueAtUtc
        };

        _db.TaskItems.Add(item);
        await _db.SaveChangesAsync(cancellationToken);

        return new TaskItemReadDto
        {
            Id = item.Id,
            Title = item.Title,
            IsCompleted = item.IsCompleted,
            CreatedAtUtc = item.CreatedAtUtc,
            DueAtUtc = item.DueAtUtc
        };
    }

    public async Task<TaskItemReadDto?> UpdateAsync(int id, TaskItemUpdateDto input, CancellationToken cancellationToken)
    {
        var item = await _db.TaskItems.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        if (item is null)
        {
            return null;
        }

        item.Title = input.Title.Trim();
        item.IsCompleted = input.IsCompleted;
        item.DueAtUtc = input.DueAtUtc;

        await _db.SaveChangesAsync(cancellationToken);

        return new TaskItemReadDto
        {
            Id = item.Id,
            Title = item.Title,
            IsCompleted = item.IsCompleted,
            CreatedAtUtc = item.CreatedAtUtc,
            DueAtUtc = item.DueAtUtc
        };
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var item = await _db.TaskItems.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        if (item is null)
        {
            return false;
        }

        _db.TaskItems.Remove(item);
        await _db.SaveChangesAsync(cancellationToken);

        return true;
    }
}