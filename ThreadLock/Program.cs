int counter = 0;
object locker = new object();

for (var i = 0; i < 5; i++)
{
    //var thread = new Thread(IncrementCounter);
    var thread = new Thread(IncrementCounterWithLocker);
    thread.Name = $"Поток {i}";
    thread.Start();
}

void IncrementCounter()
{
    for (var i = 0; i < 10; i++)
    {
        counter++;
        Console.WriteLine($"{Thread.CurrentThread.Name}: {counter}");
        Thread.Sleep(200);
    }

    counter = 0;
}

void IncrementCounterWithLocker()
{
    lock (locker)
    {
        for (var i = 0; i < 10; i++)
        {
            counter++;
            Console.WriteLine($"{Thread.CurrentThread.Name}: {counter}");
            Thread.Sleep(200);
        }

        counter = 0;
    }
}