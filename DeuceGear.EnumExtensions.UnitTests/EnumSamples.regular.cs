﻿using System;

namespace DeuceGear.UnitTests.EnumExtensions
{
    public enum RegularEnum
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

    public enum RegularCachingEnum
    {
        Empty,
        Single1,
        Single2,
        List
    }

    [Flags]
    public enum RegularFlaggedEnum
    {
        Empty = 1,
        Single1 = 2,
        Single2 = 4,
        List = 8
    }

    [Flags]
    public enum RegularBadFlaggedEnum
    {
        Empty = 1,
        Single1 = 2,
        Single2 = 5,
        List = 10
    }
}
