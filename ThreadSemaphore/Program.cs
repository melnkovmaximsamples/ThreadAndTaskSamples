// объявляем текущее доступное кол-во входов и максимальное. 1 и 3 соответственно
// после запуска всех потоков освобождаем 2 оставшихся входа и выполняют ДЗ уже одновременно 3 ученика
var semaphore = new Semaphore(1, 3);

for (var i = 0; i < 10; i++)
{
    var thread = new Thread(DoHomework);

    thread.Name = $"Поток {i}";
    thread.Start();
}

Thread.Sleep(2000);
semaphore.Release(2);

void DoHomework()
{
    semaphore.WaitOne();

    Console.WriteLine(Thread.CurrentThread.Name);

    Console.WriteLine($"{Thread.CurrentThread.Name}: делаю ДЗ по математике");
    Thread.Sleep(200);

    Console.WriteLine($"{Thread.CurrentThread.Name}: делаю ДЗ по русскому языку");
    Thread.Sleep(200);

    Console.WriteLine($"{Thread.CurrentThread.Name}: делаю ДЗ по информатике");
    Thread.Sleep(5000);

    semaphore.Release();
}