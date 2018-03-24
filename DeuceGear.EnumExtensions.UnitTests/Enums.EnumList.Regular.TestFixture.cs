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
        public void EnumsListRegularEnumGenericList()
        {
            // arrange / act
            var result = Enums.EnumList<RegularEnum>().ToList();

            // assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(RegularEnum.Empty));
            Assert.That(result[1], Is.EqualTo(RegularEnum.Single1));
            Assert.That(result[2], Is.EqualTo(RegularEnum.Single2));
            Assert.That(result[3], Is.EqualTo(RegularEnum.List));
        }

        [Test]
        public void EnumsListRegularEnumTypeList()
        {
            // arrange / act
            var result = Enums.EnumList<RegularEnum, int>();

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(1));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(3));
        }

        #region Performance
        [Test]
        public void EnumsListRegularEnumPerformanceTest() => EnumsListEnumPerformanceTest<RegularEnum, int>();

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void EnumsListRegularEnumPerformanceTestExcludingTheFirstCall(int testLength) => EnumsListEnumPerformanceTestExcludingTheFirstCall<RegularEnum, int>(testLength);
        #endregion Performance
    }
}
