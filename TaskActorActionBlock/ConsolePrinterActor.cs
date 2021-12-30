using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskActor
{
    public class ConsolePrinterActor : AbstractActor<string>
    { 
        protected override Task HandleMessageAsync(string message)
        {
            Console.WriteLine($"Repeated message: {message}");

            return Task.Delay(1000);
        }
    }
}
