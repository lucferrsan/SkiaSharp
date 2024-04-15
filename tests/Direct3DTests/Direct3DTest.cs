using System;
using SkiaSharp.Tests;
using Xunit;

namespace SkiaSharp.Direct3D.Tests
{
	public class Direct3DTest : SKTest
	{
		protected Direct3DContext CreateDirect3DContext()
		{
			try
			{
				if (!IsWindows)
					throw new PlatformNotSupportedException();

				return new Win32Direct3DContext();
			}
			catch (Exception ex)
			{
				throw new SkipException($"Unable to create Direct3D context: {ex.Message}");
			}
		}
	}
}
