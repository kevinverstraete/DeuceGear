# DeuceGear

DeuceGear is made as small seperate packages of extensions and base classes.
The purpose is to provide a small library of every day used pieces of logic every developer may need.

## Examples

### DeuceGear.EnumExtensions

Extension pack targeting Enums

#### EnumValueAttribute

Define a enum and add EnumValue attributes to the values.

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

Get the first available value using the Value method. If no value is found, the method reverts to ToString()

```
var emptyResult = LeEnum.EmptyValue.Value()
// emptyResult will be "EmptyValue"

var singleResult = LeEnum.SingleValue.Value()
// singleResult will be "The value of SingleValue"

var listResult = LeEnum.ListValue.Value()
// listResult will be "The first value of ListValue"
```

Get all values if any via the Values method.
```
var emptyResult = LeEnum.EmptyValue.Values()
// emptyResult will be an IEnumerable<string> without items

var singleResult = LeEnum.SingleValue.Values()
// singleResult will be an IEnumerable<string> with one item: "The value of SingleValue"

var listResult = LeEnum.ListValue.Values()
// listResult will be an IEnumerable<string> with 2 items: ["The first value of ListValue", "The second value of ListValue"]
```

### DeuceGear.Linq

Extra features that may come in handy while using Linq

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
