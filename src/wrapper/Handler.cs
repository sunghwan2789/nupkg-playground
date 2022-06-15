namespace wrapper;

public class Handler : IDisposable
{
    private readonly RustLibraryHandle _handle;

    public Handler()
    {
        _handle = RustLibraryWrapper.create_handler();
    }

    public string Name
    {
        get => RustLibraryWrapper.get_handler_name(_handle);
        set => RustLibraryWrapper.set_handler_name(_handle, value);
    }

    public int Invoke()
    {
        return RustLibraryWrapper.invoke_handler(_handle);
    }

    public void Dispose()
    {
        using (_handle)
        {
        }
        GC.SuppressFinalize(this);
    }
}
