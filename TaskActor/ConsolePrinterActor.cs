using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskActor
{
    public class ConsolePrinterActor : AbstractActor<string>
    {
        protected override int _threadCount => 1;

        protected override Task HandleMessageAsync(string message, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Repeated message: {message}");

            return Task.Delay(1000);
        }
    }
}
