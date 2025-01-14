using System.Runtime.CompilerServices;

namespace Samples.Probes.TestRuns.SmokeTests;

// Phase 1
[LineProbeTestData(lineNumber: 41, phase: 1)]
[LineProbeTestData(lineNumber: 55, phase: 1)]
[LineProbeTestData(lineNumber: 56, phase: 1)]

// Phase 2
[LineProbeTestData(lineNumber: 41, phase: 2)]
[LineProbeTestData(lineNumber: 55, phase: 2)]
[LineProbeTestData(lineNumber: 56, phase: 2)]
[LineProbeTestData(lineNumber: 57, phase: 2)]
[LineProbeTestData(lineNumber: 58, phase: 2)]

// Phase 3
[LineProbeTestData(lineNumber: 46, phase: 3, expectedNumberOfSnapshots: 3)]
[LineProbeTestData(lineNumber: 59, phase: 3)]

// Phase 4
[LineProbeTestData(lineNumber: 55, phase: 4)]

// Phase 5
[LineProbeTestData(lineNumber: 46, phase: 5, expectedNumberOfSnapshots: 3)]

// Phase 6
// Probe in unreachable branch should not emit any snapshot
[LineProbeTestData(lineNumber: 52, phase: 6, expectedNumberOfSnapshots: 0)]
public class LineProbesWithRevertTest : IRun
{
    public void Run()
    {
        MethodToInstrument(nameof(Run));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [MethodProbeTestData("System.Void", new[] { "System.String" }, phase: 1)]
    public void MethodToInstrument(string callerName)
    {
        int a = callerName.Length;

        int sum = a;
        for (int i = 2; i < a + 2; i++)
        {
            sum *= i;
        }

        if (sum < 10)
        {
            // Unreachable branch
            sum = 0;
        }

        a++;
        a++;
        a++;
        a++;
        a++;
    }
}
