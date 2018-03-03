using NUnit.Framework;
using System;
using System.Linq;

namespace DeuceGear.UnitTests.ObjectExtensions
{
    [TestFixture]
    public class ObjectExtensionsCloneUnitTests
    {
        [Test]
        public void ObjectExtensionsCloneTest()
        {
            // arrange
            var child = new Child(123, "123", new DateTime(2001, 2, 3, 4, 5, 6), 7, new int[] { 1, 2, 3 }, new string[,] { { "1", "a" }, { "2", "b" }, { "3", "c" } })
            {
                Int = 9123,
                String = "9123",
                DateTime = new DateTime(2091, 2, 3, 4, 5, 6),
                Int32 = 97,
                IntArray = new int[] { 91, 92, 93 },
                StringArray = new string[,] { { "91", "za" }, { "92", "zb" }, { "93", "zc" } }
            };

            var parent = new Parent(456, "456", new DateTime(2004, 5, 6, 7, 8, 9), 10, new int[] { 4, 5, 6 }, new string[,] { { "4", "d" }, { "5", "e" }, { "6", "f" } })
            {
                Int = 9456,
                String = "9456",
                DateTime = new DateTime(2094, 5, 6, 7, 8, 9),
                Int32 = 910,
                IntArray = new int[] { 94, 95, 96 },
                StringArray = new string[,] { { "94", "zd" }, { "95", "ze" }, { "96", "zf" } }
            };

            child.Parent = parent;
            parent.Child = child;

            // act
            var result = parent.DeepClone();

            // assert
            Assert.That(parent, Is.Not.EqualTo(result));
            Assert.That(child, Is.Not.EqualTo(result.Child));

            Assert.That(result, Is.EqualTo(result.Child.Parent));

            Assert.That(parent.Int, Is.EqualTo(result.Int));
            Assert.That(parent.String, Is.EqualTo(result.String));
            Assert.That(parent.DateTime, Is.EqualTo(result.DateTime));
            Assert.That(parent.Int32, Is.EqualTo(result.Int32));
            Assert.That(parent.IntArray.ToList().SequenceEqual(result.IntArray));
            var parentArray = parent.StringArray;
            var resultArray = result.StringArray;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    Assert.That(resultArray[i, j], Is.EqualTo(parentArray[i, j]));
                }
            }

            Assert.That(parent.GetInt(), Is.EqualTo(result.GetInt()));
            Assert.That(parent.GetString(), Is.EqualTo(result.GetString()));
            Assert.That(parent.GetDateTime(), Is.EqualTo(result.GetDateTime()));
            Assert.That(parent.GetInt32(), Is.EqualTo(result.GetInt32()));
            Assert.That(parent.GetIntArray().ToList().SequenceEqual(result.GetIntArray()));
            var parentArray2 = parent.GetStringArray();
            var resultArray2 = result.GetStringArray();
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    Assert.That(resultArray2[i, j], Is.EqualTo(parentArray2[i, j]));
                }
            }

            Assert.That(child.Int, Is.EqualTo(result.Child.Int));
            Assert.That(child.String, Is.EqualTo(result.Child.String));
            Assert.That(child.DateTime, Is.EqualTo(result.Child.DateTime));
            Assert.That(child.Int32, Is.EqualTo(result.Child.Int32));
            Assert.That(child.IntArray.ToList().SequenceEqual(result.Child.IntArray));
            var childArray = child.StringArray;
            var resultChildArray = result.Child.StringArray;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    Assert.That(resultChildArray[i, j], Is.EqualTo(childArray[i, j]));
                }
            }

            Assert.That(child.GetInt(), Is.EqualTo(result.Child.GetInt()));
            Assert.That(child.GetString(), Is.EqualTo(result.Child.GetString()));
            Assert.That(child.GetDateTime(), Is.EqualTo(result.Child.GetDateTime()));
            Assert.That(child.GetInt32(), Is.EqualTo(result.Child.GetInt32()));
            Assert.That(child.GetIntArray().ToList().SequenceEqual(result.Child.GetIntArray()));
            var childArray2 = child.GetStringArray();
            var resultChildArray2 = result.Child.GetStringArray();
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    Assert.That(resultChildArray2[i, j], Is.EqualTo(childArray2[i, j]));
                }
            }
        }

        private class Parent
        {
            public Parent(int intval, string stringval, DateTime datetimeval, Int32 int32val, int[] intarray, string[,] stringarray)
            {
                _int = intval;
                _string = stringval;
                _dateTime = datetimeval;
                _int32 = int32val;
                _intArray = intarray;
                _stringArray = stringarray;
            }
            public int Int { get; set; }
            public string String { get; set; }
            public DateTime DateTime { get; set; }
            public Int32 Int32 { get; set; }
            public int[] IntArray { get; set; }
            public string[,] StringArray { get; set; }

            private int _int;
            private string _string;
            private DateTime _dateTime;
            private Int32 _int32;
            private int[] _intArray;
            private string[,] _stringArray;

            public Child Child { get; set; }

            public int GetInt()
            {
                return _int;
            }
            public string GetString()
            {
                return _string;
            }
            public DateTime GetDateTime()
            {
                return _dateTime;
            }
            public Int32 GetInt32()
            {
                return _int32;
            }
            public int[] GetIntArray()
            {
                return _intArray;
            }
            public string[,] GetStringArray()
            {
                return _stringArray;
            }
        }

        private class Child
        {
            public Child(int intval, string stringval, DateTime datetimeval, Int32 int32val, int[] intarray, string[,] stringarray)
            {
                _int = intval;
                _string = stringval;
                _dateTime = datetimeval;
                _int32 = int32val;
                _intArray = intarray;
                _stringArray = stringarray;
            }
            public int Int { get; set; }
            public string String { get; set; }
            public DateTime DateTime { get; set; }
            public Int32 Int32 { get; set; }
            public int[] IntArray { get; set; }
            public string[,] StringArray { get; set; }

            private int _int;
            private string _string;
            private DateTime _dateTime;
            private Int32 _int32;
            private int[] _intArray;
            private string[,] _stringArray;

            public Parent Parent { get; set; }

            public int GetInt()
            {
                return _int;
            }
            public string GetString()
            {
                return _string;
            }
            public DateTime GetDateTime()
            {
                return _dateTime;
            }
            public Int32 GetInt32()
            {
                return _int32;
            }
            public int[] GetIntArray()
            {
                return _intArray;
            }
            public string[,] GetStringArray()
            {
                return _stringArray;
            }

        }
    }
}
