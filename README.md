# DeuceGear

DeuceGear is made as small seperate packages of extensions and base classes.
The purpose is to provide a small library of every day used pieces of logic every developer may need.

## Examples

### DeuceGear.EnumExtensions

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
var emptyResult = LeEnum.EmptyValue.Value
// emptyResult will be "EmptyValue"

var singleResult = LeEnum.SingleValue.Value
// singleResult will be "The value of SingleValue"

var listResult = LeEnum.ListValue.Value
// listResult will be "The first value of ListValue"
```

### DeuceGear.Linq
### DeuceGear.RegexExtensions
### DeuceGear.StringExtensions
