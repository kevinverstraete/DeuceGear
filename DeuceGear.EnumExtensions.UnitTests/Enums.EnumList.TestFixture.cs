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
        public void EnumsEnumIntListGeneric()
        {
            // arrange / act
            var result = Enums.EnumIntList<LeEnum>();

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(1));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(3));
        }

        [Test]
        public void EnumsEnumListGeneric()
        {
            // arrange / act
            var result = Enums.EnumList<LeEnum>().ToList();

            // assert
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(LeEnum.Empty));
            Assert.That(result[1], Is.EqualTo(LeEnum.Single1));
            Assert.That(result[2], Is.EqualTo(LeEnum.Single2));
            Assert.That(result[3], Is.EqualTo(LeEnum.List));
        }

        [Test]
        public void EnumsEnumIntListGenericRequiresEnum()
        {
            // arrange / act
            var result = Assert.Throws<ArgumentException>(() => Enums.EnumIntList<int>());

            // assert
            Assert.That(result.Message, Is.EqualTo("T must be an enumerated type"));
        }

        [Test]
        public void EnumsEnumListGenericRequiresEnum()
        {
            // arrange / act
            var result = Assert.Throws<ArgumentException>(() => Enums.EnumList<int>());

            // assert
            Assert.That(result.Message, Is.EqualTo("T must be an enumerated type"));
        }


        #region Performance
        // Result: Single use: beter to use typeof(LeEnum).GetEnumValues
        // Use it in an iteration. The first call will be slower than typeof(LeEnum).GetEnumValues
        // From that point on, it wil beat typeof(LeEnum).GetEnumValues() and Enum.GetValues(typeof(LeEnum))
        [Test]
        public void EnumExtensionsEnumListIntPerformanceTest()
        {
            // arrange
            var stopwatch = new Stopwatch();
            var testLength = 20000;

            // act - 1 - Enum.GetValues
            stopwatch.Start();
            for (int i = 0; i < testLength; i++)
            {
                var values = (int[])Enum.GetValues(typeof(LeEnum));
            }
            stopwatch.Stop();
            var enumGetValues = stopwatch.ElapsedTicks;

            // act - 2 - typeof().GetEnumValues
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = (int[])typeof(LeEnum).GetEnumValues();
            }
            stopwatch.Stop();
            var typeofGetValues = stopwatch.ElapsedTicks;

            // act - 3 - deucegear
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = Enums.EnumIntList<LeEnum>();
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
        public void EnumExtensionsEnumListIntPerformanceTestExcludingTheFirstCall(int testLength)
        {
            // arrange
            var stopwatch = new Stopwatch();

            // act - 1 - Enum.GetValues
            var values1 = (int[])Enum.GetValues(typeof(LeEnum));
            stopwatch.Start();
            for (int i = 0; i < testLength; i++)
            {
                var values = (int[])Enum.GetValues(typeof(LeEnum));
            }
            stopwatch.Stop();
            var enumGetValues = stopwatch.ElapsedTicks;

            // act - 2 - typeof().GetEnumValues
            var values2 = (int[])typeof(LeEnum).GetEnumValues();
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = (int[])typeof(LeEnum).GetEnumValues();
            }
            stopwatch.Stop();
            var typeofGetValues = stopwatch.ElapsedTicks;

            // act - 3 - deucegear
            var values3 = Enums.EnumIntList<LeEnum>();
            stopwatch.Restart();
            for (int i = 0; i < testLength; i++)
            {
                var values = Enums.EnumIntList<LeEnum>();
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
