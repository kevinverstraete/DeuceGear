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
        // Result: Single use: beter to use typeof(Enum).GetEnumValues
        // Use it in an iteration. The first call will be slower than typeof(Enum).GetEnumValues
        // From that point on, it wil beat typeof(Enum).GetEnumValues() and Enum.GetValues(typeof(LeEnum))
        [Test]
        public void EnumsListULongEnumPerformanceTest()
        {
            // arrange
            var stopwatch = new Stopwatch();
            var testLength = 20000;

            // act - 1 - Enum.GetValues
            stopwatch.Start();
            for (int i = 0; i < testLength; i++)
            {
                var values = (ulong[])Enum.GetValues(typeof(ULongEnum));
            }
            stopwatch.Stop();
            var enumGetValues = stopwatch.ElapsedTicks;

            // act - 2 - typeof().GetEnumValues
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = (ulong[])typeof(ULongEnum).GetEnumValues();
            }
            stopwatch.Stop();
            var typeofGetValues = stopwatch.ElapsedTicks;

            // act - 3 - deucegear
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = Enums.EnumList<ULongEnum, ulong>();
            }
            stopwatch.Stop();
            var deucegear = stopwatch.ElapsedTicks;

            // assert
            Console.WriteLine("Enum.GetValues: " + enumGetValues);
            Console.WriteLine("Typeof.GetEnumValues: " + typeofGetValues);
            Console.WriteLine("Deucegear: " + deucegear);
            Assert.That(deucegear, Is.LessThanOrEqualTo(enumGetValues));
            Assert.That(deucegear, Is.LessThanOrEqualTo(typeofGetValues));
        }

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(1000)]
        public void EnumsListULongEnumPerformanceTestExcludingTheFirstCall(int testLength)
        {
            // arrange
            var stopwatch = new Stopwatch();

            // act - 1 - Enum.GetValues
            var values1 = (ulong[])Enum.GetValues(typeof(ULongEnum));
            stopwatch.Start();
            for (int i = 0; i < testLength; i++)
            {
                var values = (ulong[])Enum.GetValues(typeof(ULongEnum));
            }
            stopwatch.Stop();
            var enumGetValues = stopwatch.ElapsedTicks;

            // act - 2 - typeof().GetEnumValues
            var values2 = (ulong[])typeof(ULongEnum).GetEnumValues();
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = (ulong[])typeof(ULongEnum).GetEnumValues();
            }
            stopwatch.Stop();
            var typeofGetValues = stopwatch.ElapsedTicks;

            // act - 3 - deucegear
            var values3 = Enums.EnumList<ULongEnum, ulong>();
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = Enums.EnumList<ULongEnum, ulong>();
            }
            stopwatch.Stop();
            var deucegear = stopwatch.ElapsedTicks;

            // assert
            Console.WriteLine("Enum.GetValues: " + enumGetValues);
            Console.WriteLine("Typeof.GetEnumValues: " + typeofGetValues);
            Console.WriteLine("Deucegear: " + deucegear);
            Assert.That(deucegear, Is.LessThanOrEqualTo(enumGetValues));
            Assert.That(deucegear, Is.LessThanOrEqualTo(typeofGetValues));
        }
        #endregion Performance
    }
}
