using NUnit.Framework;

namespace DeuceGear.UnitTests.EnumExtensions
{
    [TestFixture]
    public partial class EnumTextValueAttributeTestFixture
    {

        [Test]
        public void EnumTextValueAttributeTestCtor()
        {
            // arrange/act
            var result = new EnumTextValueAttribute();

            // assert
            Assert.That(result.Value, Is.EqualTo(string.Empty));
        }

        [Test]
        [TestCase(null)]
        [TestCase("testvalue")]
        public void EnumTextValueAttributeTestCtorWithValue(string value)
        {
            // arrange/act
            var result = new EnumTextValueAttribute(value);

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
            var attrib1 = new EnumTextValueAttribute(value);
            var attrib2 = new EnumTextValueAttribute(second);

            //act
            var result = attrib1.Equals(attrib2);

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void EnumTextValueAttributeTestHashCode()
        {
            // arrange
            var str = "text";

            // act
            var attrib = new EnumTextValueAttribute(str);

            // assert
            Assert.That(attrib.GetHashCode(), Is.EqualTo(str.GetHashCode()));
        }

        [Test]
        public void EnumTextValueAttributeTestDefault()
        {
            // arrange/act
            var attrib1 = new EnumTextValueAttribute(string.Empty);
            var attrib2 = new EnumTextValueAttribute("bob");
            var attrib3 = EnumTextValueAttribute.Default;

            // assert
            Assert.That(attrib1.IsDefaultAttribute, Is.EqualTo(true));
            Assert.That(attrib2.IsDefaultAttribute, Is.EqualTo(false));
            Assert.That(attrib3.IsDefaultAttribute, Is.EqualTo(true));
        }
    }
}
