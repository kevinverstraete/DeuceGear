using DeuseGear.Linq;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace DeuceGear.Linq.UnitTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AndSpecificationTestFixture
    {
        [Test]
        public void AndSpecificationTestAndSpecification()
        {
            // arrange
            var specFirstName = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("J"));
            var specLastName = new AdHocSpecification<Sample>(x => x.LastName.StartsWith("R"));
            var spec = new AndSpecification<Sample>(specFirstName, specLastName);

            // act
            var resultFirstName = TestData.List.Where(specFirstName.IsSatisfied()).OrderBy(c => c.FirstName);
            var resultLastName = TestData.List.Where(specLastName.IsSatisfied()).OrderBy(c => c.FirstName);
            var result = TestData.List.Where(spec.IsSatisfied()).OrderBy(c => c.FirstName);

            // assert
            Assert.That(resultFirstName.Count(), Is.EqualTo(2));
            Assert.That(resultFirstName.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(resultFirstName.Last().FirstName, Is.EqualTo("Julian"));
            Assert.That(resultLastName.Count(), Is.EqualTo(2));
            Assert.That(resultLastName.First().LastName, Is.EqualTo("Rodriguez"));
            Assert.That(resultLastName.Last().LastName, Is.EqualTo("Rivera"));
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(result.First().LastName, Is.EqualTo("Rodriguez"));
        }

        [Test]
        public void AndSpecificationTestAndSpecificationViaOperator()
        {
            // arrange
            var specFirstName = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("J"));
            var specLastName = new AdHocSpecification<Sample>(x => x.LastName.StartsWith("R"));
            var spec = specFirstName && specLastName;

            // act
            var resultFirstName = TestData.List.Where(specFirstName.IsSatisfied()).OrderBy(c => c.FirstName);
            var resultLastName = TestData.List.Where(specLastName.IsSatisfied()).OrderBy(c => c.FirstName);
            var result = TestData.List.Where(spec.IsSatisfied()).OrderBy(c => c.FirstName);

            // assert
            Assert.That(resultFirstName.Count(), Is.EqualTo(2));
            Assert.That(resultFirstName.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(resultFirstName.Last().FirstName, Is.EqualTo("Julian"));
            Assert.That(resultLastName.Count(), Is.EqualTo(2));
            Assert.That(resultLastName.First().LastName, Is.EqualTo("Rodriguez"));
            Assert.That(resultLastName.Last().LastName, Is.EqualTo("Rivera"));
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(result.First().LastName, Is.EqualTo("Rodriguez"));
        }

        [Test]
        public void AndSpecificationTestAndSpecificationForLinq()
        {
            // arrange
            Expression<Func<Sample, bool>> specFirstName = x => x.FirstName.StartsWith("J");
            Expression<Func<Sample, bool>> specLastName = x => x.LastName.StartsWith("R");
            var spec = specFirstName.And(specLastName);

            // act
            var resultFirstName = TestData.List.Where(specFirstName).OrderBy(c => c.FirstName);
            var resultLastName = TestData.List.Where(specLastName).OrderBy(c => c.FirstName);
            var result = TestData.List.Where(spec).OrderBy(c => c.FirstName);

            // assert
            Assert.That(resultFirstName.Count(), Is.EqualTo(2));
            Assert.That(resultFirstName.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(resultFirstName.Last().FirstName, Is.EqualTo("Julian"));
            Assert.That(resultLastName.Count(), Is.EqualTo(2));
            Assert.That(resultLastName.First().LastName, Is.EqualTo("Rodriguez"));
            Assert.That(resultLastName.Last().LastName, Is.EqualTo("Rivera"));
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(result.First().LastName, Is.EqualTo("Rodriguez"));
        }

        [Test]
        public void AndSpecificationTestAndSpecificationForLinqWithDifferentVisitor()
        {
            // arrange
            Expression<Func<Sample, bool>> specFirstName = x => x.FirstName.StartsWith("J");
            Expression<Func<Sample, bool>> specLastName = y => y.LastName.StartsWith("R");
            var spec = specFirstName.And(specLastName);

            // act
            var resultFirstName = TestData.List.Where(specFirstName).OrderBy(c => c.FirstName);
            var resultLastName = TestData.List.Where(specLastName).OrderBy(c => c.FirstName);
            var result = TestData.List.Where(spec).OrderBy(c => c.FirstName);

            // assert
            Assert.That(resultFirstName.Count(), Is.EqualTo(2));
            Assert.That(resultFirstName.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(resultFirstName.Last().FirstName, Is.EqualTo("Julian"));
            Assert.That(resultLastName.Count(), Is.EqualTo(2));
            Assert.That(resultLastName.First().LastName, Is.EqualTo("Rodriguez"));
            Assert.That(resultLastName.Last().LastName, Is.EqualTo("Rivera"));
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(result.First().LastName, Is.EqualTo("Rodriguez"));
        }
    }
}
