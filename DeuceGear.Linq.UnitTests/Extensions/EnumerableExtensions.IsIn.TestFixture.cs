using System.Collections.Generic;
using System.Linq;
using DeuceGear.Linq;
using NUnit.Framework;

namespace DeuceGear.UnitTests.Linq.Extensions
{
	[TestFixture]
    public class EnumerableExtensionsIsInTestFixture
    {
        private static Sample _jose = new Sample("Jose", "Rodriguez");
        private static Sample _bob = new Sample("Bob", "Barker");
        private static Sample _julian = new Sample("Julian", "Mendez");
        private static List<Sample> _checkList = new List<Sample>() { _bob, _jose, _julian };

        private static IEnumerable<TestCaseData> EnumerableExtensionsTestIsInParamsData()
        {
            yield return new TestCaseData("enum", TestData.List.AsEnumerable().IsIn(_jose, _bob).ToList());
            yield return new TestCaseData("query", TestData.List.IsIn(_jose, _bob).ToList());

            yield return new TestCaseData("enum - select", TestData.List.AsEnumerable().IsIn(x => x.FirstName,_jose.FirstName, _bob.FirstName).ToList());
            yield return new TestCaseData("query - select", TestData.List.IsIn(x => x.FirstName, _jose.FirstName, _bob.FirstName).ToList());
        }

        [Test]
        [TestCaseSource(nameof(EnumerableExtensionsTestIsInParamsData))]
        public void EnumerableExtensionsTestIsInParams(string id, List<Sample> act)
        {
            // act
            var resultEnumerable = act;

            // assert
            Assert.That(resultEnumerable.Count, Is.EqualTo(1));
            Assert.That(resultEnumerable[0].LastName, Is.EqualTo("Rodriguez"));
        }
       
        private static IEnumerable<TestCaseData> EnumerableExtensionsTestIsInListData()
        {
            yield return new TestCaseData("enum - array", TestData.List.AsEnumerable().IsIn(_checkList.ToArray()).ToList());
            yield return new TestCaseData("enum - enum", TestData.List.AsEnumerable().IsIn(_checkList.AsEnumerable()).ToList());
            yield return new TestCaseData("enum - query", TestData.List.AsEnumerable().IsIn(_checkList.AsQueryable()).ToList());
            yield return new TestCaseData("query - array", TestData.List.IsIn(_checkList.ToArray()).ToList());
            yield return new TestCaseData("query - enum", TestData.List.IsIn(_checkList.AsEnumerable()).ToList());
            yield return new TestCaseData("query - query", TestData.List.IsIn(_checkList.AsQueryable()).ToList());

            yield return new TestCaseData("enum - array - select", TestData.List.AsEnumerable().IsIn(x => x.FirstName, _checkList.Select(x => x.FirstName).ToArray()).ToList());
            yield return new TestCaseData("enum - enum - select", TestData.List.AsEnumerable().IsIn(x => x.FirstName, _checkList.Select(x => x.FirstName).AsEnumerable()).ToList());
            yield return new TestCaseData("enum - query - select", TestData.List.AsEnumerable().IsIn(x => x.FirstName, _checkList.Select(x => x.FirstName).AsQueryable()).ToList());
            yield return new TestCaseData("query - array - select", TestData.List.IsIn(x => x.FirstName, _checkList.Select(x => x.FirstName).ToArray()).ToList());
            yield return new TestCaseData("query - enum - select", TestData.List.IsIn(x => x.FirstName, _checkList.Select(x => x.FirstName).AsEnumerable()).ToList());
            yield return new TestCaseData("query - query - select", TestData.List.IsIn(x => x.FirstName, _checkList.Select(x => x.FirstName).AsQueryable()).ToList());
        }

        [Test]
        [TestCaseSource(nameof(EnumerableExtensionsTestIsInListData))]
        public void EnumerableExtensionsTestIsInArray(string id, List<Sample> act)
        {
            // act
            var resultEnumerable = act;

            // assert
            Assert.That(resultEnumerable.Count, Is.EqualTo(2));
            Assert.That(resultEnumerable[0].LastName, Is.EqualTo("Rodriguez"));
            Assert.That(resultEnumerable[1].LastName, Is.EqualTo("Mendez"));
        }
    }
}
