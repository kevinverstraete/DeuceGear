using DeuseGear.Linq;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace DeuceGear.UnitTests.Linq.Specifications
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class OrSpecificationTestFixture
    {
        [Test]
        public void OrSpecificationTestOrSpecification()
        {
            // arrange
            var specFirstName = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("M"));
            var specLastName = new AdHocSpecification<Sample>(x => x.LastName.StartsWith("M"));
            var spec = new OrSpecification<Sample>(specFirstName, specLastName);

            // act
            var resultFirstName = TestData.List.Where(specFirstName.IsSatisfied()).OrderBy(c => c.FirstName);
            var resultLastName = TestData.List.Where(specLastName.IsSatisfied()).OrderBy(c => c.FirstName);
            var result = TestData.List.Where(spec.IsSatisfied()).OrderBy(c => c.FirstName);

            // assert
            Assert.That(resultFirstName.Count(), Is.EqualTo(1));
            Assert.That(resultFirstName.First().FirstName, Is.EqualTo("Manuel"));
            Assert.That(resultFirstName.First().LastName, Is.EqualTo("Rivera"));
            Assert.That(resultLastName.Count(), Is.EqualTo(1));
            Assert.That(resultLastName.First().FirstName, Is.EqualTo("Julian"));
            Assert.That(resultLastName.First().LastName, Is.EqualTo("Mendez"));
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Julian"));
            Assert.That(result.First().LastName, Is.EqualTo("Mendez"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Manuel"));
            Assert.That(result.Last().LastName, Is.EqualTo("Rivera"));
        }

        [Test]
        public void OrSpecificationTestOrSpecificationViaOperator()
        {
            // arrange
            var specFirstName = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("M"));
            var specLastName = new AdHocSpecification<Sample>(x => x.LastName.StartsWith("M"));
            var spec = specFirstName || specLastName;

            // act
            var resultFirstName = TestData.List.Where(specFirstName.IsSatisfied()).OrderBy(c => c.FirstName);
            var resultLastName = TestData.List.Where(specLastName.IsSatisfied()).OrderBy(c => c.FirstName);
            var result = TestData.List.Where(spec.IsSatisfied()).OrderBy(c => c.FirstName);

            // assert
            Assert.That(resultFirstName.Count(), Is.EqualTo(1));
            Assert.That(resultFirstName.First().FirstName, Is.EqualTo("Manuel"));
            Assert.That(resultFirstName.First().LastName, Is.EqualTo("Rivera"));
            Assert.That(resultLastName.Count(), Is.EqualTo(1));
            Assert.That(resultLastName.First().FirstName, Is.EqualTo("Julian"));
            Assert.That(resultLastName.First().LastName, Is.EqualTo("Mendez"));
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Julian"));
            Assert.That(result.First().LastName, Is.EqualTo("Mendez"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Manuel"));
            Assert.That(result.Last().LastName, Is.EqualTo("Rivera"));
        }

        [Test]
        public void OrSpecificationTestOrSpecificationForLinq()
        {
            // arrange
            Expression<Func<Sample, bool>> specFirstName = x => x.FirstName.StartsWith("M");
            Expression<Func<Sample, bool>> specLastName = x => x.LastName.StartsWith("M");
            var spec = specFirstName.Or(specLastName);

            // act
            var resultFirstName = TestData.List.Where(specFirstName).OrderBy(c => c.FirstName);
            var resultLastName = TestData.List.Where(specLastName).OrderBy(c => c.FirstName);
            var result = TestData.List.Where(spec).OrderBy(c => c.FirstName);

            // assert
            Assert.That(resultFirstName.Count(), Is.EqualTo(1));
            Assert.That(resultFirstName.First().FirstName, Is.EqualTo("Manuel"));
            Assert.That(resultFirstName.First().LastName, Is.EqualTo("Rivera"));
            Assert.That(resultLastName.Count(), Is.EqualTo(1));
            Assert.That(resultLastName.First().FirstName, Is.EqualTo("Julian"));
            Assert.That(resultLastName.First().LastName, Is.EqualTo("Mendez"));
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Julian"));
            Assert.That(result.First().LastName, Is.EqualTo("Mendez"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Manuel"));
            Assert.That(result.Last().LastName, Is.EqualTo("Rivera"));
        }
        [Test]
        public void OrSpecificationTestOrSpecificationForLinqWithDifferentVisitor()
        {
            // arrange
            Expression<Func<Sample, bool>> specFirstName = x => x.FirstName.StartsWith("M");
            Expression<Func<Sample, bool>> specLastName = y => y.LastName.StartsWith("M");
            var spec = specFirstName.Or(specLastName);

            // act
            var resultFirstName = TestData.List.Where(specFirstName).OrderBy(c => c.FirstName);
            var resultLastName = TestData.List.Where(specLastName).OrderBy(c => c.FirstName);
            var result = TestData.List.Where(spec).OrderBy(c => c.FirstName);

            // assert
            Assert.That(resultFirstName.Count(), Is.EqualTo(1));
            Assert.That(resultFirstName.First().FirstName, Is.EqualTo("Manuel"));
            Assert.That(resultFirstName.First().LastName, Is.EqualTo("Rivera"));
            Assert.That(resultLastName.Count(), Is.EqualTo(1));
            Assert.That(resultLastName.First().FirstName, Is.EqualTo("Julian"));
            Assert.That(resultLastName.First().LastName, Is.EqualTo("Mendez"));
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Julian"));
            Assert.That(result.First().LastName, Is.EqualTo("Mendez"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Manuel"));
            Assert.That(result.Last().LastName, Is.EqualTo("Rivera"));
        }
    }
}
