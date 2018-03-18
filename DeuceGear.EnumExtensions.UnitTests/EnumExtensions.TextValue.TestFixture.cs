using NUnit.Framework;

namespace DeuceGear.UnitTests.EnumExtensions
{
    [TestFixture]
    public partial class EnumExtensionsTestFixture
    {
        [Test]
        public void EnumExtensionsTextValueTestForUnknownValue()
        {
            //assert
            Assert.That(((LeEnum)15).TextValue, Is.EqualTo("15"));
        }

        [Test]
        public void EnumExtensionsTextValueTestForKnownValue()
        {
            //assert
            Assert.That(LeEnum.Empty.TextValue, Is.EqualTo("Empty"));
            Assert.That(LeEnum.Single1.TextValue(), Is.EqualTo("The value of Single1"));
            Assert.That(LeEnum.Single2.TextValue(), Is.EqualTo("The value of Single2"));
            Assert.That(LeEnum.List.TextValue(), Is.EqualTo("The first value of List"));
        }
    }
}
