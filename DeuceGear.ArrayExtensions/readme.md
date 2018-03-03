[<< Back to main page](../)

# DeuceGear.ArrayExtensions

Extension pack targeting Arrays

## Add

With this method you can add a element to the end of an existing array.

```cs
var array = new string[] { "a", "b", "c" };
var newArray = source.Add("d");
// the array now contains ["a","b","c","d"]
```

## IndexExists

Accessing an array with an invalid index throws an exception. 
Everyone kinda writes the same logic to test the validity of an index.

1-Dimensional:
```cs
var array = new int[3];
var result = array.IndexExists(<index>);
```

Multidimensional:
```cs
var array = new int[3, 2];
var result = ar.IndexExists(<index>, <dimension>);
```

## Indices

This method results in a list of all possible indices within the array.
This indices allow you to loop through an array without knowing it's dimensions.

```cs
var array = new string[2, 3, 2];
array[0, 0, 0] = "000";
array[0, 0, 1] = "001";
array[0, 1, 0] = "010";
array[0, 1, 1] = "011";
array[0, 2, 0] = "020";
array[0, 2, 1] = "021";
array[1, 0, 0] = "100";
array[1, 0, 1] = "101";
array[1, 1, 0] = "110";
array[1, 1, 1] = "111";
array[1, 2, 0] = "120";
array[1, 2, 1] = "121";

foreach (var index in source.Indices())
{
    var value = source.GetValue(index);
}
```

## IsNullOrEmpty

IsNullOrEmpty() verifies if an array is a Null reference or has no elements at all.

## Merge

With Merge you can merge 2 1-dimensional array together.
```cs
var source = new string[] { "a", "b", "c" };
var toAdd = new string[] { "d", "e", "f" };
var result = source.Merge(toAdd);
// result now contains ["a","b","c","d","e","f"]
```


[<< Back to main page](../)