using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
namespace DeuceGear.UnitTests.EnumExtensions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EnumTextValueAttributeTestFixture
    {
        [Test]
        public void EnumValueEnumOperators()
        {
            // arrange
            var @enum = LeEnum.Single1;

            // act
            SafeEnum<LeEnum> safeEnum = @enum;
            LeEnum roundtripEnum = safeEnum;

            // assert
            Assert.That(safeEnum.Equals(@enum));
            Assert.That(@enum.Equals(safeEnum));
            Assert.That(safeEnum == @enum);
            Assert.That((LeEnum)safeEnum, Is.EqualTo(@enum));
            Assert.That(safeEnum.Value, Is.EqualTo(@enum));
            Assert.That(roundtripEnum, Is.EqualTo(@enum));
        }
        [Test]
        public void EnumValueIntOperators()
        {
            // arrange
            var @int = 1;

            // act
            SafeEnum<LeEnum> safeEnum = @int;
            int roundtripInt = safeEnum;

            // assert
            Assert.That(@int.Equals(safeEnum));
            Assert.That(safeEnum.Equals(@int));
            Assert.That(safeEnum == @int);
            Assert.That((int)safeEnum, Is.EqualTo(@int));
            Assert.That((int)safeEnum.Value, Is.EqualTo(@int));
            Assert.That(roundtripInt, Is.EqualTo(@int));
        }

        [Test]
        public void EnumValueCachingTest()
        {
            // arrange
            var @enum = LeCachingEnum.Single1;
            var stopwatch = new Stopwatch();

            // act
            stopwatch.Start();
            SafeEnum<LeCachingEnum> safeEnum1 = @enum;
            stopwatch.Stop();
            var step1 = stopwatch.ElapsedTicks;
            stopwatch.Reset();
            stopwatch.Start();
            SafeEnum<LeCachingEnum> safeEnum2 = @enum;
            stopwatch.Stop();
            var step2 = stopwatch.ElapsedTicks;

            // assert
            Assert.That(step1, Is.GreaterThanOrEqualTo(step2));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void EnumValueValidWithoutFlags(int value)
        {
            // arrange
            var @enum = (LeEnum)value;

            // assert
            SafeEnum<LeEnum> safeEnum1 = @enum;

            // assert
            Assert.That(safeEnum1.Value, Is.EqualTo(@enum));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(4)]
        public void EnumValueInvalidWithoutFlags(int value)
        {
            // arrange
            var @enum = (LeEnum)value;

            // assert
            SafeEnum<LeEnum> safeEnum1;
            var result = Assert.Throws<ArgumentException>(() => safeEnum1 = @enum);

            // assert
            Assert.That(result.Message, Is.EqualTo("T must be a valid enum value"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        public void EnumValueValidWithFlags(int value)
        {
            // arrange
            var @enum = (LeFlaggedEnum)value;

            // assert
            SafeEnum<LeFlaggedEnum> safeEnum1 = @enum;

            // assert
            Assert.That(safeEnum1.Value, Is.EqualTo(@enum));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(16)]
        [TestCase(17)]
        public void EnumValueInvalidWithFlags(int value)
        {
            // arrange
            var @enum = (LeFlaggedEnum)value;

            // assert
            SafeEnum<LeFlaggedEnum> safeEnum1;
            var result = Assert.Throws<ArgumentException>(() => safeEnum1 = @enum);

            // assert
            Assert.That(result.Message, Is.EqualTo("T contains unknown flag values"));
        }

        [Test]
        // x
        [TestCase(0)]  // 0
        [TestCase(1)]  // 1
        [TestCase(3)]  // 1 + 2
        [TestCase(8)]  // 1 + 2 + 5
        [TestCase(18)] // 1 + 2 + 5 + 10
        [TestCase(13)] // 1 + 2 + 10
        [TestCase(6)]  // 1 + 5
        [TestCase(16)] // 1 + 5 + 10
        [TestCase(11)] // 1 + 10
        [TestCase(2)]  // 2
        [TestCase(7)]  // 2 + 5
        [TestCase(17)] // 2 + 5 + 10
        [TestCase(12)] // 2 + 10
        [TestCase(5)]  // 5
        [TestCase(15)] // 5 + 10
        [TestCase(10)] // 10
        public void EnumValueValidWithWeirdFlags(int value)
        {
            // arrange
            var @enum = (LeBadFlaggedEnum)value;

            // assert
            SafeEnum<LeBadFlaggedEnum> safeEnum1 = @enum;

            // assert
            Assert.That(safeEnum1.Value, Is.EqualTo(@enum));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(4)]
        [TestCase(9)]
        [TestCase(14)]
        [TestCase(19)]
        [TestCase(20)]
        public void EnumValueInvalidWithWeirdFlags(int value)
        {
            // arrange
            var @enum = (LeBadFlaggedEnum)value;

            // assert
            SafeEnum<LeBadFlaggedEnum> safeEnum1;
            var result = Assert.Throws<ArgumentException>(() => safeEnum1 = @enum);

            // assert
            Assert.That(result.Message, Is.EqualTo("T contains unknown flag values"));
        }
    }
}
