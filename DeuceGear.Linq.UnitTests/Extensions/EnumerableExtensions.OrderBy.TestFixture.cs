using System.Linq;
using DeuceGear.Linq;
using NUnit.Framework;

namespace DeuceGear.UnitTests.Linq.Extensions
{
	[TestFixture]
    public partial class EnumerableExtensionsTestFixture
    {
        [Test]
        public void EnumerableExtensionsTestSortingAscending()
        {
            // act
            var resultEnumerable = TestData.List
                .AsEnumerable()
                .OrderBy(c => c.LastName, SortDirection.Ascending)
                .ToList();

            // assert
            Assert.That(resultEnumerable[0].LastName, Is.EqualTo("Mendez"));
            Assert.That(resultEnumerable[1].LastName, Is.EqualTo("Rivera"));
            Assert.That(resultEnumerable[2].LastName, Is.EqualTo("Rodriguez"));
        }

        [Test]
        public void QueryableExtensionsTestSortingAscending()
        {
            // act
            var resultQueryable = TestData.List
                .OrderBy(c => c.LastName, SortDirection.Ascending)
                .ToList();

            // assert
            Assert.That(resultQueryable[0].LastName, Is.EqualTo("Mendez"));
            Assert.That(resultQueryable[1].LastName, Is.EqualTo("Rivera"));
            Assert.That(resultQueryable[2].LastName, Is.EqualTo("Rodriguez"));
        }

        [Test]
        public void EnumerableExtensionsTestSortingDescending()
        {
            // act
            var resultEnumerable = TestData.List
                .AsEnumerable()
                .OrderBy(c => c.FirstName, SortDirection.Descending)
                .ToList();

            // assert
            Assert.That(resultEnumerable[0].FirstName, Is.EqualTo("Manuel"));
            Assert.That(resultEnumerable[1].FirstName, Is.EqualTo("Julian"));
            Assert.That(resultEnumerable[2].FirstName, Is.EqualTo("Jose"));
        }

        [Test]
        public void QueryableExtensionsTestSortingDescending()
        {
            // act
            var resultQueryable = TestData.List
                .OrderBy(c => c.FirstName, SortDirection.Descending)
                .ToList();

            // assert
            Assert.That(resultQueryable[0].FirstName, Is.EqualTo("Manuel"));
            Assert.That(resultQueryable[1].FirstName, Is.EqualTo("Julian"));
            Assert.That(resultQueryable[2].FirstName, Is.EqualTo("Jose"));
        }
    }
}
