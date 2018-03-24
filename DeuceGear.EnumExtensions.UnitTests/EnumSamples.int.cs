using System;

namespace DeuceGear.UnitTests.EnumExtensions
{
    
    public enum IntEnum : int
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

    public enum IntCachingEnum : int
    {
        Empty,
        Single1,
        Single2,
        List
    }

    [Flags]
    public enum IntFlaggedEnum : int
    {
        Empty = 1,
        Single1 = 2,
        Single2 = 4,
        List = 8
    }

    [Flags]
    public enum BadIntFlaggedEnum : int
    {
        Empty = 1,
        Single1 = 2,
        Single2 = 5,
        List = 10
    }


    public enum Int64Enum : Int64
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

    public enum Int64CachingEnum : Int64
    {
        Empty,
        Single1,
        Single2,
        List
    }

    [Flags]
    public enum Int64FlaggedEnum : Int64
    {
        Empty = 1,
        Single1 = 2,
        Single2 = 4,
        List = 8
    }

    [Flags]
    public enum BadInt64FlaggedEnum : Int64
    {
        Empty = 1,
        Single1 = 2,
        Single2 = 5,
        List = 10
    }
}
