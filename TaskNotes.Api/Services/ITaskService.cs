using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNotes.Api.Dtos;

namespace TaskNotes.Api.Services
{
    public interface ITaskService
    {
        Task<IReadOnlyList<TaskItemReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TaskItemReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<TaskItemReadDto> CreateAsync(TaskItemCreateDto input, CancellationToken cancellationToken);
         Task<TaskItemReadDto?> UpdateAsync(int id, TaskItemUpdateDto input, CancellationToken cancellationToken);
         Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}