using Microsoft.EntityFrameworkCore;
using TaskNotes.Api.Models;

namespace TaskNotes.Api.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {   
    }

    public DbSet<TaskItem> TaskItems => Set<TaskItem>();
}