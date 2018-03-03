using NUnit.Framework;
using System.Linq;

namespace DeuceGear.UnitTests.ArrayExtensions
{
    [TestFixture]
    public class ArrayExtensionsIndicesTestFixture
    {
        [Test]
        public void ArrayExtensionIndices()
        {
            // arrange
            var source = new string[2, 3, 2];
            source[0, 0, 0] = "000";
            source[0, 0, 1] = "001";
            source[0, 1, 0] = "010";
            source[0, 1, 1] = "011";
            source[0, 2, 0] = "020";
            source[0, 2, 1] = "021";
            source[1, 0, 0] = "100";
            source[1, 0, 1] = "101";
            source[1, 1, 0] = "110";
            source[1, 1, 1] = "111";
            source[1, 2, 0] = "120";
            source[1, 2, 1] = "121";

            // act
            var indices = source.Indices().ToList();

            // assert
            Assert.That(indices.Count(), Is.EqualTo(12));
            Assert.That(indices[0].SequenceEqual(new int[] { 0, 0, 0 }));
            Assert.That(indices[1].SequenceEqual(new int[] { 0, 0, 1 }));
            Assert.That(indices[2].SequenceEqual(new int[] { 0, 1, 0 }));
            Assert.That(indices[3].SequenceEqual(new int[] { 0, 1, 1 }));
            Assert.That(indices[4].SequenceEqual(new int[] { 0, 2, 0 }));
            Assert.That(indices[5].SequenceEqual(new int[] { 0, 2, 1 }));
            Assert.That(indices[6].SequenceEqual(new int[] { 1, 0, 0 }));
            Assert.That(indices[7].SequenceEqual(new int[] { 1, 0, 1 }));
            Assert.That(indices[8].SequenceEqual(new int[] { 1, 1, 0 }));
            Assert.That(indices[9].SequenceEqual(new int[] { 1, 1, 1 }));
            Assert.That(indices[10].SequenceEqual(new int[] { 1, 2, 0 }));
            Assert.That(indices[11].SequenceEqual(new int[] { 1, 2, 1 }));
        }
    }
}
