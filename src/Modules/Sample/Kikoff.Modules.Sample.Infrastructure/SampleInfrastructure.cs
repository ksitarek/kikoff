using System.Reflection;

namespace Kikoff.Modules.Sample.Infrastructure;

public static class SampleInfrastructure
{
    public static Assembly Assembly => typeof(SampleInfrastructure).Assembly;
}
