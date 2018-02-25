using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DeuceGear.StringExtensions.UnitTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class StringExtensionsTestFixture
    {
        [Test]
        // zero length case
        [TestCase(null, 0, "")]
        [TestCase("", 0, "")]
        [TestCase("a", 0, "")]
        [TestCase("ab", 0, "")]
        [TestCase("abc", 0, "")]
        [TestCase("abcd", 0, "")]
        // correct length case
        [TestCase(null, 2, "")]
        [TestCase("", 2, "")]
        [TestCase("a", 2, "a")]
        [TestCase("ab", 2, "ab")]
        [TestCase("abc", 2, "ab")]
        [TestCase("abcd", 2, "ab")]
        public void StringExtensionsTestLeft(string value, int length, string expectation)
        {
            // act + arrange
            var result = value.Left(length);

            // assert
            Assert.That(result, Is.EqualTo(expectation));
        }

        // negative length case
        [TestCase(null, -1, "")]
        [TestCase("", -1, "")]
        [TestCase("a", -1, "")]
        [TestCase("ab", -1, "")]
        [TestCase("abc", -1, "")]
        [TestCase("abcd", -1, "")]
        public void StringExtensionsTestLeftException(string value, int length, string expectation)
        {
            // act + arrange
            var result = Assert.Throws<ArgumentException>(() => value.Left(length));

            // assert
            Assert.That(result.Message, Is.EqualTo("Length can not be a negative value"));
        }
    }
}