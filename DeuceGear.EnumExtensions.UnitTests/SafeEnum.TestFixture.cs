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
        // not working unless someone knows a trick to inherit from enum
        // - @enum.Equals(safeEnum)

        #region RoundTrip
        [Test]
        public void SafeEnumEnumRoundTrip()
        {
            // arrange
            var @enum = RegularEnum.Single1;

            // act
            SafeEnum<RegularEnum> safeEnum = @enum;
            RegularEnum roundtripEnum = safeEnum;

            // assert
            Assert.That(roundtripEnum, Is.EqualTo(@enum));
        }
        [Test]
        public void SafeEnumIntRoundTrip()
        {
            // arrange
            var @int = 1;

            // act
            SafeEnum<RegularEnum> safeEnum = @int;
            int roundtripInt = safeEnum;

            // assert
            Assert.That(roundtripInt, Is.EqualTo(@int));
        }
        #endregion RoundTrip

        #region Caching
        [Test]
        public void SafeEnumCachingTest()
        {
            // arrange
            var @enum = RegularCachingEnum.Single1;
            var stopwatch = new Stopwatch();

            // act
            stopwatch.Start();
            SafeEnum<RegularCachingEnum> safeEnum1 = @enum;
            stopwatch.Stop();
            var step1 = stopwatch.ElapsedTicks;
            stopwatch.Reset();
            stopwatch.Start();
            SafeEnum<RegularCachingEnum> safeEnum2 = @enum;
            stopwatch.Stop();
            var step2 = stopwatch.ElapsedTicks;

            // assert
            Assert.That(step1, Is.GreaterThanOrEqualTo(step2));
        }
        #endregion Caching

        #region Value Validation
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SafeEnumValidWithoutFlags(int value)
        {
            // arrange
            var @enum = (RegularEnum)value;

            // assert
            SafeEnum<RegularEnum> safeEnum1 = @enum;

            // assert
            Assert.That(safeEnum1.Value, Is.EqualTo(@enum));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(4)]
        public void SafeEnumInvalidWithoutFlags(int value)
        {
            // arrange
            var @enum = (RegularEnum)value;

            // assert
            SafeEnum<RegularEnum> safeEnum1;
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
        public void SafeEnumValidWithFlags(int value)
        {
            // arrange
            var @enum = (RegularFlaggedEnum)value;

            // assert
            SafeEnum<RegularFlaggedEnum> safeEnum1 = @enum;

            // assert
            Assert.That(safeEnum1.Value, Is.EqualTo(@enum));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(16)]
        [TestCase(17)]
        public void SafeEnumInvalidWithFlags(int value)
        {
            // arrange
            var @enum = (RegularFlaggedEnum)value;

            // assert
            SafeEnum<RegularFlaggedEnum> safeEnum1;
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
        public void SafeEnumValidWithWeirdFlags(int value)
        {
            // arrange
            var @enum = (RegularBadFlaggedEnum)value;

            // assert
            SafeEnum<RegularBadFlaggedEnum> safeEnum1 = @enum;

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
        public void SafeEnumInvalidWithWeirdFlags(int value)
        {
            // arrange
            var @enum = (RegularBadFlaggedEnum)value;

            // assert
            SafeEnum<RegularBadFlaggedEnum> safeEnum1;
            var result = Assert.Throws<ArgumentException>(() => safeEnum1 = @enum);

            // assert
            Assert.That(result.Message, Is.EqualTo("T contains unknown flag values"));
        }
        #endregion Value Validation

        #region operators
        [Test]
        public void SafeEnumOperators()
        {
            // this test runs scenarios totally unneeded like reversing operations, 
            // but I only did this so i could keep track of all variantions possible.

            // arrange/act
            var enumEmpty = RegularEnum.Empty;
            var enumSingle1 = RegularEnum.Single1;

            var intEmpty = 0;
            var intSingle1 = 1;

            var safeEnumEmpty = new SafeEnum<RegularEnum>(RegularEnum.Empty);
            var safeEnumSingle1 = new SafeEnum<RegularEnum>(RegularEnum.Single1);

            // assert - ==
            Assert.That(intEmpty == (int)enumEmpty, "int == (int)enum");
            Assert.That(intEmpty == (int)safeEnumEmpty, "int == (int)safeEnum");
            Assert.That(intEmpty == safeEnumEmpty, "int == safeEnum");
            Assert.That((int)enumEmpty == intEmpty, "(int)enum == int");
            Assert.That((int)safeEnumEmpty == intEmpty, "(int)safeEnum == int");
            Assert.That(safeEnumEmpty == intEmpty, "safeEnum == int");

            Assert.That(enumEmpty == (RegularEnum)intEmpty, "enum == (LeEnum)int");
            Assert.That(enumEmpty == (RegularEnum)safeEnumEmpty, "enum == (LeEnum)safeEnum");
            Assert.That(enumEmpty == safeEnumEmpty, "enum == safeEnum");
            Assert.That((RegularEnum)intEmpty == enumEmpty, "(LeEnum)int == enum");
            Assert.That((RegularEnum)safeEnumEmpty == enumEmpty, "(LeEnum)safeEnum == enum");
            Assert.That(safeEnumEmpty == enumEmpty, "safeEnum == enum");

            Assert.That(safeEnumEmpty == (SafeEnum<RegularEnum>)intEmpty, "safeEnum == (Safe<T>)int");
            Assert.That(safeEnumEmpty == (SafeEnum<RegularEnum>)enumEmpty, "safeEnum == (Safe<T>)enum");
            Assert.That((SafeEnum<RegularEnum>)intEmpty == safeEnumEmpty, "(Safe<T>)int == safeEnum");
            Assert.That((SafeEnum<RegularEnum>)enumEmpty == safeEnumEmpty, "(Safe<T>)enum == safeEnum");

            // assert - !=
            Assert.That(intEmpty != (int)enumSingle1, "int != (int)enum");
            Assert.That(intEmpty != (int)safeEnumSingle1, "int != (int)safeEnum");
            Assert.That(intEmpty != safeEnumSingle1, "int != safeEnum");
            Assert.That((int)enumEmpty != intSingle1, "(int)enum != int");
            Assert.That((int)safeEnumEmpty != intSingle1, "(int)safeEnum != int");
            Assert.That(safeEnumEmpty != intSingle1, "safeEnum != int");

            Assert.That(enumEmpty != (RegularEnum)intSingle1, "enum != (LeEnum)int");
            Assert.That(enumEmpty != (RegularEnum)safeEnumSingle1, "enum != (LeEnum)safeEnum");
            Assert.That(enumEmpty != safeEnumSingle1, "enum != safeEnum");
            Assert.That((RegularEnum)intEmpty != enumSingle1, "(LeEnum)int != enum");
            Assert.That((RegularEnum)safeEnumEmpty != enumSingle1, "(LeEnum)safeEnum != enum");
            Assert.That(safeEnumEmpty != enumSingle1, "safeEnum != enum");

            Assert.That(safeEnumEmpty != (SafeEnum<RegularEnum>)intSingle1, "safeEnum != (Safe<T>)int");
            Assert.That(safeEnumEmpty != (SafeEnum<RegularEnum>)enumSingle1, "safeEnum != (Safe<T>)enum");
            Assert.That((SafeEnum<RegularEnum>)intEmpty != safeEnumSingle1, "(Safe<T>)int != safeEnum");
            Assert.That((SafeEnum<RegularEnum>)enumEmpty != safeEnumSingle1, "(Safe<T>)enum != safeEnum");

            // assert - <
            Assert.That(intEmpty < (int)enumSingle1, "int < (int)enum");
            Assert.That(intEmpty < (int)safeEnumSingle1, "int < (int)safeEnum");
            Assert.That(intEmpty < safeEnumSingle1, "int < safeEnum");
            Assert.That((int)enumEmpty < intSingle1, "(int)enum < int");
            Assert.That((int)safeEnumEmpty < intSingle1, "(int)safeEnum < int");
            Assert.That(safeEnumEmpty < intSingle1, "safeEnum < int");

            Assert.That(enumEmpty < (RegularEnum)intSingle1, "enum < (LeEnum)int");
            Assert.That(enumEmpty < (RegularEnum)safeEnumSingle1, "enum < (LeEnum)safeEnum");
            Assert.That(enumEmpty < safeEnumSingle1, "enum < safeEnum");
            Assert.That((RegularEnum)intEmpty < enumSingle1, "(LeEnum)int < enum");
            Assert.That((RegularEnum)safeEnumEmpty < enumSingle1, "(LeEnum)safeEnum < enum");
            Assert.That(safeEnumEmpty < enumSingle1, "safeEnum < enum");

            Assert.That(safeEnumEmpty < (SafeEnum<RegularEnum>)intSingle1, "safeEnum < (Safe<T>)int");
            Assert.That(safeEnumEmpty < (SafeEnum<RegularEnum>)enumSingle1, "safeEnum < (Safe<T>)enum");
            Assert.That((SafeEnum<RegularEnum>)intEmpty < safeEnumSingle1, "(Safe<T>)int < safeEnum");
            Assert.That((SafeEnum<RegularEnum>)enumEmpty < safeEnumSingle1, "(Safe<T>)enum < safeEnum");

            // assert - <=
            Assert.That(intEmpty <= (int)enumEmpty, "int <== (int)enum");
            Assert.That(intEmpty <= (int)safeEnumEmpty, "int <== (int)safeEnum");
            Assert.That(intEmpty <= safeEnumEmpty, "int <== safeEnum");
            Assert.That((int)enumEmpty <= intEmpty, "(int)enum <== int");
            Assert.That((int)safeEnumEmpty <= intEmpty, "(int)safeEnum <== int");
            Assert.That(safeEnumEmpty <= intEmpty, "safeEnum <== int");
            Assert.That(intEmpty <= (int)enumSingle1, "int <= (int)enum");
            Assert.That(intEmpty <= (int)safeEnumSingle1, "int <= (int)safeEnum");
            Assert.That(intEmpty <= safeEnumSingle1, "int <= safeEnum");
            Assert.That((int)enumEmpty <= intSingle1, "(int)enum <= int");
            Assert.That((int)safeEnumEmpty <= intSingle1, "(int)safeEnum <= int");
            Assert.That(safeEnumEmpty <= intSingle1, "safeEnum <= int");

            Assert.That(enumEmpty <= (RegularEnum)intEmpty, "enum <== (LeEnum)int");
            Assert.That(enumEmpty <= (RegularEnum)safeEnumEmpty, "enum <== (LeEnum)safeEnum");
            Assert.That(enumEmpty <= safeEnumEmpty, "enum <== safeEnum");
            Assert.That((RegularEnum)intEmpty <= enumEmpty, "(LeEnum)int <== enum");
            Assert.That((RegularEnum)safeEnumEmpty <= enumEmpty, "(LeEnum)safeEnum <== enum");
            Assert.That(safeEnumEmpty <= enumEmpty, "safeEnum <== enum");
            Assert.That(enumEmpty <= (RegularEnum)intSingle1, "enum <= (LeEnum)int");
            Assert.That(enumEmpty <= (RegularEnum)safeEnumSingle1, "enum <= (LeEnum)safeEnum");
            Assert.That(enumEmpty <= safeEnumSingle1, "enum <= safeEnum");
            Assert.That((RegularEnum)intEmpty <= enumSingle1, "(LeEnum)int <= enum");
            Assert.That((RegularEnum)safeEnumEmpty <= enumSingle1, "(LeEnum)safeEnum <= enum");
            Assert.That(safeEnumEmpty <= enumSingle1, "safeEnum <= enum");

            Assert.That(safeEnumEmpty <= (SafeEnum<RegularEnum>)intEmpty, "safeEnum <== (Safe<T>)int");
            Assert.That(safeEnumEmpty <= (SafeEnum<RegularEnum>)enumEmpty, "safeEnum <== (Safe<T>)enum");
            Assert.That((SafeEnum<RegularEnum>)intEmpty <= safeEnumEmpty, "(Safe<T>)int <== safeEnum");
            Assert.That((SafeEnum<RegularEnum>)enumEmpty <= safeEnumEmpty, "(Safe<T>)enum <== safeEnum");
            Assert.That(safeEnumEmpty <= (SafeEnum<RegularEnum>)intSingle1, "safeEnum <= (Safe<T>)int");
            Assert.That(safeEnumEmpty <= (SafeEnum<RegularEnum>)enumSingle1, "safeEnum <= (Safe<T>)enum");
            Assert.That((SafeEnum<RegularEnum>)intEmpty <= safeEnumSingle1, "(Safe<T>)int <= safeEnum");
            Assert.That((SafeEnum<RegularEnum>)enumEmpty <= safeEnumSingle1, "(Safe<T>)enum <= safeEnum");

            // assert - >=
            Assert.That(intEmpty <= (int)enumEmpty, "int <== (int)enum");
            Assert.That(intEmpty <= (int)safeEnumEmpty, "int <== (int)safeEnum");
            Assert.That(intEmpty <= safeEnumEmpty, "int <== safeEnum");
            Assert.That((int)enumEmpty <= intEmpty, "(int)enum <== int");
            Assert.That((int)safeEnumEmpty <= intEmpty, "(int)safeEnum <== int");
            Assert.That(safeEnumEmpty <= intEmpty, "safeEnum <== int");
            Assert.That(intEmpty <= (int)enumSingle1, "int <= (int)enum");
            Assert.That(intEmpty <= (int)safeEnumSingle1, "int <= (int)safeEnum");
            Assert.That(intEmpty <= safeEnumSingle1, "int <= safeEnum");
            Assert.That((int)enumEmpty <= intSingle1, "(int)enum <= int");
            Assert.That((int)safeEnumEmpty <= intSingle1, "(int)safeEnum <= int");
            Assert.That(safeEnumEmpty <= intSingle1, "safeEnum <= int");

            Assert.That(enumEmpty <= (RegularEnum)intEmpty, "enum <== (LeEnum)int");
            Assert.That(enumEmpty <= (RegularEnum)safeEnumEmpty, "enum <== (LeEnum)safeEnum");
            Assert.That(enumEmpty <= safeEnumEmpty, "enum <== safeEnum");
            Assert.That((RegularEnum)intEmpty <= enumEmpty, "(LeEnum)int <== enum");
            Assert.That((RegularEnum)safeEnumEmpty <= enumEmpty, "(LeEnum)safeEnum <== enum");
            Assert.That(safeEnumEmpty <= enumEmpty, "safeEnum <== enum");
            Assert.That(enumEmpty <= (RegularEnum)intSingle1, "enum <= (LeEnum)int");
            Assert.That(enumEmpty <= (RegularEnum)safeEnumSingle1, "enum <= (LeEnum)safeEnum");
            Assert.That(enumEmpty <= safeEnumSingle1, "enum <= safeEnum");
            Assert.That((RegularEnum)intEmpty <= enumSingle1, "(LeEnum)int <= enum");
            Assert.That((RegularEnum)safeEnumEmpty <= enumSingle1, "(LeEnum)safeEnum <= enum");
            Assert.That(safeEnumEmpty <= enumSingle1, "safeEnum <= enum");

            Assert.That(safeEnumEmpty <= (SafeEnum<RegularEnum>)intEmpty, "safeEnum <== (Safe<T>)int");
            Assert.That(safeEnumEmpty <= (SafeEnum<RegularEnum>)enumEmpty, "safeEnum <== (Safe<T>)enum");
            Assert.That((SafeEnum<RegularEnum>)intEmpty <= safeEnumEmpty, "(Safe<T>)int <== safeEnum");
            Assert.That((SafeEnum<RegularEnum>)enumEmpty <= safeEnumEmpty, "(Safe<T>)enum <== safeEnum");
            Assert.That(safeEnumEmpty <= (SafeEnum<RegularEnum>)intSingle1, "safeEnum <= (Safe<T>)int");
            Assert.That(safeEnumEmpty <= (SafeEnum<RegularEnum>)enumSingle1, "safeEnum <= (Safe<T>)enum");
            Assert.That((SafeEnum<RegularEnum>)intEmpty <= safeEnumSingle1, "(Safe<T>)int <= safeEnum");
            Assert.That((SafeEnum<RegularEnum>)enumEmpty <= safeEnumSingle1, "(Safe<T>)enum <= safeEnum");

            // assert - >=
            Assert.That(intSingle1 >= (int)enumSingle1, "int >== (int)enum");
            Assert.That(intSingle1 >= (int)safeEnumSingle1, "int >== (int)safeEnum");
            Assert.That(intSingle1 >= safeEnumSingle1, "int >== safeEnum");
            Assert.That((int)enumSingle1 >= intSingle1, "(int)enum >== int");
            Assert.That((int)safeEnumSingle1 >= intSingle1, "(int)safeEnum >== int");
            Assert.That(safeEnumSingle1 >= intSingle1, "safeEnum >== int");
            Assert.That(intSingle1 >= (int)enumEmpty, "int >= (int)enum");
            Assert.That(intSingle1 >= (int)safeEnumEmpty, "int >= (int)safeEnum");
            Assert.That(intSingle1 >= safeEnumEmpty, "int >= safeEnum");
            Assert.That((int)enumSingle1 >= intEmpty, "(int)enum >= int");
            Assert.That((int)safeEnumSingle1 >= intEmpty, "(int)safeEnum >= int");
            Assert.That(safeEnumSingle1 >= intEmpty, "safeEnum >= int");

            Assert.That(enumSingle1 >= (RegularEnum)intSingle1, "enum >== (LeEnum)int");
            Assert.That(enumSingle1 >= (RegularEnum)safeEnumSingle1, "enum >== (LeEnum)safeEnum");
            Assert.That(enumSingle1 >= safeEnumSingle1, "enum >== safeEnum");
            Assert.That((RegularEnum)intSingle1 >= enumSingle1, "(LeEnum)int >== enum");
            Assert.That((RegularEnum)safeEnumSingle1 >= enumSingle1, "(LeEnum)safeEnum >== enum");
            Assert.That(safeEnumSingle1 >= enumSingle1, "safeEnum >== enum");
            Assert.That(enumSingle1 >= (RegularEnum)intEmpty, "enum >= (LeEnum)int");
            Assert.That(enumSingle1 >= (RegularEnum)safeEnumEmpty, "enum >= (LeEnum)safeEnum");
            Assert.That(enumSingle1 >= safeEnumEmpty, "enum >= safeEnum");
            Assert.That((RegularEnum)intSingle1 >= enumEmpty, "(LeEnum)int >= enum");
            Assert.That((RegularEnum)safeEnumSingle1 >= enumEmpty, "(LeEnum)safeEnum >= enum");
            Assert.That(safeEnumSingle1 >= enumEmpty, "safeEnum >= enum");

            Assert.That(safeEnumSingle1 >= (SafeEnum<RegularEnum>)intSingle1, "safeEnum >== (Safe<T>)int");
            Assert.That(safeEnumSingle1 >= (SafeEnum<RegularEnum>)enumSingle1, "safeEnum >== (Safe<T>)enum");
            Assert.That((SafeEnum<RegularEnum>)intSingle1 >= safeEnumSingle1, "(Safe<T>)int >== safeEnum");
            Assert.That((SafeEnum<RegularEnum>)enumSingle1 >= safeEnumSingle1, "(Safe<T>)enum >== safeEnum");
            Assert.That(safeEnumSingle1 >= (SafeEnum<RegularEnum>)intEmpty, "safeEnum >= (Safe<T>)int");
            Assert.That(safeEnumSingle1 >= (SafeEnum<RegularEnum>)enumEmpty, "safeEnum >= (Safe<T>)enum");
            Assert.That((SafeEnum<RegularEnum>)intSingle1 >= safeEnumEmpty, "(Safe<T>)int >= safeEnum");
            Assert.That((SafeEnum<RegularEnum>)enumSingle1 >= safeEnumEmpty, "(Safe<T>)enum >= safeEnum");

            // assert - >
            Assert.That(intSingle1 > (int)enumEmpty, "int > (int)enum");
            Assert.That(intSingle1 > (int)safeEnumEmpty, "int > (int)safeEnum");
            Assert.That(intSingle1 > safeEnumEmpty, "int > safeEnum");
            Assert.That((int)enumSingle1 > intEmpty, "(int)enum > int");
            Assert.That((int)safeEnumSingle1 > intEmpty, "(int)safeEnum > int");
            Assert.That(safeEnumSingle1 > intEmpty, "safeEnum > int");

            Assert.That(enumSingle1 > (RegularEnum)intEmpty, "enum > (LeEnum)int");
            Assert.That(enumSingle1 > (RegularEnum)safeEnumEmpty, "enum > (LeEnum)safeEnum");
            Assert.That(enumSingle1 > safeEnumEmpty, "enum > safeEnum");
            Assert.That((RegularEnum)intSingle1 > enumEmpty, "(LeEnum)int > enum");
            Assert.That((RegularEnum)safeEnumSingle1 > enumEmpty, "(LeEnum)safeEnum > enum");
            Assert.That(safeEnumSingle1 > enumEmpty, "safeEnum > enum");

            Assert.That(safeEnumSingle1 >= (SafeEnum<RegularEnum>)intEmpty, "safeEnum > (Safe<T>)int");
            Assert.That(safeEnumSingle1 >= (SafeEnum<RegularEnum>)enumEmpty, "safeEnum > (Safe<T>)enum");
            Assert.That((SafeEnum<RegularEnum>)intSingle1 >= safeEnumEmpty, "(Safe<T>)int > safeEnum");
            Assert.That((SafeEnum<RegularEnum>)enumSingle1 >= safeEnumEmpty, "(Safe<T>)enum > safeEnum");
        }
        #endregion operators

        [Test]
        public void SafeEnumEquals()
        {
            // arrange/act
            var enumEmpty = RegularEnum.Empty;

            var intEmpty = 0;

            var safeEnumEmpty = new SafeEnum<RegularEnum>(RegularEnum.Empty);
            var safeEnumSingle1 = new SafeEnum<RegularEnum>(RegularEnum.Single1);

            // equals
            Assert.That(intEmpty.Equals((int)enumEmpty), "int equals (int)enum");
            Assert.That(intEmpty.Equals((int)safeEnumEmpty), "int equals (int)safeEnum");
            Assert.That(intEmpty.Equals(safeEnumEmpty), "int equals safeEnum");
            Assert.That(((int)enumEmpty).Equals(intEmpty), "(int)enum equals int");
            Assert.That(((int)safeEnumEmpty).Equals(intEmpty), "(int)safeEnum equals int");
            Assert.That(safeEnumEmpty.Equals(intEmpty), "safeEnum equals int");

            Assert.That(enumEmpty.Equals((RegularEnum)intEmpty), "enum equals (LeEnum)int");
            Assert.That(enumEmpty.Equals((RegularEnum)safeEnumEmpty), "enum equals (LeEnum)safeEnum");
            Assert.That(enumEmpty.EqualsSafe(safeEnumEmpty), "enum EqualsSafe safeEnum");
            //Assert.That(enumEmpty.Equals(safeEnumEmpty), "enum equals safeEnum"); // yet to fix
            Assert.That(((RegularEnum)intEmpty).Equals(enumEmpty), "(LeEnum)int equals enum");
            Assert.That(((RegularEnum)safeEnumEmpty).Equals(enumEmpty), "(LeEnum)safeEnum equals enum");
            Assert.That((safeEnumEmpty).Equals(enumEmpty), "safeEnum equals enum");

            Assert.That(safeEnumEmpty.Equals((SafeEnum<RegularEnum>)intEmpty), "safeEnum equals (Safe<T>)int");
            Assert.That(safeEnumEmpty.Equals((SafeEnum<RegularEnum>)enumEmpty), "safeEnum equals (Safe<T>)enum");
            Assert.That(((SafeEnum<RegularEnum>)intEmpty).Equals(safeEnumEmpty), "(Safe<T>)int equals safeEnum");
            Assert.That(((SafeEnum<RegularEnum>)enumEmpty).Equals(safeEnumEmpty), "(Safe<T>)enum equals safeEnum");
        }

        #region HashCode
        [Test]
        public void SafeEnumMatchesHashCode()
        {
            // arrange
            var @enum = RegularEnum.Single1;
            var flaggedEnum = RegularFlaggedEnum.Single1;
            var safeEnum = (SafeEnum<RegularEnum>)RegularEnum.Single1;
            var flaggedSafeEnum = (SafeEnum<RegularFlaggedEnum>)RegularFlaggedEnum.Single1;

            // assert
            Assert.That(@enum.GetHashCode(), Is.EqualTo(safeEnum.GetHashCode()));
            Assert.That(flaggedEnum.GetHashCode(), Is.EqualTo(flaggedSafeEnum.GetHashCode()));
        }
        #endregion


        #region HashCode
        [Test]
        public void xx()
        {
            // arrange
            //var @enum = RegularEnum.Single1;
            //var flaggedEnum = RegularFlaggedEnum.Single1;
            //var safeEnum = new SafeEnum<RegularEnum>(RegularEnum.Single1);
            //var flaggedSafeEnum = new SafeEnum<RegularFlaggedEnum>(RegularFlaggedEnum.Single1);

            // assert
            //Assert.That(@enum.GetTypeCode(), Is.EqualTo(safeEnum.GetTypeCode()));
            //Assert.That(flaggedEnum.GetTypeCode(), Is.EqualTo(flaggedSafeEnum.GetTypeCode()));
        }
        #endregion

        // compareTo
        // ToDo:
        // - Enum.Equals (now EqualsSafe)
    }
}