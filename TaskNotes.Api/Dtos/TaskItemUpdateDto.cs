using System.ComponentModel.DataAnnotations;

namespace TaskNotes.Api.Dtos
{
    public sealed class TaskItemUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public DateTime? DueAtUtc { get; set; }
    }
}