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
            Console.WriteLine();
        }
        public void UpdateTask(int id, string newDescription)
        {
            var task = tasks.Find(task => task.Id == id);
            if (task == null)
            {
                Console.WriteLine("Task with ID: " + id + " not found");
                return;
            }
            else
            {
                task.Description = newDescription;
                task.UpdatedAt = DateTime.Now;
                SaveTasks();
                Console.WriteLine("Task with ID: " + id + " updated successfully");
            }
            Console.WriteLine();
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
        public void ListDoneTasks()
        {
            var doneTasks = tasks.FindAll(task => task.Status == TaskStatus.Done);
            if (doneTasks.Count == 0)
            {
                Console.WriteLine("No done tasks found");
                return;
            }
            else
            {
                foreach (var task in doneTasks)
                {
                    Console.WriteLine(task.Id + "." + " " + task.Description + ":" + " " + "[" + " " + task.Status + " " + "]");
                }
                Console.WriteLine();
            }
        }
        public void ListInProgressTasks()
        {
            var inProgressTasks = tasks.FindAll(task => task.Status == TaskStatus.InProgress);
            if (inProgressTasks.Count == 0)
            {
                Console.WriteLine("No in-progress tasks found");
                return;
            }
            else
            {
                foreach (var task in inProgressTasks)
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
            Console.WriteLine();
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
            Console.WriteLine();
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
            Console.WriteLine();
        }
    }
}