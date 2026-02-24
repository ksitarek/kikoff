using Kikoff.BuildingBlocks.Modules;
using Kikoff.BuildingBlocks.Modules.Extensions;
using Kikoff.Modules.LoremIpsum.Application;

[assembly: KikoffModule("LoremIpsum")]

namespace Kikoff.Tests.BuildingBlocks.Modules
{
    [Category("Unit")]
    [Category("BuildingBlocks")]
    public class TypeExtensionsTests
    {
        [Test]
        public void Will_Correctly_Extract_Message_ModuleName()
        {
            Assert.That(typeof(KikoffTestMessage).TryGetModuleName(), Is.EqualTo("LoremIpsum"));
        }
    }
}

namespace Kikoff.Modules.LoremIpsum.Application
{
    internal class KikoffTestMessage();
}
