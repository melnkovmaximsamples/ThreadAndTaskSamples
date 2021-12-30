var thread = new Thread(new ThreadStart(WriteSomething));
//или можно так, компилятор сам создаст ThreadStart
//var thread = new Thread(new ThreadStart(WriteSomething));
thread.Start();


void WriteSomething()
{
    while (true)
    {
        Console.WriteLine("Hello from second thread!!");
        Thread.Sleep(5000);
    }
}

Console.ReadKey();