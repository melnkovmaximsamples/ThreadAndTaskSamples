// Монитор - это обертка над lock. Суть та же, но при использовании код становится более императивным
int counter = 0;
object locker = new object();

for (var i = 0; i < 5; i++)
{
    var thread = new Thread(IncrementCounterWithMonitor);
    thread.Name = $"Поток {i}";
    thread.Start();
}

void IncrementCounterWithMonitor()
{
    var isLocked = false;
    Monitor.Enter(locker, ref isLocked);

    for (var i = 0; i < 10; i++)
    {
        counter++;
        Console.WriteLine($"{Thread.CurrentThread.Name}: {counter}");
        Thread.Sleep(200);
    }

    counter = 0;

    if (isLocked) Monitor.Exit(locker);
}