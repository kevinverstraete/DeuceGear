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
        public void EnumsListULongEnumGenericList()
        {
            // arrange / act
            var result = Enums.EnumList<ULongEnum>().ToList();

            // assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(ULongEnum.Empty));
            Assert.That(result[1], Is.EqualTo(ULongEnum.Single1));
            Assert.That(result[2], Is.EqualTo(ULongEnum.Single2));
            Assert.That(result[3], Is.EqualTo(ULongEnum.List));
        }

        [Test]
        public void EnumsListULongEnumTypeList()
        {
            // arrange / act
            var result = Enums.EnumList<ULongEnum, ulong>();

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(1));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(3));
        }

        #region Performance
        [Test]
        public void EnumsListULongEnumPerformanceTest() => EnumsListEnumPerformanceTest<ULongEnum, ulong>();

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void EnumsListULongEnumPerformanceTestExcludingTheFirstCall(int testLength) => EnumsListEnumPerformanceTestExcludingTheFirstCall<ULongEnum, ulong>(testLength);
        #endregion Performance
    }
}
