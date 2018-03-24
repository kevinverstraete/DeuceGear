using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;

namespace DeuceGear.UnitTests.EnumExtensions
{
    [TestFixture]
    public partial class EnumsTestFixture
    {
        private object _performanceLock = new object();

        [Test]
        public void EnumsListByteEnumGenericList()
        {
            // arrange / act
            var result = Enums.EnumList<ByteEnum>().ToList();

            // assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(ByteEnum.Empty));
            Assert.That(result[1], Is.EqualTo(ByteEnum.Single1));
            Assert.That(result[2], Is.EqualTo(ByteEnum.Single2));
            Assert.That(result[3], Is.EqualTo(ByteEnum.List));
        }

        [Test]
        public void EnumsListByteEnumTypeList()
        {
            // arrange / act
            var result = Enums.EnumList<ByteEnum, byte>();

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(1));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(3));
        }

        #region Performance
        [Test]
        public void EnumsListByteEnumPerformanceTest() => EnumsListEnumPerformanceTest<ByteEnum, byte>();

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void EnumsListByteEnumPerformanceTestExcludingTheFirstCall(int testLength) =>  EnumsListEnumPerformanceTestExcludingTheFirstCall<ByteEnum, byte>(testLength);
        #endregion Performance
    }
}
