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

        public AbstractActor()
        {
            _messageBuffer = new BufferBlock<T>();
            _cancellationTokenSource = new CancellationTokenSource();

            var actionBlock = new ActionBlock<T>(HandleMessageAsync, new ExecutionDataflowBlockOptions()
            {
                BoundedCapacity = 5,
                MaxDegreeOfParallelism = 5,
                EnsureOrdered = true,
                CancellationToken = _cancellationTokenSource.Token,
            });

            _messageBuffer.LinkTo(actionBlock);
        }

        public void PostMessage(T message)
        {
            _messageBuffer.Post(message);
        }

        protected abstract Task HandleMessageAsync(T message);

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}
