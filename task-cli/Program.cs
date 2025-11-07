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
                    Console.WriteLine("- add - Add a new task");
                    Console.WriteLine("- update <id> - Update a task's description");
                    Console.WriteLine("- list - List all tasks");
                    Console.WriteLine("- list-done - List all done tasks");
                    Console.WriteLine("- list-in-progress - List all in-progress tasks");
                    Console.WriteLine("- delete <id> - Delete a task");
                    Console.WriteLine("- mark-done <id> - Mark a task as done");
                    Console.WriteLine("- mark-in-progress <id> - Mark a task as in progress");
                    Console.WriteLine("- exit - Exit the program");
                    Console.WriteLine("");
                    break;

                case "add":
                    Console.WriteLine("Enter a description:");
                    string description = Console.ReadLine() ?? "";
                    manager.AddTask(description);
                    break;

                case "update":
                    Console.WriteLine("Enter task ID to update:");
                    if (int .TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.WriteLine("Enter new description:");
                        string newDescription = Console.ReadLine() ?? "";
                        manager.UpdateTask(updateId, newDescription);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format.");
                    }
                    break;

                case "list":
                    manager.ListTasks();
                    break;

                case "list-done":
                    manager.ListDoneTasks();
                    break;

                case "list-in-progress":
                    manager.ListInProgressTasks();
                    break;

                case "delete":
                    Console.WriteLine("Enter task ID to delete:");
                    if (int .TryParse(Console.ReadLine(), out int deleteId))
                    {
                        manager.DeleteTask(deleteId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format.");
                    }
                    break;

                case "mark-done":
                    Console.WriteLine("Enter task ID to mark as done:");
                    if (int .TryParse(Console.ReadLine(), out int doneId))
                    {
                        manager.MarkTaskAsDone(doneId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format.");
                    }
                    break;

                case "mark-in-progress":
                    Console.WriteLine("Enter task ID to mark as in progress:");
                    if (int .TryParse(Console.ReadLine(), out int inProgressId))
                    {
                        manager.MarkTaskAsInProgress(inProgressId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format.");
                    }
                    break;

                default:
                        Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
                    break;
            }
        }
    }
}