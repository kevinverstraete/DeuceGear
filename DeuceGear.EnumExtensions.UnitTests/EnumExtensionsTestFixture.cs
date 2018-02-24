using NUnit.Framework;
using System.Linq;

namespace DeuceGear.EnumExtensions.UnitTests
{
    [TestFixture]
    public class EnumExtensionsTestFixture
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

        [Test]
        public void EnumExtensionsValuesTestForUnknownValue()
        {
            // arrange/Act
            var unknownValue = ((LeEnum)13).Values().ToList();

            // assert
            Assert.That(unknownValue.Count(), Is.EqualTo(0));
        }


        [Test]
        public void EnumExtensionsValuesTestForEmptyValue()
        {
            // arrange/Act
            var emptyValue = LeEnum.Empty.Values().ToList();

            // assert
            Assert.That(emptyValue.Count(), Is.EqualTo(0));
        }

        [Test]
        public void EnumExtensionsValuesTestForKnownSingleValue()
        {
            // arrange/Act
            var values = LeEnum.Single1.Values().ToList();

            // assert
            Assert.That(values.Count(), Is.EqualTo(1));
            Assert.That(values[0], Is.EqualTo("The value of Single1"));
        }

        [Test]
        public void EnumExtensionsValuesTestForKnownValue()
        {
            // arrange/Act
            var listValues = LeEnum.List.Values().ToList();

            // assert

            Assert.That(listValues.Count(), Is.EqualTo(3));
            Assert.That(listValues[0], Is.EqualTo("The first value of List"));
            Assert.That(listValues[1], Is.EqualTo("The second value of List"));
            Assert.That(listValues[2], Is.EqualTo("The third value of List"));
        }

        private enum LeEnum
        {
            Empty,
            [EnumValue("The value of Single1")]
            Single1,
            [EnumValue("The value of Single2")]
            Single2,
            [EnumValue("The first value of List")]
            [EnumValue("The second value of List")]
            [EnumValue("The third value of List")]
            List
        }
    }
}
