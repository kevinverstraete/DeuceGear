﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DeuceGear.Linq.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class TestData
    {
        public static readonly IQueryable<Sample> List = new List<Sample>()
            {
                new Sample("Jose", "Rodriguez"),
                new Sample("Manuel", "Rivera"),
                new Sample("Julian", "Mendez"),
            }.AsQueryable();
    }

    public class Sample
    {
        public Sample(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
