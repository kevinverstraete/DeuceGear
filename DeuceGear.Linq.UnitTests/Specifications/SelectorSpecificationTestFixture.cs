using DeuseGear.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DeuceGear.Linq.UnitTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SelectorSpecificationTestFixture
    {
        private IQueryable<int> _numericList;

        [SetUp]
        public void Setup()
        {
            _numericList = (new List<int>() { 1, 2, 3 }).AsQueryable();
        }

        [Test]
        public void SelectorSpecificationTestOne()
        {
            // arrange
            var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, "Jose");

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Jose"));
        }
        [Test]
        public void SelectorSpecificationTestOneNumeric()
        {
            // arrange
            var spec = new SelectorSpecification<int, int>(x => x, 2);

            // act
            var result = _numericList.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(2));
        }

        [Test]
        public void SelectorSpecificationTestEquals()
        {
            // arrange
            var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, Operation.Equals, "Jose");

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Jose"));
        }

        [Test]
        public void SelectorSpecificationTestEqualsNumeric()
        {
            // arrange
            var spec = new SelectorSpecification<int, int>(x => x, Operation.Equals, 2);

            // act
            var result = _numericList.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(2));
        }

        [Test]
        public void SelectorSpecificationTestContains()
        {
            // arrange
            var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, Operation.Contains, "u");

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Manuel"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Julian"));
        }

        [Test]
        public void SelectorSpecificationTestStartsWith()
        {
            // arrange
            var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, Operation.StartsWith, "J");

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Julian"));
        }
        [Test]
        public void SelectorSpecificationTestEndsWith()
        {
            // arrange
            var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, Operation.EndsWith, "l");

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Manuel"));
        }

        [Test]
        public void SelectorSpecificationTestNotEquals()
        {
            // arrange
            var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, Operation.NotEquals, "Jose");

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Manuel"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Julian"));
        }

        [Test]
        public void SelectorSpecificationTestNotEqualsNumeric()
        {
            // arrange
            var spec = new SelectorSpecification<int, int>(x => x, Operation.NotEquals, 2);

            // act
            var result = _numericList.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First(), Is.EqualTo(1));
            Assert.That(result.Last(), Is.EqualTo(3));
        }


        [Test]
        public void SelectorSpecificationTestGreaterThan()
        {
            // arrange
            var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, Operation.GreaterThan, "Jose");

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Manuel"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Julian"));
        }


        [Test]
        public void SelectorSpecificationTestGreaterThanNumeric()
        {
            // arrange
            var spec = new SelectorSpecification<int, int>(x => x, Operation.GreaterThan, 1);

            // act
            var result = _numericList.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First(), Is.EqualTo(2));
            Assert.That(result.Last(), Is.EqualTo(3));
        }

        [Test]
        public void SelectorSpecificationTestGreaterThanOrEquals()
        {
            // arrange
            var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, Operation.GreaterThanOrEquals, "Julian");

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Manuel"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Julian"));
        }

        [Test]
        public void SelectorSpecificationTestGreaterThanOrEqualsNumeric()
        {
            // arrange
            var spec = new SelectorSpecification<int, int>(x => x, Operation.GreaterThanOrEquals, 2);

            // act
            var result = _numericList.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First(), Is.EqualTo(2));
            Assert.That(result.Last(), Is.EqualTo(3));
        }

        [Test]
        public void SelectorSpecificationTestLessThan()
        {
            // arrange
            var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, Operation.LessThan, "Manuel");

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Julian"));
        }

        [Test]
        public void SelectorSpecificationTestLessThanNumeric()
        {
            // arrange
            var spec = new SelectorSpecification<int, int>(x => x, Operation.LessThan, 3);

            // act
            var result = _numericList.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First(), Is.EqualTo(1));
            Assert.That(result.Last(), Is.EqualTo(2));
        }

        [Test]
        public void SelectorSpecificationTestLessThanOrEquals()
        {
            // arrange
            var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, Operation.LessThanOrEquals, "Julian");

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Julian"));
        }


        [Test]
        public void SelectorSpecificationTestLessThanOrEqualNumeric()
        {
            // arrange
            var spec = new SelectorSpecification<int, int>(x => x, Operation.LessThanOrEquals, 2);

            // act
            var result = _numericList.Where(spec.IsSatisfied()).ToList();

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First(), Is.EqualTo(1));
            Assert.That(result.Last(), Is.EqualTo(2));
        }
    }
}
