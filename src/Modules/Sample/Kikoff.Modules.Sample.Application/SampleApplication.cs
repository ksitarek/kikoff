using System.Reflection;
using Kikoff.BuildingBlocks.Modules;

[assembly:KikoffModule("Sample")]

namespace Kikoff.Modules.Sample.Application;

public static class SampleApplication
{
    public static Assembly Assembly => typeof(SampleApplication).Assembly;
}
