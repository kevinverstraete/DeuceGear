[<< Back to main page](../)

# DeuceGear.EnumExtensions

Extension pack targeting Enums

## EnumValueAttribute

Define a enum and add EnumValue attributes to the values:
```cs
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
```cs
var emptyResult = LeEnum.EmptyValue.Value()
// emptyResult will be "EmptyValue"

var singleResult = LeEnum.SingleValue.Value()
// singleResult will be "The value of SingleValue"

var listResult = LeEnum.ListValue.Value()
// listResult will be "The first value of ListValue"
```

Get all values if any via the Values method:
```cs
var emptyResult = LeEnum.EmptyValue.Values()
// emptyResult will be an IEnumerable<string> without items

var singleResult = LeEnum.SingleValue.Values()
// singleResult will be an IEnumerable<string> with one item: "The value of SingleValue"

var listResult = LeEnum.ListValue.Values()
// listResult will be an IEnumerable<string> with 2 items: ["The first value of ListValue", "The second value of ListValue"]
```

[<< Back to main page](../)