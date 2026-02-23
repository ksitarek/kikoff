using System.Reflection;

namespace Kikoff.Modules.Sample.Application;

public static class SampleApplication
{
    public static Assembly Assembly => typeof(SampleApplication).Assembly;
}
