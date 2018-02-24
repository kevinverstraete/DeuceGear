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
    public class CustomSpecificationTestFixture
    {
        [Test]
        public void CustomSpecificationTestCustomSpecification()
        {
            // arrange
            var spec = new FirstNameSpecification("Julian");

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).OrderBy(c => c.FirstName);

            // assert
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.Last().FirstName, Is.EqualTo("Julian"));
        }
    }

    public class FirstNameSpecification : Specification<Sample>
    {
        private string _firstName;
        public FirstNameSpecification(string firstName)
        {
            _firstName = firstName;
        }

        public override Expression<Func<Sample, bool>> IsSatisfied()
        {
            return c => c.FirstName == _firstName;
        }
    }
}
