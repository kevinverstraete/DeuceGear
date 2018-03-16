using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
namespace DeuceGear.UnitTests.EnumExtensions
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EnumValueAttributeTestFixture
    {
        [Test]
        public void Operators()
        {
            // arrange
            var @enum = LeEnum.Single1;

            // act
            SafeEnum<LeEnum> safeEnum = @enum;
            LeEnum roundtripEnum = safeEnum;

            // assert
            Assert.That(safeEnum.Value, Is.EqualTo(@enum));
            Assert.That(roundtripEnum, Is.EqualTo(@enum));
        }
    }
}
