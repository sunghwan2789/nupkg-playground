using System.Runtime.InteropServices;

namespace wrapper;

internal static class RustLibraryWrapper
{
    private const string dllName = "rust_library";

    [DllImport(dllName)]
    public static extern RustLibraryHandle handler_create();

    [DllImport(dllName)]
    public static extern void handler_set_name(RustLibraryHandle handle, [MarshalAs(UnmanagedType.LPStr)] string name);

    [DllImport(dllName)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    public static extern string handler_get_name(RustLibraryHandle handle);

    [DllImport(dllName)]
    public static extern int handler_invoke(RustLibraryHandle handle);

    [DllImport(dllName)]
    public static extern void handler_destroy(RustLibraryHandle handle);
}
