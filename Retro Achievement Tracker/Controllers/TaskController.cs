using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Controllers
{
    public class TaskController
    {
        private SemaphoreSlim semaphore;
        public TaskController()
        {
            semaphore = new SemaphoreSlim(1);
        }
        public async Task Enqueue(Func<Task> taskGenerator)
        {
            await semaphore.WaitAsync();
            try
            {
                await Task.Delay(200).ContinueWith(async result => await taskGenerator());
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
