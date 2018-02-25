using System.Linq;
using DeuceGear.Linq;
using NUnit.Framework;

namespace DeuceGear.UnitTests.Linq.Extensions
{
	[TestFixture]
    public partial class EnumerableExtensionsTestFixture
    {
        [Test]
        public void EnumerableExtensionsTestThenSorting()
        {
            // act
            var resultEnumerable = TestData.List
				.AsEnumerable()
				.OrderBy(c => c.LastName.Substring(0, 1), SortDirection.Descending)
				.ThenBy(c => c.LastName.Substring(1, 1), SortDirection.Descending).ToList();

            // assert
            Assert.That(resultEnumerable[0].LastName, Is.EqualTo("Rodriguez"));
            Assert.That(resultEnumerable[1].LastName, Is.EqualTo("Rivera"));
            Assert.That(resultEnumerable[2].LastName, Is.EqualTo("Mendez"));
        }

        [Test]
        public void QueryableExtensionsTestThenSorting()
        {
            // act
            var resultQueryable = TestData.List
                .OrderBy(c => c.LastName.Substring(0, 1), SortDirection.Descending)
                .ThenBy(c => c.LastName.Substring(1, 1), SortDirection.Descending).ToList();

            // assert
            Assert.That(resultQueryable[0].LastName, Is.EqualTo("Rodriguez"));
            Assert.That(resultQueryable[1].LastName, Is.EqualTo("Rivera"));
            Assert.That(resultQueryable[2].LastName, Is.EqualTo("Mendez"));
        }

        [Test]
        public void EnumerableExtensionsTestThenSortingAsc()
        {
            // act
            var resultEnumerable = TestData.List
                .AsEnumerable()
                .OrderBy(c => c.FirstName.Substring(0, 1), SortDirection.Ascending)
                .ThenBy(c => c.FirstName.Substring(1, 1), SortDirection.Ascending).ToList();

            // assert
            Assert.That(resultEnumerable[0].FirstName, Is.EqualTo("Jose"));
            Assert.That(resultEnumerable[1].FirstName, Is.EqualTo("Julian"));
            Assert.That(resultEnumerable[2].FirstName, Is.EqualTo("Manuel"));
        }

        [Test]
        public void QueryableExtensionsTestThenSortingAsc()
        {
            // act
            var resultQueryable = TestData.List
                .OrderBy(c => c.FirstName.Substring(0, 1), SortDirection.Ascending)
                .ThenBy(c => c.FirstName.Substring(1, 1), SortDirection.Ascending).ToList();

            // assert
            Assert.That(resultQueryable[0].FirstName, Is.EqualTo("Jose"));
            Assert.That(resultQueryable[1].FirstName, Is.EqualTo("Julian"));
            Assert.That(resultQueryable[2].FirstName, Is.EqualTo("Manuel"));
        }
    }
}
