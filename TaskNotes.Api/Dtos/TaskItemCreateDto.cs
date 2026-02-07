using System.ComponentModel.DataAnnotations;

namespace TaskNotes.Api.Dtos;

public sealed class TaskItemCreateDto
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public DateTime? DueAtUtc { get; set; }
}