using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeuceGear.UnitTests.EnumExtensions
{
    [TestFixture]
    public partial class EnumExtensionsTestFixture
    {
        [Test]
        public void EnumExtensionsTextValuesTestForUnknownValue()
        {
            EnumExtensionsTextValuesPrivate((ByteEnum)13, null);
            EnumExtensionsTextValuesPrivate((IntEnum)13, null);
            EnumExtensionsTextValuesPrivate((LongEnum)13, null);
            EnumExtensionsTextValuesPrivate((RegularEnum)13, null);
            EnumExtensionsTextValuesPrivate((SByteEnum)13, null);
            EnumExtensionsTextValuesPrivate((ShortEnum)13, null);
            EnumExtensionsTextValuesPrivate((UIntEnum)13, null);
            EnumExtensionsTextValuesPrivate((ULongEnum)13, null);
            EnumExtensionsTextValuesPrivate((UShortEnum)13, null);
        }

        [Test]
        public void EnumExtensionsTextValuesTestForEmptyValue()
        {
            EnumExtensionsTextValuesPrivate(ByteEnum.Empty, null);
            EnumExtensionsTextValuesPrivate(IntEnum.Empty, null);
            EnumExtensionsTextValuesPrivate(LongEnum.Empty, null);
            EnumExtensionsTextValuesPrivate(RegularEnum.Empty, null);
            EnumExtensionsTextValuesPrivate(SByteEnum.Empty, null);
            EnumExtensionsTextValuesPrivate(ShortEnum.Empty, null);
            EnumExtensionsTextValuesPrivate(UIntEnum.Empty, null);
            EnumExtensionsTextValuesPrivate(ULongEnum.Empty, null);
            EnumExtensionsTextValuesPrivate(UShortEnum.Empty, null);
                    }

        [Test]
        public void EnumExtensionsTextValuesTestForKnownSingleValue()
        {
            var list = new List<String> { "The value of Single1" };

            EnumExtensionsTextValuesPrivate(ByteEnum.Single1, list);
            EnumExtensionsTextValuesPrivate(IntEnum.Single1, list);
            EnumExtensionsTextValuesPrivate(LongEnum.Single1, list);
            EnumExtensionsTextValuesPrivate(RegularEnum.Single1, list);
            EnumExtensionsTextValuesPrivate(SByteEnum.Single1, list);
            EnumExtensionsTextValuesPrivate(ShortEnum.Single1, list);
            EnumExtensionsTextValuesPrivate(UIntEnum.Single1, list);
            EnumExtensionsTextValuesPrivate(ULongEnum.Single1, list);
            EnumExtensionsTextValuesPrivate(UShortEnum.Single1, list);        }


        [Test]
        public void EnumExtensionsTextValuesTestForKnownValue()
        {
            var list = new List<String> { "The first value of List", "The second value of List", "The third value of List" };

            EnumExtensionsTextValuesPrivate(ByteEnum.List, list);
            EnumExtensionsTextValuesPrivate(IntEnum.List, list);
            EnumExtensionsTextValuesPrivate(LongEnum.List, list);
            EnumExtensionsTextValuesPrivate(RegularEnum.List, list);
            EnumExtensionsTextValuesPrivate(SByteEnum.List, list);
            EnumExtensionsTextValuesPrivate(ShortEnum.List, list);
            EnumExtensionsTextValuesPrivate(UIntEnum.List, list);
            EnumExtensionsTextValuesPrivate(ULongEnum.List, list);
            EnumExtensionsTextValuesPrivate(UShortEnum.List, list);
        }

        #region Tests logic
        private void EnumExtensionsTextValuesPrivate(Enum @enum, List<string> expected)
        {
            // arrange/
            expected = expected ?? new List<string>();
            var count = expected.Count;
            
            // Act
            var values = @enum.TextValues().ToList();

            // Assert
            Assert.That(values.Count(), Is.EqualTo(count));
            for (int i = 0; i < count; i++)
            {
                Assert.That(values[i], Is.EqualTo(expected[i]));
            }
        }
        #endregion Tests logic
    }
}
