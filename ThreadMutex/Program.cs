// аналог lock, но работает на уровне ОС и может быть использован для блокировки, в нескольких экземплярах приложения
int counter = 0;
var mutex = new Mutex();

for (var i = 0; i < 5; i++)
{
    var thread = new Thread(IncrementCounterWithLocker);
    thread.Name = $"Поток {i}";
    thread.Start();
}

void IncrementCounterWithLocker()
{
    mutex.WaitOne();

    for (var i = 0; i < 10; i++)
    {
        counter++;
        Console.WriteLine($"{Thread.CurrentThread.Name}: {counter}");
        Thread.Sleep(200);
    }

    counter = 0;

    mutex.ReleaseMutex();
}