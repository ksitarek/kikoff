using Kikoff.Modules.LoremIpsum.Application;
using Kikoff.BuildingBlocks.Modules.Extensions;

namespace Kikoff.Tests.BuildingBlocks.Modules
{
    [Category("Unit")]
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
