using System;
using task_cli;


class Program
{
    static void Main()
    {
        var manager = new TaskManager();
        Console.WriteLine("=== Task Tracker CLI ===");
        Console.WriteLine("Type 'help' to see available commands\n");
        Console.WriteLine("Type 'exit' to quit the program\n");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";
            if (input == "")
            {
                continue;
            }
            else if (input == "exit")
            {
                break;
            }

            switch (input)
            {
                case "help":
                    Console.WriteLine("Commands:");
                    Console.WriteLine("add - Add a new task");
                    Console.WriteLine("list - List all tasks");
                    Console.WriteLine("delete <id> - Delete a task");
                    Console.WriteLine("mark-done <id> - Mark a task as done");
                    Console.WriteLine("mark-in-progress <id> - Mark a task as in progress");
                    break;
                case "add":
                    Console.WriteLine("Enter a description:");
                    string description = Console.ReadLine() ?? "";
                    manager.AddTask(description);
                    break;
                case "list":
                    manager.ListTasks();
                    break;
                default:
                    if (input.StartsWith("delete "))
                    {
                        if (int .TryParse(input.Split(' ')[1], out int deleteId))
                        {
                            manager.DeleteTask(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                    }
                    else if (input.StartsWith("mark-done "))
                    {
                        if (int .TryParse(input.Split(' ')[1], out int doneId))
                        {
                            manager.MarkTaskAsDone(doneId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                    }
                    else if (input.StartsWith("mark-in-progress "))
                    {
                        if (int .TryParse(input.Split(' ')[1], out int inProgressId))
                        {
                            manager.MarkTaskAsInProgress(inProgressId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
                    }
                    break;
            }
        }
    }
}