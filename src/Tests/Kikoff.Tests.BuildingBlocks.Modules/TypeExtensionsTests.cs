using Kikoff.BuildingBlocks.Modules;
using Kikoff.BuildingBlocks.Modules.Extensions;
using Kikoff.Modules.Lorem.Ipsum.Application;

[assembly: KikoffModule("Lorem.Ipsum")]

namespace Kikoff.Tests.BuildingBlocks.Modules
{
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
}

namespace Kikoff.Modules.Lorem.Ipsum.Application
{
    internal class KikoffTestMessage();
}
