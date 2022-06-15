using System.Runtime.InteropServices;

namespace wrapper;

internal class RustLibraryHandle : SafeHandle
{
    public RustLibraryHandle()
        : base(IntPtr.Zero, true)
    {
    }

    public override bool IsInvalid => false;

    protected override bool ReleaseHandle()
    {
        RustLibraryWrapper.destroy_handler(this);
        return true;
    }
}
