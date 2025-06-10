namespace Composition
{
    public static class ExecuteTasks
    {
        private const int TASK_READ_COUNT = 5;
        private const int TASK_WRITE_COUNT = 2;
        private const int READ_ITERATIONS = 10;
        private const int WRITE_ITERATIONS = 5;

        public static void ReadWrite()
        {
            Task[] readers = new Task[TASK_READ_COUNT];
            for (int i = 0; i < readers.Length; i++)
            {
                readers[i] = Task.Run(() =>
                {
                    for (int j = 0; j < READ_ITERATIONS; j++)
                    {
                        Console.WriteLine($"Reader {Task.CurrentId}: count = {Server.GetCount()}");
                        Thread.Sleep(100);
                    }
                });
            }

            Task[] writers = new Task[TASK_WRITE_COUNT];

            for (int i = 0; i < writers.Length; i++)
            {
                writers[i] = Task.Run(() =>
                {
                    for (int j = 0; j < WRITE_ITERATIONS; j++)
                    {
                        Server.AddToCount(1);
                        Console.WriteLine($"Writer {Task.CurrentId} added 1 to count.");
                        Thread.Sleep(200);
                    }
                });
            }

            Task.WaitAll(readers);
            Task.WaitAll(writers);
        }
    }
}
