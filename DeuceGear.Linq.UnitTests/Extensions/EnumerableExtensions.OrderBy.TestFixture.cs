using System.Collections.Generic;
using System.Linq;
using DeuceGear.Linq;
using NUnit.Framework;

namespace DeuceGear.UnitTests.Linq.Extensions
{
    [TestFixture]
    public class EnumerableExtensionsOrderByTestFixture
    {
        private static IEnumerable<TestCaseData> ExtensionsTestSortingAscendingData()
        {
            yield return new TestCaseData("enum",TestData.List.AsEnumerable().OrderBy(c => c.LastName, SortDirection.Ascending).ToList());
            yield return new TestCaseData("query",  TestData.List.OrderBy(c => c.LastName, SortDirection.Ascending).ToList());
        }

        [Test]
        [TestCaseSource(nameof(ExtensionsTestSortingAscendingData))]
        public void EnumerableExtensionsTestSortingAscending(string id, List<Sample> act)
        {
            // act
            var resultEnumerable = act;

            // assert
            Assert.That(resultEnumerable[0].LastName, Is.EqualTo("Mendez"));
            Assert.That(resultEnumerable[1].LastName, Is.EqualTo("Rivera"));
            Assert.That(resultEnumerable[2].LastName, Is.EqualTo("Rodriguez"));
        }

        private static IEnumerable<TestCaseData> ExtensionsTestSortingDescendingData()
        {
            yield return new TestCaseData("enum", TestData.List.AsEnumerable().OrderBy(c => c.FirstName, SortDirection.Descending).ToList());
            yield return new TestCaseData("query", TestData.List.OrderBy(c => c.FirstName, SortDirection.Descending).ToList());
        }

        [Test]
        [TestCaseSource(nameof(ExtensionsTestSortingDescendingData))]
        public void EnumerableExtensionsTestSortingDescending(string id, List<Sample> act)
        {
            // act
            var resultEnumerable = act;

            // assert
            Assert.That(resultEnumerable[0].FirstName, Is.EqualTo("Manuel"));
            Assert.That(resultEnumerable[1].FirstName, Is.EqualTo("Julian"));
            Assert.That(resultEnumerable[2].FirstName, Is.EqualTo("Jose"));
        }
    }
}
