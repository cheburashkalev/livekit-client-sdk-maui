
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace LiveKit;

public unsafe struct NativeArray<T> : IDisposable where T : unmanaged
{
    private void* _ptr;
    private int _length;

    public int Length => _length;

    public NativeArray(int length)
    {
        if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));

        _length = length;
        _ptr = (void*)Marshal.AllocHGlobal(length * sizeof(T));
        Unsafe.InitBlockUnaligned(_ptr, 0, (uint)(length * sizeof(T))); // Обнуляем память
    }
    public unsafe void* GetUnsafePtr()
    {
        return _ptr;
    }

    public ref T this[int index]
    {
        get
        {
            if (index < 0 || index >= _length) throw new IndexOutOfRangeException();
            return ref Unsafe.AsRef<T>((byte*)_ptr + index * sizeof(T));
        }
    }

    public void Dispose()
    {
        if (_ptr != null)
        {
            Marshal.FreeHGlobal((IntPtr)_ptr);
            _ptr = null;
            _length = 0;
        }
    }
}

