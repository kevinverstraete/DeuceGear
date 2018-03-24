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
            Assert.That(((ByteEnum)15).TextValue, Is.EqualTo("15"));
            Assert.That(((IntEnum)15).TextValue, Is.EqualTo("15"));
            Assert.That(((LongEnum)15).TextValue, Is.EqualTo("15"));
            Assert.That(((RegularEnum)15).TextValue, Is.EqualTo("15"));
            Assert.That(((SByteEnum)15).TextValue, Is.EqualTo("15"));
            Assert.That(((ShortEnum)15).TextValue, Is.EqualTo("15"));
            Assert.That(((UIntEnum)15).TextValue, Is.EqualTo("15"));
            Assert.That(((ULongEnum)15).TextValue, Is.EqualTo("15"));
            Assert.That(((UShortEnum)15).TextValue, Is.EqualTo("15"));
        }

        [Test]
        public void EnumExtensionsTextValueTestForKnownValue()
        {
            //assert
            Assert.That(ByteEnum.Empty.TextValue, Is.EqualTo("Empty"));
            Assert.That(ByteEnum.Single1.TextValue(), Is.EqualTo("The value of Single1"));
            Assert.That(ByteEnum.Single2.TextValue(), Is.EqualTo("The value of Single2"));
            Assert.That(ByteEnum.List.TextValue(), Is.EqualTo("The first value of List"));

            Assert.That(IntEnum.Empty.TextValue, Is.EqualTo("Empty"));
            Assert.That(IntEnum.Single1.TextValue(), Is.EqualTo("The value of Single1"));
            Assert.That(IntEnum.Single2.TextValue(), Is.EqualTo("The value of Single2"));
            Assert.That(IntEnum.List.TextValue(), Is.EqualTo("The first value of List"));

            Assert.That(LongEnum.Empty.TextValue, Is.EqualTo("Empty"));
            Assert.That(LongEnum.Single1.TextValue(), Is.EqualTo("The value of Single1"));
            Assert.That(LongEnum.Single2.TextValue(), Is.EqualTo("The value of Single2"));
            Assert.That(LongEnum.List.TextValue(), Is.EqualTo("The first value of List"));

            Assert.That(RegularEnum.Empty.TextValue, Is.EqualTo("Empty"));
            Assert.That(RegularEnum.Single1.TextValue(), Is.EqualTo("The value of Single1"));
            Assert.That(RegularEnum.Single2.TextValue(), Is.EqualTo("The value of Single2"));
            Assert.That(RegularEnum.List.TextValue(), Is.EqualTo("The first value of List"));

            Assert.That(SByteEnum.Empty.TextValue, Is.EqualTo("Empty"));
            Assert.That(SByteEnum.Single1.TextValue(), Is.EqualTo("The value of Single1"));
            Assert.That(SByteEnum.Single2.TextValue(), Is.EqualTo("The value of Single2"));
            Assert.That(SByteEnum.List.TextValue(), Is.EqualTo("The first value of List"));

            Assert.That(ShortEnum.Empty.TextValue, Is.EqualTo("Empty"));
            Assert.That(ShortEnum.Single1.TextValue(), Is.EqualTo("The value of Single1"));
            Assert.That(ShortEnum.Single2.TextValue(), Is.EqualTo("The value of Single2"));
            Assert.That(ShortEnum.List.TextValue(), Is.EqualTo("The first value of List"));

            Assert.That(UIntEnum.Empty.TextValue, Is.EqualTo("Empty"));
            Assert.That(UIntEnum.Single1.TextValue(), Is.EqualTo("The value of Single1"));
            Assert.That(UIntEnum.Single2.TextValue(), Is.EqualTo("The value of Single2"));
            Assert.That(UIntEnum.List.TextValue(), Is.EqualTo("The first value of List"));

            Assert.That(ULongEnum.Empty.TextValue, Is.EqualTo("Empty"));
            Assert.That(ULongEnum.Single1.TextValue(), Is.EqualTo("The value of Single1"));
            Assert.That(ULongEnum.Single2.TextValue(), Is.EqualTo("The value of Single2"));
            Assert.That(ULongEnum.List.TextValue(), Is.EqualTo("The first value of List"));

            Assert.That(UShortEnum.Empty.TextValue, Is.EqualTo("Empty"));
            Assert.That(UShortEnum.Single1.TextValue(), Is.EqualTo("The value of Single1"));
            Assert.That(UShortEnum.Single2.TextValue(), Is.EqualTo("The value of Single2"));
            Assert.That(UShortEnum.List.TextValue(), Is.EqualTo("The first value of List"));
        }
    }
}
