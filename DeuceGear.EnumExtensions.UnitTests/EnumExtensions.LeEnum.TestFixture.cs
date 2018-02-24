using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DeuceGear.EnumExtensions.UnitTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EnumExtensionsTestFixture
    {
        private enum LeEnum
        {
            Empty,
            [EnumValue("The value of Single1")]
            Single1,
            [EnumValue("The value of Single2")]
            Single2,
            [EnumValue("The first value of List")]
            [EnumValue("The second value of List")]
            [EnumValue("The third value of List")]
            List
        }
    }
}
