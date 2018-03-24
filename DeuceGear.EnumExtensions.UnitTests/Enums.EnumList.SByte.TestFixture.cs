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
        public void EnumsListSByteEnumGenericList()
        {
            // arrange / act
            var result = Enums.EnumList<SByteEnum>().ToList();

            // assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(SByteEnum.Empty));
            Assert.That(result[1], Is.EqualTo(SByteEnum.Single1));
            Assert.That(result[2], Is.EqualTo(SByteEnum.Single2));
            Assert.That(result[3], Is.EqualTo(SByteEnum.List));
        }

        [Test]
        public void EnumsListSByteEnumTypeList()
        {
            // arrange / act
            var result = Enums.EnumList<SByteEnum, sbyte>();

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(1));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(3));
        }

        #region Performance
        [Test]
        public void EnumsListSByteEnumPerformanceTest() => EnumsListEnumPerformanceTest<SByteEnum, sbyte>();

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void EnumsListSByteEnumPerformanceTestExcludingTheFirstCall(int testLength) => EnumsListEnumPerformanceTestExcludingTheFirstCall<SByteEnum, sbyte>(testLength);
        #endregion Performance
    }
}
