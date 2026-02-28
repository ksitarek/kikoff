using Kikoff.BuildingBlocks.Modules;
using Kikoff.BuildingBlocks.Modules.Extensions;

[assembly: KikoffModule("Lorem.Ipsum")]

namespace Kikoff.Tests.BuildingBlocks.Module;

[Category("Unit")]
[Category("BuildingBlocks")]
public class TypeExtensionsTests
{
    [Test]
    public void Will_Correctly_Extract_Message_ModuleName()
    {
        Assert.That(typeof(KikoffTestMessage).TryGetModuleName(), Is.EqualTo("Lorem.Ipsum"));
    }
}

internal class KikoffTestMessage();