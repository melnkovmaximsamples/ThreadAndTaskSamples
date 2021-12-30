using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskActor
{
    public abstract class AbstractActor<T>: IDisposable
    {
        private readonly BufferBlock<T> _messageBuffer;
        private readonly CancellationTokenSource _cancellationTokenSource;

        protected abstract int _threadCount { get; }

        public AbstractActor()
        {
            _messageBuffer = new BufferBlock<T>();
            _cancellationTokenSource = new CancellationTokenSource();

            Task.Factory.StartNew(async (_) =>
            {
                var cancellationToken = _cancellationTokenSource.Token;
                var handlers = new List<Task>();

                while (cancellationToken.IsCancellationRequested == false)
                {
                    while (handlers.Count < _threadCount)
                    {
                        handlers.Add(Handle(cancellationToken));
                    }

                    await Task.WhenAny(handlers);
                    handlers.RemoveAll(x => x.IsCompleted);
                }
            }, TaskCreationOptions.LongRunning, _cancellationTokenSource.Token);
        }

        public void PostMessage(T message)
        {
            _messageBuffer.Post(message);
        }

        private async Task Handle(CancellationToken cancellationToken)
        {
            var message = await _messageBuffer.ReceiveAsync(cancellationToken);

            try
            {
                await HandleMessageAsync(message, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected abstract Task HandleMessageAsync(T message, CancellationToken cancellationToken);

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}
