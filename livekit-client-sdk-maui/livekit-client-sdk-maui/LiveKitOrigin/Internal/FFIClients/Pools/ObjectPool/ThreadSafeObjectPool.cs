using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Maui.Controls;

namespace LiveKit.Internal.FFIClients.Pools.ObjectPool
{
    public class ThreadSafeObjectPool<T> where T : class
    {
        private readonly Func<T> create;
        private readonly Action<T>? actionOnRelease;
        private readonly ConcurrentBag<T> bag = new();

        public ThreadSafeObjectPool(Func<T> create, Action<T>? actionOnRelease = null)
        {
            this.create = create;
            this.actionOnRelease = actionOnRelease;
        }

        public T Get()
        {
            return bag.TryTake(out var result) 
                ? result!
                : create.Invoke()!;
        }
        public void Return(T element)
        {
            actionOnRelease?.Invoke(element);
            bag.Add(element);
        }
        public void Release(T element)
        {
            Return(element);
        }

        public void Clear()
        {
            bag.Clear();
        }

        public int CountInactive => bag.Count;
    }
}