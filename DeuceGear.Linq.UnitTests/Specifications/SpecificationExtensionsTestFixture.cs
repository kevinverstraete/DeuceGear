using DeuseGear.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace DeuceGear.UnitTests.Linq.Specifications
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SpecificationExtensionsTestFixture
    {
        [Test]
        [TestCaseSource("SpecificationExtensionsTestIsSameCaseSource")]
        public void SpecificationExtensionsTestIsSame(string description, Specification<Sample> spec1, object spec2, bool expected)
        {
            var spec2Cast = spec2 as Specification<Sample>;
            if (spec2Cast != null || spec2 == null)
            {
                // act
                var result2 = spec1.IsSameAs(spec2Cast);

                // assert
                Assert.That(result2, Is.EqualTo(expected));
            }
            else
            {
                // datasource contains unusable sample
                Assert.That(true);
            }
        }

        [Test]
        [TestCaseSource("SpecificationExtensionsTestIsSameCaseSource")]
        public void SpecificationExtensionsTestEquals(string description, Specification<Sample> spec1, object spec2, bool expected)
        {
            // act
            var result = spec1.Equals(spec2);
            // assert
            Assert.That(result, Is.EqualTo(expected));
        }

        public static IEnumerable<TestCaseData> SpecificationExtensionsTestIsSameCaseSource()
        {
            // single spec types
            var specFirstNull = new FirstNameSpec(null);
            var specFirstNull2 = new FirstNameSpec(null);
            var specFirstBob = new FirstNameSpec("bob");
            var specFirstBob2 = new FirstNameSpec("bob");
            var specFirstBobbette = new FirstNameSpec("bobbette");
            var specFirstAndLastBob = new FirstAndLastNameSpec("bob", "le");
            var specFirstAndLastBob2 = new FirstAndLastNameSpec("bob", "le");
            var specFirstAndLastBobbbette = new FirstAndLastNameSpec("bobbette", "le");
            var specLastBob = new LastNameSpec("bob");

            yield return new TestCaseData("Check on null type", specFirstBob, null, false);
            yield return new TestCaseData("Check non reference type", specFirstBob, "dinge", false);
            yield return new TestCaseData("SameReference", specFirstBob, specFirstBob, true);
            yield return new TestCaseData("Different type", specFirstBob, specLastBob, false);
            yield return new TestCaseData("Same single content (null)", specFirstNull, specFirstNull2, true);
            yield return new TestCaseData("Same single content", specFirstBob, specFirstBob2, true);
            yield return new TestCaseData("Same multiple content", specFirstAndLastBob, specFirstAndLastBob2, true);
            yield return new TestCaseData("Different single content", specFirstBob, specFirstBobbette, false);

            // operator specs
            var orSpecBob = new OrSpecification<Sample>(specFirstBob, specFirstBob2);
            var orSpecBob2 = new OrSpecification<Sample>(specFirstBob, specFirstBob2);
            var orSpecBob3 = new OrSpecification<Sample>(specFirstBob, specLastBob);
            var andSpecBob = new AndSpecification<Sample>(specFirstBob, specFirstBob);
            var andSpecBob2 = new AndSpecification<Sample>(specFirstBob, specFirstBob2);
            var andSpecBob3 = new AndSpecification<Sample>(specFirstBob, specLastBob);

            yield return new TestCaseData("OR Same containing specs", orSpecBob, orSpecBob2, true);
            yield return new TestCaseData("Or Different containing specs", orSpecBob, orSpecBob3, false);
            yield return new TestCaseData("And Same containing specs", andSpecBob, andSpecBob2, true);
            yield return new TestCaseData("And Different containing specs", andSpecBob, andSpecBob3, false);

            // array specs: value compares
            var array = new int[] { 1, 2, 3 };
            var arraySpecNull = new ArraySpec<int>(null);
            var arraySpec = new ArraySpec<int>(array);
            var arraySpec2 = new ArraySpec<int>(array);
            var arraySpec3 = new ArraySpec<int>(new int[] { 1, 2, 3 });
            var arraySpec4 = new ArraySpec<int>(new int[] { 1, 2, 3, 4 });

            yield return new TestCaseData("Array - same array", arraySpec, arraySpec2, true);
            yield return new TestCaseData("Array - different array - same content", arraySpec, arraySpec3, true);
            yield return new TestCaseData("Array - different array - different content", arraySpec, arraySpec4, false);
            yield return new TestCaseData("Array - different array - different content (null)", arraySpec, arraySpecNull, false);
            yield return new TestCaseData("Array(obj) - same array", arraySpec, arraySpec2, true);

            // array specs: object compares
            var sample = new Sample("le", "bob");
            var arraySpecSample = new ArraySpec<Sample>(new Sample[] { sample, sample });
            var arraySpecSample2 = new ArraySpec<Sample>(new Sample[] { sample, sample });
            var arraySpecSampleNull = new ArraySpec<Sample>(new Sample[] { sample, null, sample });
            var arraySpecSampleNull2 = new ArraySpec<Sample>(new Sample[] { sample, null, sample });
            var arraySpecObject = new ArraySpec<object>(new object[] { "a", 1 });
            var arraySpecObject2 = new ArraySpec<object>(new object[] { "a", "b" });
            var arraySpecObject3 = new ArraySpec<object>(new object[] { "a", "c" });
            var arraySpecObjectnull = new ArraySpec<object>(null);

            yield return new TestCaseData("Array(obj) - different array - same content", arraySpecSample, arraySpecSample2, true);
            yield return new TestCaseData("Array(obj) - different array - different content (null)", arraySpecSampleNull, arraySpecSampleNull2, false);
            yield return new TestCaseData("Array(obj) - different array - different content (type)", arraySpecObject, arraySpecObject2, false);
            yield return new TestCaseData("Array(obj) - different array - different content (value)", arraySpecObject3, arraySpecObject2, false);
            yield return new TestCaseData("Array(obj) - different array - one is null", arraySpecObject3, arraySpecObjectnull, false);
        }


        private class FirstNameSpec : Specification<Sample>
        {
            public string FirstName { get; set; }

            public FirstNameSpec(string firstName)
            {
                FirstName = firstName;
            }

            public override Expression<Func<Sample, bool>> IsSatisfied()
            {
                return x => x.FirstName == FirstName;
            }
        }
        private class LastNameSpec : Specification<Sample>
        {
            public string LastName { get; set; }

            public LastNameSpec(string lastName)
            {
                LastName = lastName;
            }

            public override Expression<Func<Sample, bool>> IsSatisfied()
            {
                return x => x.LastName == LastName;
            }
        }
        private class FirstAndLastNameSpec : Specification<Sample>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public FirstAndLastNameSpec(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public override Expression<Func<Sample, bool>> IsSatisfied()
            {
                return x => x.FirstName == FirstName && x.LastName == LastName;
            }
        }
        private class ArraySpec<T> : Specification<Sample>
        {
            public T[] MyProp { get; set; }
            public ArraySpec(T[] list)
            {
                MyProp = list;
            }
            public override Expression<Func<Sample, bool>> IsSatisfied()
            {
                throw new NotImplementedException();
            }
        }
    }
}
