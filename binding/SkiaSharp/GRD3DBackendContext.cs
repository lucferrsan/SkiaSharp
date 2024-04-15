using System;
using System.Collections.Generic;
using System.Text;

namespace SkiaSharp
{
	public class GRD3DBackendContext : IDisposable
	{
		public nint Adapter { get; set; }
		public nint Device { get; set; }
		public nint Queue { get; set; }
		public bool ProtectedContext { get; set; }

		public void Dispose ()
		{
			// NOTE: for the future
		}

		internal GrD3DBackendContextNative ToNative ()
		{
			return new GrD3DBackendContextNative {
				fAdapter = Adapter,
				fDevice = Device,
				fQueue = Queue,
				fProtectedContext = ProtectedContext ? (byte)1 : (byte)0
			};
		}
	}
}
