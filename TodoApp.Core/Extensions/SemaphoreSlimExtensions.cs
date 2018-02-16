using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodoApp.Core.Extensions
{
    public static class SemaphoreSlimExtensions
    {
        public static async Task<SemaphoreSlimGuard> WaitAsyncAndGuard(this SemaphoreSlim semaphore)
        {
            await semaphore.WaitAsync();
            return new SemaphoreSlimGuard(semaphore);
        }
        

        /// <summary>
        /// Helper class which releases a SemaphoreSlim once on disposal so it can be used with a using() statement.
        /// </summary>
        public class SemaphoreSlimGuard : IDisposable
        {
            private SemaphoreSlim _guardedSemaphore;

            internal SemaphoreSlimGuard(SemaphoreSlim semaphore)
            {
                _guardedSemaphore = semaphore;
            }
            
            public void Dispose()
            {
                if (_guardedSemaphore != null)
                {
                    _guardedSemaphore.Release();
                    _guardedSemaphore = null;
                }
            }
        }
    }
}
