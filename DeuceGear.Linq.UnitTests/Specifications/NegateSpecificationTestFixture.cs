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
    public class NegateSpecificationTestFixture
    {
        [Test]
        public void NegateSpecificationTestNegateSpecification()
        {
            // arrange
            var specFirstName = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("J"));
            var spec = new NegateSpecification<Sample>(specFirstName);

            // act
            var resultFirstName = TestData.List.Where(specFirstName.IsSatisfied()).OrderBy(c => c.FirstName);
            var result = TestData.List.Where(spec.IsSatisfied()).OrderBy(c => c.FirstName);

            // assert
            Assert.That(resultFirstName.Count(), Is.EqualTo(2));
            Assert.That(resultFirstName.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(resultFirstName.Last().FirstName, Is.EqualTo("Julian"));
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Manuel"));
            Assert.That(result.First().LastName, Is.EqualTo("Rivera"));
        }

        [Test]
        public void NegateSpecificationTestNegateSpecificationViaOperator()
        {
            // arrange
            var specFirstName = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("J"));
            var spec = !specFirstName;

            // act
            var resultFirstName = TestData.List.Where(specFirstName.IsSatisfied()).OrderBy(c => c.FirstName);
            var result = TestData.List.Where(spec.IsSatisfied()).OrderBy(c => c.FirstName);

            // assert
            Assert.That(resultFirstName.Count(), Is.EqualTo(2));
            Assert.That(resultFirstName.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(resultFirstName.Last().FirstName, Is.EqualTo("Julian"));
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Manuel"));
            Assert.That(result.First().LastName, Is.EqualTo("Rivera"));
        }


        [Test]
        public void NegateSpecificationTestNegateSpecificationViaLinq()
        {
            // arrange
            Expression<Func<Sample, bool>> specFirstName = x => x.FirstName.StartsWith("J");
            var spec = ExpressionExtensions.Not(specFirstName);

            // act
            var resultFirstName = TestData.List.Where(specFirstName).OrderBy(c => c.FirstName);
            var result = TestData.List.Where(spec).OrderBy(c => c.FirstName);

            // assert
            Assert.That(resultFirstName.Count(), Is.EqualTo(2));
            Assert.That(resultFirstName.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(resultFirstName.Last().FirstName, Is.EqualTo("Julian"));
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Manuel"));
            Assert.That(result.First().LastName, Is.EqualTo("Rivera"));
        }
    }
}
