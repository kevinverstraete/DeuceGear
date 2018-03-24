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
        public void EnumsListShortEnumGenericList()
        {
            // arrange / act
            var result = Enums.EnumList<ShortEnum>().ToList();

            // assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(ShortEnum.Empty));
            Assert.That(result[1], Is.EqualTo(ShortEnum.Single1));
            Assert.That(result[2], Is.EqualTo(ShortEnum.Single2));
            Assert.That(result[3], Is.EqualTo(ShortEnum.List));
        }

        [Test]
        public void EnumsListShortEnumTypeList()
        {
            // arrange / act
            var result = Enums.EnumList<ShortEnum, short>();

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(1));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(3));
        }

        #region Performance
        [Test]
        public void EnumsListShortEnumPerformanceTest() => EnumsListEnumPerformanceTest<ShortEnum, short>();

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void EnumsListShortEnumPerformanceTestExcludingTheFirstCall(int testLength) => EnumsListEnumPerformanceTestExcludingTheFirstCall<ShortEnum, short>(testLength);
        #endregion Performance
    }
}
