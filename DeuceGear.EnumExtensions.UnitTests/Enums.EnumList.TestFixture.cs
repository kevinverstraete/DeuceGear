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
        public void EnumsListByteEnumIntListError()
        {
            // arrange / act
            var result = Assert.Throws<NotSupportedException>(() => Enums.EnumList<ByteEnum, int>());

            // assert
            Assert.That(result.Message, Is.EqualTo("DeuceGear.UnitTests.EnumExtensions.ByteEnum can not be converted to a list of type System.Int32"));
        }

        [Test]
        public void EnumsListEnumListTRequiresEnum()
        {
            // arrange / act
            var result = Assert.Throws<ArgumentException>(() => Enums.EnumList<int>());

            // assert
            Assert.That(result.Message, Is.EqualTo("T must be an enumerated type"));
        }

        [Test]
        public void EnumsListEnumListTTRequiresEnum()
        {
            // arrange / act
            var result = Assert.Throws<ArgumentException>(() => Enums.EnumList<int, int>());

            // assert
            Assert.That(result.Message, Is.EqualTo("T must be an enumerated type"));
        }


        #region Performance
        // Result: Single use: beter to use typeof(Enum).GetEnumValues
        // Use it in an iteration. The first call will be slower than typeof(Enum).GetEnumValues
        // From that point on, it wil beat typeof(Enum).GetEnumValues() and Enum.GetValues(typeof(LeEnum))
        private void EnumsListEnumPerformanceTest<Tenum, TdataType>()
             where Tenum : struct, IConvertible
        {
            lock (_performanceLock)
            {
                // arrange
                var stopwatch = new Stopwatch();
                var testLength = 20000;

                // act - 1 - Enum.GetValues
                stopwatch.Start();
                for (int i = 0; i < testLength; i++)
                {
                    var values = (TdataType[])Enum.GetValues(typeof(Tenum));
                }
                stopwatch.Stop();
                var enumGetValues = stopwatch.ElapsedTicks;

                // act - 2 - typeof().GetEnumValues
                stopwatch.Restart();
                for (int i = 0; i < testLength; i++)
                {
                    var values = (TdataType[])typeof(Tenum).GetEnumValues();
                }
                stopwatch.Stop();
                var typeofGetValues = stopwatch.ElapsedTicks;

                // act - 3 - deucegear
                stopwatch.Restart();
                for (int i = 0; i < testLength; i++)
                {
                    var values = Enums.EnumList<Tenum, TdataType>();
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
        }
        
        private void EnumsListEnumPerformanceTestExcludingTheFirstCall<Tenum, TdataType>(int testLength)
             where Tenum : struct, IConvertible
        {
            lock (_performanceLock)
            {
                // arrange
                var stopwatch = new Stopwatch();

                // act - 1 - Enum.GetValues
                var values1 = (TdataType[])Enum.GetValues(typeof(Tenum));
                stopwatch.Start();
                for (int i = 0; i < testLength; i++)
                {
                    var values = (TdataType[])Enum.GetValues(typeof(Tenum));
                }
                stopwatch.Stop();
                var enumGetValues = stopwatch.ElapsedTicks;

                // act - 2 - typeof().GetEnumValues
                var values2 = (TdataType[])typeof(Tenum).GetEnumValues();
                stopwatch.Restart();
                for (int i = 0; i < testLength; i++)
                {
                    var values = (TdataType[])typeof(Tenum).GetEnumValues();
                }
                stopwatch.Stop();
                var typeofGetValues = stopwatch.ElapsedTicks;

                // act - 3 - deucegear
                var values3 = Enums.EnumList<Tenum, TdataType>();
                stopwatch.Restart();
                for (int i = 0; i < testLength; i++)
                {
                    var values = Enums.EnumList<Tenum, TdataType>();
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
        }
        #endregion Performance
    }
}
