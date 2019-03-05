using System;
using System.Reflection;
using System.Runtime.Loader;

namespace SimplCommerce.Module.DinkToPdf
{
    /// <summary>
    /// Assembly loader for libwkhtmltox.dll
    /// </summary>
    /// <remarks>
    /// https://github.com/rdvojmoc/DinkToPdf/issues/5#issuecomment-321183899
    /// </remarks>
    internal class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public IntPtr LoadUnmanagedLibrary(string absolutePath)
        {
            return LoadUnmanagedDll(absolutePath);
        }
        protected override IntPtr LoadUnmanagedDll(String unmanagedDllName)
        {
            return LoadUnmanagedDllFromPath(unmanagedDllName);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            throw new NotImplementedException();
        }
    }
}
