using NUnit.Framework;
using System;

namespace DeuceGear.UnitTests.ArrayExtensions
{
    [TestFixture]
    public class ArrayExtensionsMergeTestFixture
    {

        [Test]
        public void ArrayExtensionsMergeWithSourceNullThrowsError()
        {
            // arrange 
            string[] source = null;
            string[] toAdd = null;

            // act
            var result = Assert.Throws<ArgumentNullException>(() => source.Merge(toAdd));

            // assert
            Assert.That(result.ParamName, Is.EqualTo("array"));
        }

        [Test]
        public void ArrayObjectExtensionsMergeWithSourceNullThrowsError()
        {
            // arrange 
            Array source = null;
            Array toAdd = null;

            // act
            var result = Assert.Throws<ArgumentNullException>(() => source.Merge(toAdd));

            // assert
            Assert.That(result.ParamName, Is.EqualTo("array"));
        }

        [Test]
        public void ArrayExtensionsMergeWithDifferentTypesThrowsError()
        {
            // arrange 
            var source = new string[0];
            var toAdd = new int[0];

            // act
            var result = Assert.Throws<ArgumentException>(() => source.Merge(toAdd));

            // assert
            Assert.That(result.Message, Is.EqualTo("Type mismatch between " + source.GetType().GetElementType() + " and " + toAdd.GetType().GetElementType()));
        }

        [Test]
        public void ArrayObjectExtensionsMergeWithDifferentTypesThrowsError()
        {
            // arrange 
            Array source = new string[0];
            Array toAdd = new int[0];

            // act
            var result = Assert.Throws<ArgumentException>(() => source.Merge(toAdd));

            // assert
            Assert.That(result.Message, Is.EqualTo("Type mismatch between " + source.GetType().GetElementType() + " and " + toAdd.GetType().GetElementType()));
        }

        [Test]
        public void ArrayExtensionsMergeEmptyArraysResultsInNewEmptyArray()
        {
            // arrange 
            var source = new string[0];
            var toAdd = new string[0];

            // act
            var result = source.Merge(toAdd);

            // assert
            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test]
        public void ArrayObjectExtensionsMergeEmptyArraysResultsInNewEmptyArray()
        {
            // arrange 
            Array source = new string[0];
            Array toAdd = new string[0];

            // act
            var result = source.Merge(toAdd);

            // assert
            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test]
        public void ArrayExtensionsMergeWithArrayToAddNullResultsInCopy()
        {
            // arrange 
            var source = new string[] { "a", "b", "c" };

            // act
            var result = source.Merge(null);

            // assert
            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result.GetValue(0), Is.EqualTo("a"));
            Assert.That(result.GetValue(1), Is.EqualTo("b"));
            Assert.That(result.GetValue(2), Is.EqualTo("c"));
        }

        [Test]
        public void ArrayObjectExtensionsMergeWithArrayToAddNullResultsInCopy()
        {
            // arrange 
            Array source = new string[] { "a", "b", "c" };

            // act
            var result = source.Merge(null);

            // assert
            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result.GetValue(0), Is.EqualTo("a"));
            Assert.That(result.GetValue(1), Is.EqualTo("b"));
            Assert.That(result.GetValue(2), Is.EqualTo("c"));
        }

        [Test]
        public void ArrayExtensionsMergeEmptyArrayWithOtherArrayResultsInCopy()
        {
            // arrange 
            var source = new string[0];
            var toAdd = new string[] { "a", "b", "c" };

            // act
            var result = source.Merge(toAdd);

            // assert
            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo("a"));
            Assert.That(result[1], Is.EqualTo("b"));
            Assert.That(result[2], Is.EqualTo("c"));
        }

        [Test]
        public void ArrayObjectExtensionsMergeEmptyArrayWithOtherArrayResultsInCopy()
        {
            // arrange 
            Array source = new string[0];
            Array toAdd = new string[] { "a", "b", "c" };

            // act
            var result = source.Merge(toAdd);

            // assert
            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result.GetValue(0), Is.EqualTo("a"));
            Assert.That(result.GetValue(1), Is.EqualTo("b"));
            Assert.That(result.GetValue(2), Is.EqualTo("c"));
        }

        [Test]
        public void ArrayExtensionsMergeSuccess()
        {
            // arrange 
            var source = new string[] { "a", "b", "c" };
            var toAdd = new string[] { "d", "e", "f" };

            // act
            var result = source.Merge(toAdd);

            // assert
            Assert.That(result.Length, Is.EqualTo(6));
            Assert.That(result[0], Is.EqualTo("a"));
            Assert.That(result[1], Is.EqualTo("b"));
            Assert.That(result[2], Is.EqualTo("c"));
            Assert.That(result[3], Is.EqualTo("d"));
            Assert.That(result[4], Is.EqualTo("e"));
            Assert.That(result[5], Is.EqualTo("f"));
        }

        [Test]
        public void ArrayObjectExtensionsMergeSuccess()
        {
            // arrange 
            Array source = new string[] { "a", "b", "c" };
            Array toAdd = new string[] { "d", "e", "f" };

            // act
            var result = source.Merge(toAdd);

            // assert
            Assert.That(result.Length, Is.EqualTo(6));
            Assert.That(result.GetValue(0), Is.EqualTo("a"));
            Assert.That(result.GetValue(1), Is.EqualTo("b"));
            Assert.That(result.GetValue(2), Is.EqualTo("c"));
            Assert.That(result.GetValue(3), Is.EqualTo("d"));
            Assert.That(result.GetValue(4), Is.EqualTo("e"));
            Assert.That(result.GetValue(5), Is.EqualTo("f"));
        }

        [Test]
        public void ArrayExtensionMergeMultiDimensions()
        {
            // arrange
            var source = new string[2, 3];
            source[0, 0] = "00";
            source[0, 1] = "01";
            source[0, 2] = "02";
            source[1, 0] = "10";
            source[1, 1] = "11";
            source[1, 2] = "12";

            var toAdd = new string[2, 3];
            source[0, 0] = "20";
            source[0, 1] = "21";
            source[0, 2] = "22";
            source[1, 0] = "30";
            source[1, 1] = "31";
            source[1, 2] = "32";

            // act
            var result = Assert.Throws<ArgumentException>(() => source.Merge(toAdd));

            // assert
            Assert.That(result.Message, Is.EqualTo("Only single rank arrays are supported"));

        }
    }
}
