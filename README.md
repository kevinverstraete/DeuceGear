# DeuceGear

DeuceGear is made as small seperate packages of extensions and base classes.
The purpose is to provide a small library of every day used pieces of logic every developer may need.

## Examples

### DeuceGear.EnumExtensions

Extension pack targeting Enums

#### EnumValueAttribute

Define a enum and add EnumValue attributes to the values:
```
public enum LeEnum
{
  EmptyValue,
  [EnumValue("The value of SingleValue")] 
  SingleValue,
  [EnumValue("The first value of ListValue")]
  [EnumValue("The second value of ListValue")] 
  ListValue
}
```

Get the first available value using the Value method. If no value is found, the method reverts to ToString():
```
var emptyResult = LeEnum.EmptyValue.Value()
// emptyResult will be "EmptyValue"

var singleResult = LeEnum.SingleValue.Value()
// singleResult will be "The value of SingleValue"

var listResult = LeEnum.ListValue.Value()
// listResult will be "The first value of ListValue"
```

Get all values if any via the Values method:
```
var emptyResult = LeEnum.EmptyValue.Values()
// emptyResult will be an IEnumerable<string> without items

var singleResult = LeEnum.SingleValue.Values()
// singleResult will be an IEnumerable<string> with one item: "The value of SingleValue"

var listResult = LeEnum.ListValue.Values()
// listResult will be an IEnumerable<string> with 2 items: ["The first value of ListValue", "The second value of ListValue"]
```

### DeuceGear.Linq

Extra features that may come in handy while using Linq.

#### Specifications

Linq specifications are made for 2 reasons. The first reason is to guard a developer of writing
the same expression every time he needs it. The second is making basic operations possible on
linq expressions (and, or, not).

As sample we use a simple class:
```
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

We have a list object where we want to execute some filters on:
```
Data = new List<Sample>()
{
	new Sample("Jose", "Rodriguez"),
	new Sample("Manuel", "Rivera"),
	new Sample("Julian", "Mendez"),
}.AsQueryable();
```

##### Basic operations

Multiple expressions can now be manuipulated with some basic operations (or, and, not):
```
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

##### Custom specifications

If a specific Expression is used over and over, it is possible to contain it within a custom expression:
```
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
```
var spec = new FirstNameSpecification("Julian");
var result = Data.Where(spec.IsSatisfied());
```

##### AdHoc Specification

Creating a custom specification can be made AdHoc:
```
var spec = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("J"));
var result = Data.Where(spec.IsSatisfied());
```

##### Selector Specification

A Selector Specification exists so easy criteria can be made, controllered by the UI for example
```
var spec = new SelectorSpecification<Sample, string>(x => x.FirstName, Operation.StartsWith, "J");
var result = Data.Where(spec.IsSatisfied());
```

##### Specification Operations

Specifications can also be controlled via operations: 
```
var specFirstName = new AdHocSpecification<Sample>(x => x.FirstName.StartsWith("J"));
var specLastName = new AdHocSpecification<Sample>(x => x.LastName.StartsWith("M"));

var specAnd = specFirstName && specLastName;
var specOr = specFirstName || specLastName;
var specNot = !specFirstName;
```

This could come handy in cases where input in the UI determines what filters need to be used. 
Just build up the specification according to the input parameters.

### DeuceGear.RegexExtensions

Extension pack targeting Regex

#### Match.GetGroupValue(string name)

When a string is matched using regular expressions, we sometimes need to extract a specific group value.
In order to make this a oneliner, the GetGroupValue is implemented.

```
var phoneNumbers = "050/12.34.56 051/23.45.67 052/15.97.53 053/98.76.54";
var pattern = @"(?<area>\d{3})/(?<number>\d{2}.\d{2}.\d{2})"; ;
var matches = Regex.Matches(phoneNumbers, pattern);

// there will be fore matches, we'll get the group values from the first one
var areaValue = matches[0].GetGroupValue("area");
var numberValue = matches[0].GetGroupValue("number");
var emptyValue = matches[0].GetGroupValue("bob");

// areaValue will be "050"
// numberValue will be "12.34.56"
// emptyValue will be string.Emptyt because the "bob" group does not exist

```

### DeuceGear.StringExtensions

Extension pack targeting Strings

#### Left(int length)

A standard left implementation.
- Negative values return an exception.
- if more characters are asked than available, just return what's there

#### Right(int length)

A standard right implementation.
- Negative values return an exception.
- if more characters are asked than available, just return what's there
