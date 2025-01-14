using System.Runtime.CompilerServices;
using Samples.Probes.TestRuns.Shared;

namespace Samples.Probes.TestRuns.SmokeTests;

public class SimpleTypeNameTest : IRun
{
    public void Run()
    {
        MethodToInstrument(nameof(Run));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [MethodProbeTestData("System.Void", new[] { "System.String" }, useFullTypeName: false)]
    public void MethodToInstrument(string callerName)
    {
        var arr = new[] { callerName, nameof(MethodToInstrument), nameof(SimpleTypeNameTest) };
        if (NoOp(arr).Length == arr.Length)
        {
            throw new IntentionalDebuggerException("Same length.");
        }
    }

    [MethodImpl(MethodImplOptions.NoOptimization)]
    string[] NoOp(string[] arr) => arr;
}
