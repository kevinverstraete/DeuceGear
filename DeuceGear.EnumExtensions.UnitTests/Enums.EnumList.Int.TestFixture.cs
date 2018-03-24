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
        public void EnumsListIntEnumGenericList()
        {
            // arrange / act
            var result = Enums.EnumList<IntEnum>().ToList();

            // assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(IntEnum.Empty));
            Assert.That(result[1], Is.EqualTo(IntEnum.Single1));
            Assert.That(result[2], Is.EqualTo(IntEnum.Single2));
            Assert.That(result[3], Is.EqualTo(IntEnum.List));
        }

        [Test]
        public void EnumsListIntEnumTypeList()
        {
            // arrange / act
            var result = Enums.EnumList<IntEnum, int>();

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(1));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(3));
        }

        #region Performance
        [Test]
        public void EnumsListIntEnumPerformanceTest() => EnumsListEnumPerformanceTest<IntEnum, int>();

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void EnumsListIntEnumPerformanceTestExcludingTheFirstCall(int testLength) => EnumsListEnumPerformanceTestExcludingTheFirstCall<IntEnum, int>(testLength);
        #endregion Performance
    }
}
