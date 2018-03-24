using System;

namespace DeuceGear.UnitTests.EnumExtensions
{
    
    public enum ULongEnum : ulong
    {
        Empty,
        [EnumTextValue("The value of Single1")]
        Single1,
        [EnumTextValue("The value of Single2")]
        Single2,
        [EnumTextValue("The first value of List")]
        [EnumTextValue("The second value of List")]
        [EnumTextValue("The third value of List")]
        List
    }

    public enum ULongCachingEnum : ulong
    {
        Empty,
        Single1,
        Single2,
        List
    }

    [Flags]
    public enum ULongFlaggedEnum : ulong
    {
        Empty = 1,
        Single1 = 2,
        Single2 = 4,
        List = 8
    }

    [Flags]
    public enum BadULongFlaggedEnum : ulong
    {
        Empty = 1,
        Single1 = 2,
        Single2 = 5,
        List = 10
    }
}
