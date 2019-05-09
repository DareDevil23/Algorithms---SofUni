namespace ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int tasksCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            HashSet<Task> tasks = new HashSet<Task>();
            for (int i = 0; i < tasksCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                Task task = new Task { Value = int.Parse(tokens[0]), Deadline = int.Parse(tokens[1]) };
                tasks.Add(task);
            }

            int maxDeadLine = tasks.Max(t => t.Deadline);
            List<int> optimalTasks = new List<int>();
            int totalValue = 0;

            for (int i = 0; i < maxDeadLine; i++)
            {
                var mostValuable = tasks
                    .Where(t => !t.IsFinished && t.Deadline > i)
                    .OrderByDescending(t => t.Value/(t.Deadline - i))
                    .First();

                mostValuable.IsFinished = true;
                totalValue += mostValuable.Value;
                optimalTasks.Add(mostValuable.InputNumber);
            }

            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", optimalTasks)}");
            Console.WriteLine($"Total value: {totalValue}");
        }
    }

    class Task
    {
        private static int id = 1;

        public int InputNumber { get; set; } = id++;

        public int Value { get; set; }

        public int Deadline { get; set; }

        public bool IsFinished { get; set; }
    }
}
