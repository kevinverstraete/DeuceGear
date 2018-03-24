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
        // Result: Single use: beter to use typeof(Enum).GetEnumValues
        // Use it in an iteration. The first call will be slower than typeof(Enum).GetEnumValues
        // From that point on, it wil beat typeof(Enum).GetEnumValues() and Enum.GetValues(typeof(LeEnum))
        [Test]
        public void EnumsListUShortEnumPerformanceTest()
        {
            // arrange
            var stopwatch = new Stopwatch();
            var testLength = 20000;

            // act - 1 - Enum.GetValues
            stopwatch.Start();
            for (int i = 0; i < testLength; i++)
            {
                var values = (ushort[])Enum.GetValues(typeof(UShortEnum));
            }
            stopwatch.Stop();
            var enumGetValues = stopwatch.ElapsedTicks;

            // act - 2 - typeof().GetEnumValues
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = (ushort[])typeof(UShortEnum).GetEnumValues();
            }
            stopwatch.Stop();
            var typeofGetValues = stopwatch.ElapsedTicks;

            // act - 3 - deucegear
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = Enums.EnumList<UShortEnum, ushort>();
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
        public void EnumsListUShortEnumPerformanceTestExcludingTheFirstCall(int testLength)
        {
            // arrange
            var stopwatch = new Stopwatch();

            // act - 1 - Enum.GetValues
            var values1 = (ushort[])Enum.GetValues(typeof(UShortEnum));
            stopwatch.Start();
            for (int i = 0; i < testLength; i++)
            {
                var values = (ushort[])Enum.GetValues(typeof(UShortEnum));
            }
            stopwatch.Stop();
            var enumGetValues = stopwatch.ElapsedTicks;

            // act - 2 - typeof().GetEnumValues
            var values2 = (ushort[])typeof(UShortEnum).GetEnumValues();
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = (ushort[])typeof(UShortEnum).GetEnumValues();
            }
            stopwatch.Stop();
            var typeofGetValues = stopwatch.ElapsedTicks;

            // act - 3 - deucegear
            var values3 = Enums.EnumList<UShortEnum, ushort>();
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = Enums.EnumList<UShortEnum, ushort>();
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
