using NUnit.Framework;
using System.Linq;

namespace DeuceGear.EnumExtensions.UnitTests
{
    [TestFixture]
    public partial class EnumExtensionsTestFixture
    {
        [Test]
        public void EnumExtensionsValueTestForUnknownValue()
        {
            //assert
            Assert.That(((LeEnum)15).Value, Is.EqualTo("15"));
        }

        [Test]
        public void EnumExtensionsValueTestForKnownValue()
        {
            //assert
            Assert.That(LeEnum.Empty.Value, Is.EqualTo("Empty"));
            Assert.That(LeEnum.Single1.Value(), Is.EqualTo("The value of Single1"));
            Assert.That(LeEnum.Single2.Value(), Is.EqualTo("The value of Single2"));
            Assert.That(LeEnum.List.Value(), Is.EqualTo("The first value of List"));
        }
    }
}
