using System.Reflection;

namespace Kikoff.BuildingBlocks.Modules.Extensions;

public static class TypeExtensions
{
    extension(Type type)
    {
        public string TryGetModuleName()
        {
            KikoffModuleAttribute? customAttributes = type.Assembly.GetCustomAttribute<KikoffModuleAttribute>();

            return customAttributes != null
                ? customAttributes.ModuleName
                : string.Empty;
        }
    }
}
