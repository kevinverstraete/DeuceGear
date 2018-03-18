[<< Back to main page](../)

# DeuceGear.EnumExtensions

Extension pack targeting Enums

## EnumTextValueAttribute

Define a enum and add EnumTextValue attributes to the values:
```cs
public enum LeEnum
{
    EmptyValue,
    [EnumTextValue("The value of SingleValue")] 
    SingleValue,
    [EnumTextValue("The first value of ListValue")]
    [EnumTextValue("The second value of ListValue")] 
    ListValue
}
```

Get the first available value using the TextValue method. If no value is found, the method reverts to ToString():
```cs
var emptyResult = LeEnum.EmptyValue.TextValue()
// emptyResult will be "EmptyValue"

var singleResult = LeEnum.SingleValue.TextValue()
// singleResult will be "The value of SingleValue"

var listResult = LeEnum.ListValue.TextValue()
// listResult will be "The first value of ListValue"
```

Get all values if any via the TextValues method:
```cs
var emptyResult = LeEnum.EmptyValue.TextValues()
// emptyResult will be an IEnumerable<string> without items

var singleResult = LeEnum.SingleValue.TextValues()
// singleResult will be an IEnumerable<string> with one item: "The value of SingleValue"

var listResult = LeEnum.ListValue.TextValues()
// listResult will be an IEnumerable<string> with 2 items: ["The first value of ListValue", "The second value of ListValue"]
```

### Breaking changes
##### v1.0.0 > v1.0.1
- **EnumValueAttribute** got renamed to **EnumTextValueAttribute**


# Enums

DeuceGear.Enums contains commonly used methods for Enums.

## EnumList

DeuceGear.Enums.EnumList\<T\>() gives you a list of possible enum values for the given type \<T\>.
The first call to this method caches the data to make future calls for this type much faster.
In other words, if you only need the list once, stick with "typeof(T).GetEnumValues()".

```cs
var result = Enums.EnumList<LeEnum>()
// result while be an IEnumerable of Enums.
```

This method has also a little brother, namely DeuceGear.Enums.EnumIntList\<T\>().
This returns a simple array of integers with all possible values.

[<< Back to main page](../)