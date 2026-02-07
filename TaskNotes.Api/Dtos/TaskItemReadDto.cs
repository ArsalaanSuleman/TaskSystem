using System.ComponentModel.DataAnnotations;

namespace TaskNotes.Api.Dtos
{
    public sealed class TaskItemReadDto
    {
        public int Id {get; set;}
        public string? Title {get; set;}
        public bool IsCompleted {get; set;}
        public DateTime CreatedAtUtc {get; set;}
        public DateTime? DueAtUtc {get; set;}
    }
}