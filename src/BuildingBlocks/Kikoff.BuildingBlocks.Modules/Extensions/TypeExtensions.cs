using System.Reflection;

namespace Kikoff.BuildingBlocks.Modules.Extensions;

public static class TypeExtensions
{
    private static readonly Dictionary<Assembly, string> ModuleNameCache = new();

    extension(Type type)
    {
        public string TryGetModuleName()
        {
            if (ModuleNameCache.TryGetValue(type.Assembly, out string? moduleName))
            {
                return moduleName;
            }

            ModuleNameCache[type.Assembly] = type.TryGetModuleNameByAttribute();
            return ModuleNameCache[type.Assembly];
        }

        private string TryGetModuleNameByAttribute()
        {
            KikoffModuleAttribute? customAttributes = type.Assembly.GetCustomAttribute<KikoffModuleAttribute>();

            return customAttributes != null
                ? customAttributes.ModuleName
                : string.Empty;
        }
    }
}
