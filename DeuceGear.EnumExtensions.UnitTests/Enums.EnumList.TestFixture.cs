using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;

namespace DeuceGear.UnitTests.EnumExtensions
{
    [TestFixture]
    public partial class EnumsTestFixture
    {
        [Test]
        public void EnumsListByteEnumIntListError()
        {
            // arrange / act
            var result = Assert.Throws<NotSupportedException>(() => Enums.EnumList<ByteEnum, int>());

            // assert
            Assert.That(result.Message, Is.EqualTo("DeuceGear.UnitTests.EnumExtensions.ByteEnum can not be converted to a list of type System.Int32"));
        }

        [Test]
        public void EnumsListEnumListTRequiresEnum()
        {
            // arrange / act
            var result = Assert.Throws<ArgumentException>(() => Enums.EnumList<int>());

            // assert
            Assert.That(result.Message, Is.EqualTo("T must be an enumerated type"));
        }

        [Test]
        public void EnumsListEnumListTTRequiresEnum()
        {
            // arrange / act
            var result = Assert.Throws<ArgumentException>(() => Enums.EnumList<int, int>());

            // assert
            Assert.That(result.Message, Is.EqualTo("T must be an enumerated type"));
        }
    }
}
