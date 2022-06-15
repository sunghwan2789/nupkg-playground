using System.Runtime.InteropServices;

namespace wrapper;

internal static class RustLibraryWrapper
{
    private const string dllName = "rust_library";

    [DllImport(dllName)]
    public static extern RustLibraryHandle create_handler();

    [DllImport(dllName)]
    public static extern void set_handler_name(RustLibraryHandle handle, [MarshalAs(UnmanagedType.LPStr)] string name);

    [DllImport(dllName)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    public static extern string get_handler_name(RustLibraryHandle handle);

    [DllImport(dllName)]
    public static extern int invoke_handler(RustLibraryHandle handle);

    [DllImport(dllName)]
    public static extern void destroy_handler(RustLibraryHandle handle);
}
