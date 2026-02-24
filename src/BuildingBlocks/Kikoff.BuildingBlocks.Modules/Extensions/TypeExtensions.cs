namespace Kikoff.BuildingBlocks.Modules.Extensions;

public static class TypeExtensions
{
    private static readonly string RootNamespace = ComputeRootNamespace();
    private const string ModulesSegment = "Modules";

    extension(Type type)
    {
        public string TryGetModuleName()
        {
            ReadOnlySpan<char> typeNamespace = (type.Namespace ?? string.Empty).AsSpan();

            if (!typeNamespace.StartsWith(RootNamespace))
            {
                return string.Empty;
            }

            typeNamespace = typeNamespace[RootNamespace.Length..];
            typeNamespace = typeNamespace[..typeNamespace.IndexOf('.')];

            return typeNamespace.ToString();
        }

        private static string ComputeRootNamespace()
        {
            string solutionName = typeof(TypeExtensions).Namespace!.Replace(".BuildingBlocks.Modules.Extensions", string.Empty);
            return $"{solutionName}.{ModulesSegment}.";
        }
    }
}
