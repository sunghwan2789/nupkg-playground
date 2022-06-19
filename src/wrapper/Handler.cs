namespace wrapper;

public class Handler : IDisposable
{
    private readonly RustLibraryHandle _handle;

    public Handler()
    {
        _handle = RustLibraryWrapper.handler_create();
    }

    public string Name
    {
        get => RustLibraryWrapper.handler_get_name(_handle);
        set => RustLibraryWrapper.handler_set_name(_handle, value);
    }

    public int Invoke()
    {
        return RustLibraryWrapper.handler_invoke(_handle);
    }

    public void Dispose()
    {
        using (_handle)
        {
        }
        GC.SuppressFinalize(this);
    }
}
