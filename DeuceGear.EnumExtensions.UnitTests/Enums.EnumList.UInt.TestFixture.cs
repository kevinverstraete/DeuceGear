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
        public void EnumsListUIntEnumGenericList()
        {
            // arrange / act
            var result = Enums.EnumList<UIntEnum>().ToList();

            // assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(UIntEnum.Empty));
            Assert.That(result[1], Is.EqualTo(UIntEnum.Single1));
            Assert.That(result[2], Is.EqualTo(UIntEnum.Single2));
            Assert.That(result[3], Is.EqualTo(UIntEnum.List));
        }

        [Test]
        public void EnumsListUIntEnumTypeList()
        {
            // arrange / act
            var result = Enums.EnumList<UIntEnum, uint>();

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(1));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(3));
        }

        #region Performance
        [Test]
        public void EnumsListUIntEnumPerformanceTest() => EnumsListEnumPerformanceTest<UIntEnum, uint>();

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void EnumsListUIntEnumPerformanceTestExcludingTheFirstCall(int testLength) => EnumsListEnumPerformanceTestExcludingTheFirstCall<UIntEnum, uint>(testLength);
        #endregion Performance
    }
}
