using System;
using task_cli;

class Program
{
    static void Main()
    {
        var manager = new TaskManager();
        Console.WriteLine("=== Task Tracker CLI ===");
        Console.WriteLine("Type 'help' to see available commands\n");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (string.IsNullOrEmpty(input))
                continue;

            if (input == "exit" || input == "quit")
                break;

            switch (input)
            {
                case "help":
                    Console.WriteLine("Commands:");
                    Console.WriteLine("  add            - Add a new task");
                    Console.WriteLine("  list           - List all tasks");
                    Console.WriteLine("  delete <id>    - Delete a task");
                    Console.WriteLine("  mark-done <id> - Mark a task as done");
                    Console.WriteLine("  mark-in-progress <id> - Mark a task as in progress");
                    Console.WriteLine("  exit           - Quit the program");
                    break;

                case "add":
                    Console.Write("Enter description: ");
                    string description = Console.ReadLine() ?? "";
                    manager.AddTask(description);
                    break;

                case "list":
                    manager.ListTasks();
                    break;

                default:
                    if (input.StartsWith("delete "))
                    {
                        if (int.TryParse(input.Split(' ')[1], out int deleteId))
                            manager.DeleteTask(deleteId);
                        else
                            Console.WriteLine("Invalid ID format.");
                    }
                    else if (input.StartsWith("mark-done "))
                    {
                        if (int.TryParse(input.Split(' ')[1], out int doneId))
                            manager.MarkTaskAsDone(doneId);
                        else
                            Console.WriteLine("Invalid ID format.");
                    }
                    else if (input.StartsWith("mark-in-progress "))
                    {
                        if (int.TryParse(input.Split(' ')[1], out int progId))
                            manager.MarkTaskAsInProgress(progId);
                        else
                            Console.WriteLine("Invalid ID format.");
                    }
                    else
                    {
                        Console.WriteLine("Unknown command. Type 'help' to see commands.");
                    }
                    break;
            }
        }

        Console.WriteLine("Exiting Task Tracker. Goodbye!");
    }
}
