using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DeuceGear.Linq;
using System;

namespace DeuceGear.UnitTests.Linq.Extensions
{
	[TestFixture]
    public partial class EnumerableExtensionsTestFixture
    {
        [Test]
        [TestCase(2, 0, "ab")]
        [TestCase(2, 1, "cd")]
        [TestCase(2, 2, "e")]
        [TestCase(2, 3, "")]
        public void EnumerableExtensionsTestPaging(int pageSize, int pagesToSkip, string expectationString)
        {
            // arrange
            var expectation = expectationString.ToArray().ToList();
            var list = new List<char>() { 'a', 'b', 'c', 'd', 'e' };

            // act
            var resultEnumerable = list.AsEnumerable().Paging(pageSize, pagesToSkip);

            // assert
            Assert.IsTrue(Enumerable.SequenceEqual(resultEnumerable, expectation));
        }

        [Test]
        [TestCase(0, 0, "pageSize can not be 0 or less")]
        [TestCase(-1, -1, "pageSize can not be 0 or less")]
        [TestCase(-1, 0, "pageSize can not be 0 or less")]
        [TestCase(0, -1, "pageSize can not be 0 or less")]
        [TestCase(-1, 3, "pageSize can not be 0 or less")]
        [TestCase(3, -1, "numberOfPagesToSkip can not be less than 0")]
        public void EnumerableExtensionsTestPagingThrowsException(int pageSize, int pagesToSkip, string expectationString)
        {
            // arrange
            var expectation = expectationString.ToArray().ToList();
            var list = new List<char>() { 'a', 'b', 'c', 'd', 'e' };

            // act
            var result = Assert.Throws<ArgumentException>( () =>  list.AsEnumerable().Paging(pageSize, pagesToSkip));

            // assert
            Assert.That(result.Message, Is.EqualTo(expectation));
        }

        [Test]
        [TestCase(2, 0, "ab")]
        [TestCase(2, 1, "cd")]
        [TestCase(2, 2, "e")]
        [TestCase(2, 3, "")]
        public void QueryableExtensionsTestPaging(int pageSize, int pagesToSkip, string expectationString)
        {
            // arrange
            var expectation = expectationString.ToArray().ToList();
            var list = new List<char>() { 'a', 'b', 'c', 'd', 'e' };

            // act
            var resultQueryable = list.AsQueryable().Paging(pageSize, pagesToSkip);

            // assert
            Assert.IsTrue(Enumerable.SequenceEqual(resultQueryable, expectation));
        }

        [Test]
        [TestCase(0, 0, "pageSize can not be 0 or less")]
        [TestCase(-1, -1, "pageSize can not be 0 or less")]
        [TestCase(-1, 0, "pageSize can not be 0 or less")]
        [TestCase(0, -1, "pageSize can not be 0 or less")]
        [TestCase(-1, 3, "pageSize can not be 0 or less")]
        [TestCase(3, -1, "numberOfPagesToSkip can not be less than 0")]
        public void QueryableExtensionsTestPagingThrowsException(int pageSize, int pagesToSkip, string expectationString)
        {
            // arrange
            var expectation = expectationString.ToArray().ToList();
            var list = new List<char>() { 'a', 'b', 'c', 'd', 'e' };

            // act
            var result = Assert.Throws<ArgumentException>(() => list.AsQueryable().Paging(pageSize, pagesToSkip));

            // assert
            Assert.That(result.Message, Is.EqualTo(expectation));
        }
    }
}
