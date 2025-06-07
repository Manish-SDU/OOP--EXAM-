# Assignment 2

You are responsible for managing a small inventory of products. As you are also a gifted C# developer you conclude that you can write a program that does most of the labor for you and saves products to a file and later retrieves their information.
You are provided two classes `Product.cs` and `Helpers.cs`.

## Task 1a
Complete the implementation of `Product.cs`. Remember to use correct access modifiers for variables and methods.

- Declare 3 variables, `itemName(string)`, `quantity(int)`, `shipped(bool)`
- Create a constructor to initialize the 3 variables.
- Implement 3 `get` properties for all the variables.
- Override the `ToString` method, and use the Getter methods in the `ToString()` to print the products' information.
  - An example of the format could be: `itemName=Computer mouse, quantity=1, shipped=False` 
- Implement the `Main()` method as follows:
  - Create 3 product objects with the following data:
  
  | Item name      | Quantity | Shipped |
  |----------------|----------|---------|
  | Computer mouse | 1        | false   |
  | Bike           | 0        | true    |
  | Table          | 0        | true    |

  - Create a List of type  Product.
  - Add product objects to List.
  - Print the list using the following:
    - `Console.WriteLine("{" + string.Join("\n, ", list) + "}");`

**Example** of correct output:

```
List:
{itemName=Computer mouse, quantity=1,shipped=False
, itemName=Bike, quantity=0,shipped=True
, itemName=Table, quantity=0,shipped=True}
```

## Task 1b

Complete the implementation of “Helpers.cs” file.

Implement `WriteToFile(IList<Product> products)` method:

- Use a `StreamWriter` or similar to write to the file “Products.txt”
- Iterate over the objects in the list and write each object using `ToString` method to the file.
- Ensure that you enclose the output stream in a `Try – Catch` clause and close your output stream after use.
- Make sure to catch the exceptions that can be thrown.

Implement `ReadFromFile(String fileName)` method:

- Read an input file “Products.txt” using `StreamReader`
- Iterate over the contents of the file and print it out to the screen.
- Ensure that you enclose the input stream in a `Try – Catch` clause and close your input stream after use.
- Make sure to catch the relevant exceptions that can be thrown

Implement `CheckHasBeenShipped(String fileName)` method
- Read an input file “Products.txt” using `StreamReader`
- Iterate over the contents of the file and print on screen only those products which have been shipped (shipped=True).
- Ensure that you enclose the input stream in a `Try – Catch` clause and close your input stream after use.
- Make sure to catch the relevant exceptions that can be thrown.

## Task 1c

Finally, call/invoke your helper methods in the Main method of `Product.cs`. Assuming, the `productList`
comprises 3 product objects, first call `WriteToFile()` method and pass `productList` as an argument, 
then call `ReadFromFile()` method and pass "Products.txt" as an argument and finally call `CheckHasBeenShipped()` 
method and pass "Products.txt" as an argument.

**Example** of correct output (all methods are invoked):

```
From File:
itemName=Computer mouse, quantity=1,shipped=False
itemName=Bike, quantity=0,shipped=True
itemName=Table, quantity=0,shipped=True

Only shipped:
itemName=Bike, quantity=0,shipped=True
itemName=Table, quantity=0,shipped=True
```
