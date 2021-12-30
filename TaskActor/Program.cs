using TaskActor;

var consoleRepeatActor = new ConsolePrinterActor();

for (var i = 0; i < 1000; i ++)
{
    consoleRepeatActor.PostMessage($"Message number [{i + 1}]");
}

Console.ReadKey();