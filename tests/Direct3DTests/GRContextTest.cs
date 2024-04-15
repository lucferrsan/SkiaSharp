using System;
using Xunit;
using SkiaSharp.Tests;

namespace SkiaSharp.Direct3D.Tests;

public class GRContextTest : Direct3DTest
{
    [Trait(Traits.Category.Key, Traits.Category.Values.Gpu)]
    [SkippableFact]
    public void CreateD3DContextIsValid()
    {
        using var ctx = CreateDirect3DContext();

        using var grD3DBackendContext = new GRDirect3DBackendContext
        {
            Adapter = ctx.Adapter,
            Device = ctx.Device,
            Queue = ctx.Queue,
            ProtectedContext = false
        };

        Assert.NotNull(grD3DBackendContext);

        using var grContext = GRContext.CreateDirect3D(grD3DBackendContext);

        Assert.NotNull(grContext);
    }

    [Trait(Traits.Category.Key, Traits.Category.Values.Gpu)]
    [SkippableFact]
    public void CreateVkContextWithOptionsIsValid()
    {
    	using var ctx = CreateDirect3DContext();

        using var grD3DBackendContext = new GRDirect3DBackendContext
        {
            Adapter = ctx.Adapter,
            Device = ctx.Device,
            Queue = ctx.Queue,
            ProtectedContext = false
        };

        Assert.NotNull(grD3DBackendContext);

    	var options = new GRContextOptions();

    	using var grContext = GRContext.CreateDirect3D(grD3DBackendContext, options);

    	Assert.NotNull(grContext);
    }
}
