using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace DeuceGear.UnitTests.ArrayExtensions
{
    [TestFixture]
    public class ArrayExtensionsIndexExistsTestFixture
    {
        [TestFixture]
        [ExcludeFromCodeCoverage]
        public class ArrayExtensionsTestFixture
        {
            [Test]
            [TestCase(-1, false)]
            [TestCase(0, true)]
            [TestCase(1, true)]
            [TestCase(2, true)]
            [TestCase(3, false)]
            [TestCase(4, false)]
            public void ArrayExtensionsIndexExistsTestSingleDimension(int index, bool expected)
            {
                // arrange
                var ar = new int[3];
                // act
                var result = ar.IndexExists(index);

                // assert
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            // impossible dimension
            [TestCase(-1, -1, false)]
            [TestCase(0, -1, false)]
            [TestCase(1, -1, false)]
            [TestCase(2, -1, false)]
            [TestCase(3, -1, false)]
            // first dimension
            [TestCase(-1, 0, false)]
            [TestCase(0, 0, true)]
            [TestCase(1, 0, true)]
            [TestCase(2, 0, true)]
            [TestCase(3, 0, false)]
            // second dimension
            [TestCase(-1, 1, false)]
            [TestCase(0, 1, true)]
            [TestCase(1, 1, true)]
            [TestCase(2, 1, false)]
            [TestCase(3, 1, false)]
            // unknown dimension
            [TestCase(-1, 2, false)]
            [TestCase(0, 2, false)]
            [TestCase(1, 2, false)]
            [TestCase(2, 2, false)]
            [TestCase(3, 2, false)]
            public void ArrayExtensionsIndexExistsTestMultipleDimensions(int index, int dimension, bool expected)
            {
                // arrange
                var ar = new int[3, 2];
                // act
                var result = ar.IndexExists(index, dimension);

                // assert
                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}
