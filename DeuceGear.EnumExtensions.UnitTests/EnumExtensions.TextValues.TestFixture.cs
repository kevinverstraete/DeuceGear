using NUnit.Framework;
using System.Linq;

namespace DeuceGear.UnitTests.EnumExtensions
{
    [TestFixture]
    public partial class EnumExtensionsTestFixture
    {
        [Test]
        public void EnumExtensionsTextValuesTestForUnknownValue()
        {
            // arrange/Act
            var unknownValue = ((RegularEnum)13).TextValues().ToList();

            // assert
            Assert.That(unknownValue.Count(), Is.EqualTo(0));
        }

        [Test]
        public void EnumExtensionsTextValuesTestForEmptyValue()
        {
            // arrange/Act
            var emptyValue = RegularEnum.Empty.TextValues().ToList();

            // assert
            Assert.That(emptyValue.Count(), Is.EqualTo(0));
        }

        [Test]
        public void EnumExtensionsTextValuesTestForKnownSingleValue()
        {
            // arrange/Act
            var values = RegularEnum.Single1.TextValues().ToList();

            // assert
            Assert.That(values.Count(), Is.EqualTo(1));
            Assert.That(values[0], Is.EqualTo("The value of Single1"));
        }

        [Test]
        public void EnumExtensionsTextValuesTestForKnownValue()
        {
            // arrange/Act
            var listValues = RegularEnum.List.TextValues().ToList();

            // assert

            Assert.That(listValues.Count(), Is.EqualTo(3));
            Assert.That(listValues[0], Is.EqualTo("The first value of List"));
            Assert.That(listValues[1], Is.EqualTo("The second value of List"));
            Assert.That(listValues[2], Is.EqualTo("The third value of List"));
        }
    }
}
