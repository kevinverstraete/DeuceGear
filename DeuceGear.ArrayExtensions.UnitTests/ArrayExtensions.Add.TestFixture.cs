using NUnit.Framework;
using System;

namespace DeuceGear.UnitTests.ArrayExtensions
{
    [TestFixture]
    public class ArrayExtensionsAddTestFixture
    {

        [Test]
        public void ArrayExtensionsAddNull()
        {
            // arrange
            var source = new string[] { "a", "b", "c" };

            // act
            var result = source.Add(null);

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo("a"));
            Assert.That(result[1], Is.EqualTo("b"));
            Assert.That(result[2], Is.EqualTo("c"));
            Assert.That(result[3], Is.Null);
        }

        [Test]
        public void ArrayObjectExtensionsAddNull()
        {
            // arrange
            Array source = new string[] { "a", "b", "c" };

            // act
            var result = source.Add<string>(null);

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result.GetValue(0), Is.EqualTo("a"));
            Assert.That(result.GetValue(1), Is.EqualTo("b"));
            Assert.That(result.GetValue(2), Is.EqualTo("c"));
            Assert.That(result.GetValue(3), Is.Null);
        }

        [Test]
        public void ArrayExtensionsAddValue()
        {
            // arrange
            var source = new string[] { "a", "b", "c" };

            // act
            var result = source.Add("d");

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo("a"));
            Assert.That(result[1], Is.EqualTo("b"));
            Assert.That(result[2], Is.EqualTo("c"));
            Assert.That(result[3], Is.EqualTo("d"));
        }

        [Test]
        public void ArrayObjectExtensionsAddValue()
        {
            // arrange
            Array source = new string[] { "a", "b", "c" };

            // act
            var result = source.Add("d");

            // assert
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result.GetValue(0), Is.EqualTo("a"));
            Assert.That(result.GetValue(1), Is.EqualTo("b"));
            Assert.That(result.GetValue(2), Is.EqualTo("c"));
            Assert.That(result.GetValue(3), Is.EqualTo("d"));
        }
    }
}
