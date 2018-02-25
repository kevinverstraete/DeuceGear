using NUnit.Framework;

namespace DeuceGear.UnitTests.EnumExtensions
{
    [TestFixture]
    public partial class EnumValueAttributeTestFixture
    {

        [Test]
        public void EnumValueAttributeTestCtor()
        {
            // arrange/act
            var result = new EnumValueAttribute();

            // assert
            Assert.That(result.Value, Is.EqualTo(string.Empty));
        }

        [Test]
        [TestCase(null)]
        [TestCase("testvalue")]
        public void EnumValueAttributeTestCtorWithValue(string value)
        {
            // arrange/act
            var result = new EnumValueAttribute(value);

            // assert
            Assert.That(result.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(null, null, true)]
        [TestCase(null, "", false)]
        [TestCase("", null, false)]
        [TestCase(null, "bob", false)]
        [TestCase("bob", null, false)]
        [TestCase("bobbette", "bob", false)]
        [TestCase("bob", "bobbette", false)]
        [TestCase("bob", "bob", true)]
        public void EnumStringValueAttributeTestEquals(string value, string second, bool expected)
        {
            // arrange
            var attrib1 = new EnumValueAttribute(value);
            var attrib2 = new EnumValueAttribute(second);

            //act
            var result = attrib1.Equals(attrib2);

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void EnumValueAttributeTestHashCode()
        {
            // arrange
            var str = "text";

            // act
            var attrib = new EnumValueAttribute(str);

            // assert
            Assert.That(attrib.GetHashCode(), Is.EqualTo(str.GetHashCode()));
        }

        [Test]
        public void EnumValueAttributeTestDefault()
        {
            // arrange/act
            var attrib1 = new EnumValueAttribute(string.Empty);
            var attrib2 = new EnumValueAttribute("bob");
            var attrib3 = EnumValueAttribute.Default;

            // assert
            Assert.That(attrib1.IsDefaultAttribute, Is.EqualTo(true));
            Assert.That(attrib2.IsDefaultAttribute, Is.EqualTo(false));
            Assert.That(attrib3.IsDefaultAttribute, Is.EqualTo(true));
        }
    }
}
