var thread = Thread.CurrentThread;

Console.WriteLine($"Thread name: {thread.Name}");
thread.Name = "Main";
Console.WriteLine($"New thread name: {thread.Name}");
Console.WriteLine($"Is alive: {thread.IsAlive}");
Console.WriteLine($"Is background: {thread.IsBackground}");
Console.WriteLine($"Is thread pool thread: {thread.IsThreadPoolThread}");
Console.WriteLine($"Managed thread id: {thread.ManagedThreadId}");
Console.WriteLine($"Priority: {thread.Priority}");
Console.WriteLine($"Thread state: {thread.ThreadState}");
Console.WriteLine($"Application domain: {Thread.GetDomain().FriendlyName}");

Console.ReadKey();