using System;
using Vortice.Direct3D12;
using Vortice.DXGI;

namespace SkiaSharp.Tests
{
	public class Direct3DContext : IDisposable
	{
        public virtual IDXGIAdapter1 Adapter { get; protected set; }

        public virtual ID3D12Device Device { get; protected set; }
        
        public virtual ID3D12CommandQueue Queue { get; protected set; }

		public virtual void Dispose()
        {
            Queue.Dispose();
            Device.Dispose();
            Adapter.Dispose();
        }            
	}
}
