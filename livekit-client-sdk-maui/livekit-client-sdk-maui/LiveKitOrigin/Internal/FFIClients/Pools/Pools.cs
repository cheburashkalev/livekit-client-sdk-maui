using LiveKit.Internal.FFIClients.Pools.ObjectPool;
using LiveKit.Proto;

namespace LiveKit.Internal.FFIClients.Pools//
{
    public static class Pools
    {
        public static ThreadSafeObjectPool<FfiResponse> NewFfiResponsePool()
        {
            return NewClearablePool<FfiResponse>(FfiRequestExtensions.EnsureClean);
        }
        
        public static ThreadSafeObjectPool<T> NewClearablePool<T>(Action<T> ensureClean) where T : class, new()
        {
            return new ThreadSafeObjectPool<T>(
                () => new T(),
                actionOnRelease: ensureClean
            );
        }
    }
}