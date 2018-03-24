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
        public void EnumsListUShortEnumGenericList()
        {
            // arrange / act
            var result = Enums.EnumList<UShortEnum>().ToList();

            // assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(UShortEnum.Empty));
            Assert.That(result[1], Is.EqualTo(UShortEnum.Single1));
            Assert.That(result[2], Is.EqualTo(UShortEnum.Single2));
            Assert.That(result[3], Is.EqualTo(UShortEnum.List));
        }

        [Test]
        public void EnumsListUShortEnumTypeList()
        {
            // arrange / act
            var result = Enums.EnumList<UShortEnum, ushort>();

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(1));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(3));
        }

        #region Performance
        [Test]
        public void EnumsListUShortEnumPerformanceTest() => EnumsListEnumPerformanceTest<UShortEnum, ushort>();

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void EnumsListUShortEnumPerformanceTestExcludingTheFirstCall(int testLength) => EnumsListEnumPerformanceTestExcludingTheFirstCall<UShortEnum, ushort>(testLength);
        #endregion Performance
    }
}
