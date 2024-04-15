using Vortice.Direct3D;
using Vortice.Direct3D12;
using Vortice.DXGI;

namespace SkiaSharp.Tests;

public class Win32Direct3DContext : Direct3DContext
{
    public Win32Direct3DContext()
    {
        // Create the device
        var factory = DXGI.CreateDXGIFactory1<IDXGIFactory4>();
        Adapter = GetHardwareAdapter(factory);
        Device = D3D12.D3D12CreateDevice<ID3D12Device>(Adapter, FeatureLevel.Level_11_0);

        // Create the command queue
        var queueDesc = new CommandQueueDescription(CommandListType.Direct);
        Queue = Device.CreateCommandQueue(queueDesc);
    }

	private static IDXGIAdapter1 GetHardwareAdapter(IDXGIFactory4 pFactory)
    {
        for (var adapterIndex = 0; ; adapterIndex++)
        {
            // No more adapters to enumerate.
            if (pFactory.EnumAdapters1(adapterIndex, out var pAdapter).Failure)
                break;

            // Check to see if the adapter supports Direct3D 12.
            if (D3D12.IsSupported(pAdapter, FeatureLevel.Level_11_0))
                return pAdapter;
            
            pAdapter.Release();
        }

        return null;
    }
}
