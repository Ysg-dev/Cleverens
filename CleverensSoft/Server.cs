namespace Composition
{
    public static class Server
    {
        private static int _count;
        private static readonly ReaderWriterLockSlim _rwLock = new ();

        public static int GetCount()
        {
            _rwLock.EnterReadLock();

            try
            {
                return _count;
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            _rwLock.EnterWriteLock();

            try
            {
                _count += value;
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }
    }
}
