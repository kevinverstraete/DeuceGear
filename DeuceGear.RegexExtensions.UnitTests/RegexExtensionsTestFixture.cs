using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace DeuceGear.RegexExtensions.UnitTests
{
    [TestFixture]
    public class RegexExtensionsTestFixture
    {
        private const string phoneNumbers = "050/12.34.56 051/23.45.67 052/15.97.53 053/98.76.54";

        [Test]
        public void RegexExtensionsTestNullObjectThrowsError()
        {
            // arrange
            Match match = null;

            // act
            var result = Assert.Throws<ArgumentNullException>(() => match.GetGroupValue("bob"));

            // assert
            Assert.That(result.ParamName, Is.EqualTo("match"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void RegexExtensionsTestNoNameThrowsError(string name)
        {
            // arrange
            var pattern = @"(\d{3})/(\d{2}.\d{2}.\d{2})"; ;
            var matches = Regex.Matches(phoneNumbers, pattern);

            // act
            var result = Assert.Throws<ArgumentNullException>(() => matches[0].GetGroupValue(name));

            // assert
            Assert.That(result.ParamName, Is.EqualTo("name"));
        }

        [Test]
        public void RegexExtensionsTestGetGroupByName()
        {
            // arrange
            var pattern = @"(?<area>\d{3})/(?<number>\d{2}.\d{2}.\d{2})"; ;
            var matches = Regex.Matches(phoneNumbers, pattern);

            // act/assert
            RegexExtensionsTestGetGroupByNameSingle(matches[0], "050", "12.34.56");
            RegexExtensionsTestGetGroupByNameSingle(matches[1], "051", "23.45.67");
            RegexExtensionsTestGetGroupByNameSingle(matches[2], "052", "15.97.53");
            RegexExtensionsTestGetGroupByNameSingle(matches[3], "053", "98.76.54");
        }

        private void RegexExtensionsTestGetGroupByNameSingle(Match match, string areaExpectation, string numberExpectation)
        {
            // act
            var areaValue = match.GetGroupValue("area");
            var numberValue = match.GetGroupValue("number");
            var emptyValue = match.GetGroupValue("bob");

            // assert
            Assert.That(areaValue, Is.EqualTo(areaExpectation));
            Assert.That(numberValue, Is.EqualTo(numberExpectation));
            Assert.That(emptyValue, Is.EqualTo(string.Empty));
        }
    }
}
