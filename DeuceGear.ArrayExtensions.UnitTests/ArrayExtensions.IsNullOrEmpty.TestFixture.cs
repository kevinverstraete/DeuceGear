using NUnit.Framework;
using System;

namespace DeuceGear.UnitTests.ArrayExtensions
{
    [TestFixture]
    public class ArrayExtensionsIsNullOrEmptyTestFixture
    {
        [TestCase(null, true)]
        [TestCase(new int[] { }, true)]
        [TestCase(new int[] { 1, 2, 3 }, false)]
        [Test]
        public void ArrayExtensionsIsNullOrEmptyTest(Array array, bool expected)
        {
            // act
            var result = array.IsNullOrEmpty();

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void ArrayExtensionsIsNullOrEmptyMultiDimensionTest()
        {
            // arrange
            var array = new int[0, 0];

            // act
            var result = array.IsNullOrEmpty();

            // assert
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
