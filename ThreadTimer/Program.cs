var argument = "Current datetime: ";
var timerCallback = new TimerCallback(PrintDateTimeNow);
var timer = new Timer(timerCallback, argument, 0, 1000);

void PrintDateTimeNow(object argument)
{
    Console.WriteLine($"{argument} {DateTime.Now}");
}

Console.ReadKey();