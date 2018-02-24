using DeuseGear.Linq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DeuceGear.Linq.UnitTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AdHocSpecificationTestFixture
    {
        [Test]
        public void AdHocSpecificationTestAdHocSpecification()
        {
            // arrange
            var spec = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("J"));

            // act
            var result = TestData.List.Where(spec.IsSatisfied()).OrderBy(c => c.FirstName);

            // assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("Jose"));
            Assert.That(result.Last().FirstName, Is.EqualTo("Julian"));
        }

        [Test]
        public void AdHocSpecificationTestParameterIsGenerated()
        {
            // act
            var spec = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("J"));

            // assert
            Assert.That(spec.GetHashCode(), Is.Not.EqualTo(spec.GetHashCode()));
        }
    }
}
