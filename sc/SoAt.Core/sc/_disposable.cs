namespace sc
{
    public class _disposable : IDisposable
    {
        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) onDispose();
            disposed = true;
        }

        protected virtual void onDispose() { }
    }
}
