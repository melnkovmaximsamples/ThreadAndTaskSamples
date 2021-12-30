// 1 - не поймает, т.к. нет await
try
{
    Task.Run(() => throw new Exception(""));

    Console.WriteLine("Exception 1 not handled");
}
catch (Exception ex)
{
    Console.WriteLine("Handled exception 1");
}

// 2 - поймает
try
{
    await Task.Run(() => throw new Exception(""));

    Console.WriteLine("Exception 2 not handled");
}
catch (Exception ex)
{
    Console.WriteLine("Handled exception 2");
}

// 3 - не поймает
try
{
    Task.Run(() => throw new Exception(""))
        .ContinueWith(t =>
        {
            if (t.IsFaulted) throw t.Exception;
        });

    Console.WriteLine("Exception 3 not handled");
}
catch (Exception ex)
{
    Console.WriteLine("Handled exception 3");
}

// 4 - try catch не помает, но при этом выкинет исключение наружу и приложение упадет
// т.к. в async void нет Task, то исключение будет выброшено в контексте SynchronizationContext
try
{
    DoSomething();

    Console.WriteLine("Exception 4 not handled");
}
catch (Exception ex)
{
    Console.WriteLine("Handled exception 4");
}

async void DoSomething()
{
    await Task.Run(() => throw new Exception(""));
}

Console.ReadKey();