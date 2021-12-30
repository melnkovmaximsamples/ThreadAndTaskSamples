var thread = new Thread(new ParameterizedThreadStart(WriteSomething));

//или можно так, компилятор сам создаст ParameterizedThreadStart
//var thread = new Thread(new ParameterizedThreadStart(WriteSomething));

thread.Start("Передана строка");

// в парамтере должен быть тип object и только один параметр
// поэтому если нужно передать несколько параметров, то создаем класс
void WriteSomething(object message)
{
    while (true)
    {
        Console.WriteLine(message);
        Thread.Sleep(5000);
    }
}

Console.ReadKey();