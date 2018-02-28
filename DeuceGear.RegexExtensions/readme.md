[<< Back to main page](../)

# DeuceGear.RegexExtensions

Extension pack targeting Regex

## Match.GetGroupValue(string name)

When a string is matched using regular expressions, we sometimes need to extract a specific group value.
In order to make this a oneliner, the GetGroupValue is implemented.

```cs
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

[<< Back to main page](../)