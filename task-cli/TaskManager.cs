using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace task_cli
{
    public class TaskManager
    {
        private readonly string filePath = "tasks.json";
        private List<TaskItem> tasks = new();

        public TaskManager()
        {
            LoadTasks();
        }

        private void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            else
            {
                tasks = new List<TaskItem>();
                SaveTasks();
            }
        }
        private void SaveTasks()
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        public void AddTask(string description)
        {
            var newTask = new TaskItem
            {
                Id = tasks.Count + 1,
                Description = description,
                Status = TaskStatus.Todo,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            tasks.Add(newTask);
            SaveTasks();
            Console.WriteLine($"Task added successfully (ID: {newTask.Id})");
        }
        public void ListTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found");
                return;
            }
            else
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine(task.Id + "." + " " + task.Description + ":" + " " + "[" + " " + task.Status + " " + "]");
                }
                Console.WriteLine();
            }
        }
        public void DeleteTask(int id)
        {
            var task = tasks.Find(task => task.Id == id);
            if (task == null)
            {
                Console.WriteLine("Task with ID: " + id + " not found");
                return;
            }
            else
            {
                tasks.Remove(task);
                SaveTasks();
                Console.WriteLine("Task with ID: " + id + " deleted successfully");
            }
        }
        public void MarkTaskAsDone(int id)
        {
            var task = tasks.Find(task => task.Id == id);
            if (task == null)
            {
                Console.WriteLine("Task with ID: " + id + " not found");
                return;
            }
            else
            {
                task.Status = TaskStatus.Done;
                task.UpdatedAt = DateTime.Now;
                SaveTasks();
                Console.WriteLine("Task with ID: " + id + " marked as done");
            }
        }
        public void MarkTaskAsInProgress(int id)
        {
            var task = tasks.Find(task => task.Id == id);
            if (task == null)
            {
                Console.WriteLine("Task with ID: " + id + " not found");
                return;
            }
            else
            {
                task.Status = TaskStatus.InProgress;
                task.UpdatedAt = DateTime.Now;
                SaveTasks();
                Console.WriteLine("Task with ID: " + id + " marked as in progress");
            }
        }
    }
}