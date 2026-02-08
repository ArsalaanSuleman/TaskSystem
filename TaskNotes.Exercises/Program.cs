using System;
using System.Collections.Generic;

var tasks = new Dictionary<int, TaskItem>();

// List version
// var tasks = new List<string>();

var nextId = 1;

while (true)
{
    Console.Write("Type a task or 'list' or 'exit': ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    if (input.Equals("list", StringComparison.OrdinalIgnoreCase))
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks yet.");
            continue;
        }

        // foreach (var pair in tasks)
        // {
        //     var task = pair.Value;
        //     var status = task.IsCompleted ? "done" : "todo";
        //     Console.WriteLine($"{task.Id}: {task.Title} [{status}] (created {task.CreatedUtc:HH:mm})");

        // }

        continue;

        // List version
        // for (var i = 0; i < tasks.Count; i++)
        // {
        //     Console.WriteLine($"{i + 1}. {tasks[i]}");
        // }

        // continue;

        // for (var i = 0; i < tasks.Count; i++)
        // {
        //     Console.WriteLine($"{i + 1}. {tasks[i]}");
        // }

        // continue;

        // foreach (var pair in tasks)
        // {
        //     Console.WriteLine($"{pair.Key}. {pair.Value}");
        // }

        // continue;


    }

    var newTask = new TaskItem
    {
        Id = nextId,
        Title = input.Trim(),
        IsCompleted = false,
        CreatedUtc = DateTime.UtcNow
    };

    tasks[nextId] = newTask;
    Console.WriteLine($"Added task {nextId}.");
    nextId++;

}

    public sealed class TaskItem
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public bool IsCompleted {get; set;}
    public DateTime CreatedUtc { get; init; }
}
