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
        public void EnumsListLongEnumGenericList()
        {
            // arrange / act
            var result = Enums.EnumList<LongEnum>().ToList();

            // assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(LongEnum.Empty));
            Assert.That(result[1], Is.EqualTo(LongEnum.Single1));
            Assert.That(result[2], Is.EqualTo(LongEnum.Single2));
            Assert.That(result[3], Is.EqualTo(LongEnum.List));
        }

        [Test]
        public void EnumsListLongEnumTypeList()
        {
            // arrange / act
            var result = Enums.EnumList<LongEnum, long>();

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(1));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(3));
        }

        #region Performance
        [Test]
        public void EnumsListLongEnumPerformanceTest() => EnumsListEnumPerformanceTest<LongEnum, long>();

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void EnumsListLongEnumPerformanceTestExcludingTheFirstCall(int testLength) => EnumsListEnumPerformanceTestExcludingTheFirstCall<LongEnum, long>(testLength);
        #endregion Performance
    }
}
