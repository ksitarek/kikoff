using System.Reflection;
using Kikoff.BuildingBlocks.Modules;

[assembly: KikoffModule("Sample")]

namespace Kikoff.Modules.Sample.Infrastructure;

public static class SampleInfrastructure
{
    public static Assembly Assembly => typeof(SampleInfrastructure).Assembly;
}
