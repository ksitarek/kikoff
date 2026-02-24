namespace Kikoff.BuildingBlocks.Modules;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class)]
public class KikoffModuleAttribute : Attribute
{
    public string ModuleName { get; }

    public KikoffModuleAttribute(string moduleName)
    {
        ModuleName = moduleName;
    }
}
