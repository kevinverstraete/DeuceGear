# DeuceGear.Linq

Extra features that may come in handy while using Linq.

## Testdata

To make the DeuceGear.Linq samples easier, we use a basic class:
```cs
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
```

We alse defined a small list of objects:
```cs
Data = new List<Sample>()
{
	new Sample("Jose", "Rodriguez"),
	new Sample("Manuel", "Rivera"),
	new Sample("Julian", "Mendez"),
}.AsQueryable();
```

## IEnumerable/IQueryable Extensions

### OrderBy(specification, sortDirection)

IQueryable and IEnumerable can use the method OrderBy(specification, SortDirection). 
This way it's easy to determine the sort direction of a list without the need of an if and 
OrderBy or OrderByDescending logic.

```cs
var result = TestData.List.OrderBy(c => c.LastName, SortDirection.Ascending);
```

### ThenBy(specification, sortDirection)

IOrderedQueryable and IOrderedEnumerable can use the method ThenBy(specification, SortDirection). 
This way it's easy to determine the sort direction of a list without the need of an if and 
ThenBy or ThenByDescending logic.

```cs
var result = TestData.List
             .OrderBy(c => c.LastName.Substring(0, 1), SortDirection.Descending)
             .ThenBy(c => c.LastName.Substring(1, 1), SortDirection.Descending);
```

### Paging(pageSize, numberOfPagesToSkip)

Paging implementation on IQueryable and IEnumerable.

```cs
var pageSize = 2;
var numberOfPagesToSkip = 1;
var result = TestData.List.Paging(pageSize, numberOfPagesToSkip);
```

## Specifications

Linq specifications are made for 2 reasons. The first reason is to guard a developer of writing
the same expression every time he needs it. The second is making basic operations possible on
linq expressions (and, or, not).

### Basic operations

Multiple expressions can now be manipulated with some basic operations (or, and, not):
```cs
Expression<Func<Sample, bool>> specFirstName = x => x.FirstName.StartsWith("M");
Expression<Func<Sample, bool>> specLastName = x => x.LastName.StartsWith("M");

var orExpression = specFirstName.Or(specLastName);
var andExpression = specFirstName.And(specLastName)
var notExpression = ExpressionExtensions.Not(specFirstName);

var orResult = Data.Where(orExpression);
// orResult will contain "Manuel Rivera" and "Julian Mendez"

var andResult = Data.Where(andExpression);
// andResult will contain zero results

var notResult = Data.Where(notExpression);
// notResult will contain "Jose Rodriguez" and "Julian Mendez"
```

### Custom specifications

If a specific Expression is used over and over, it is possible to contain it within a custom expression:
```cs
public class FirstNameSpecification : Specification<Sample>
{
	private string _firstName;
    public FirstNameSpecification(string firstName)
    {
		_firstName = firstName;
    }
    
	public override Expression<Func<Sample, bool>> IsSatisfied()
    {
		return c => c.FirstName == _firstName;
    }
}
```

Use:
```cs
var spec = new FirstNameSpecification("Julian");
var result = Data.Where(spec.IsSatisfied());
```

### AdHoc Specification

Creating a custom specification can be made AdHoc:
```cs
var spec = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("J"));
var result = Data.Where(spec.IsSatisfied());
```

### Selector Specification

A Selector Specification exists so easy criteria can be made, controllered by the UI for example
```cs
var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, Operation.StartsWith, "J");
var result = Data.Where(spec.IsSatisfied());
```

### Specification Operations

Specifications can also be controlled via operations: 
```cs
var specFirstName = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("J"));
var specLastName = new AdHocSpecification<Sample>(x => x.LastName.StartsWith("M"));

var specAnd = specFirstName && specLastName;
var specOr = specFirstName || specLastName;
var specNot = !specFirstName;
```

This could come handy in cases where input in the UI determines what filters need to be used. 
Just build up the specification according to the input parameters.