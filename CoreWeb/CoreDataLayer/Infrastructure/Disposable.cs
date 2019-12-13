using System;
using System.Collections.Generic;
using System.Text;

namespace CoreRepository.Infrastructure
{
    public class Disposable : IDisposable
    {
        
        private bool isDisposed;

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Disposable"/> class.
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }

        // Overrides this to dispose custom objects
        protected virtual void DisposeCore()
        {
        }
    }
}
