using System;

namespace DeuceGear.UnitTests.EnumExtensions
{
    public enum LeEnum
    {
        Empty,
        [EnumValue("The value of Single1")]
        Single1,
        [EnumValue("The value of Single2")]
        Single2,
        [EnumValue("The first value of List")]
        [EnumValue("The second value of List")]
        [EnumValue("The third value of List")]
        List
    }

    [Flags]
    public enum LeFlaggedEnum
    {
        Empty = 1,
        [EnumValue("The value of Single1")]
        Single1 = 2,
        [EnumValue("The value of Single2")]
        Single2 = 4,
        [EnumValue("The first value of List")]
        [EnumValue("The second value of List")]
        [EnumValue("The third value of List")]
        List = 8
    }
}
