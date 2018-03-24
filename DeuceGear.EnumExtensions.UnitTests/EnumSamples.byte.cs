using System;

namespace DeuceGear.UnitTests.EnumExtensions
{
    
    public enum ByteEnum : byte
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

    public enum ByteCachingEnum : byte
    {
        Empty,
        Single1,
        Single2,
        List
    }

    [Flags]
    public enum ByteFlaggedEnum : byte
    {
        Empty = 1,
        Single1 = 2,
        Single2 = 4,
        List = 8
    }

    [Flags]
    public enum BadByteFlaggedEnum : byte
    {
        Empty = 1,
        Single1 = 2,
        Single2 = 5,
        List = 10
    }
}
