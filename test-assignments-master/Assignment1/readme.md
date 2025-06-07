# Assignment 1
Assume, you are learning C#. You are introduced to the concepts of Comparable and Comparer interfaces. You need to practice these concepts and compare objects using both interfaces. Considering yourself a student, who needs to master these concepts, you decided to implement a student class such that you can compare student objects using both interfaces.

## Task 1a: Student implements IComparable\<Student\>
A class called `Student.cs` is already created in the folder _Assignment1_. Complete the implementation of the class. Remember to use correct access modifiers for variables and methods.

- Declare 5 variables for `name(string)`, `age(int)`, `department(string)`, `result(string)`, `marks(double)`.
- Create a Constructor to initialize 5 variables.
- Create 5 `get` properties for retrieving the values of all the 5 variables. A `get` property should return the value of the variable.
- Implement a `CompareTo()` method, i.e., compare the `marks` of two `Student` objects. 
Use the corresponding `get` property for this implementation.
- A `ToString() method is already provided to print the students' information. Uncomment it after completing the points above.
- Implement the `Main()` method as such:
    - Create a Set `studentSet1` of type Student with reference to `SortedSet`
    - Create 5 student objects with the following data:
  
    | Name | Age | Department | Result | Marks |
    |------|-----|-----|------|------|
    | Tim  | 20  | me  | pass | 9,80 |
    | Bo   | 21  | me  | pass | 9,20 |
    | Ella | 19  | ece | fail | 3,20 |
    | Emma | 19  | ece | pass | 9,60 |
    | Paul | 20  | cse | pass | 8,60 |

    - Add student objects to the `studentSet1` using `Add()` method
    - Print all elements inside the object `studentSet1`, using the commented `Console.Writeline`
- Run and test your implementation.

**Example** of correct output

Sorting based on marks
```
[Ella            19              ece             fail            3,20
, Paul           20              cse             pass            8,60
, Bo             21              me              pass            9,20
, Emma           19              ece             pass            9,60
, Tim            20              me              pass            9,80
]
```
## Task 1b: Sorting with Comparator

- Create a class `AgeComparer.cs` with the signature `public class AgeComparer : IComparer<Student>`.

- Implement the `Compare()` method to compare two `Student` objects by their `age` values and if two objects 
have the same `age`, they should be compared by their `marks` values. 
(**Hint** : Remember to use the corresponding `get` properties in the `Student` object.

- In the `Main()` method of the `Student` class,
    - Creating another set `studentSet2` of type `Student` with reference to `SortedSet<Student>(new AgeComparer())`
    - Add `studentSet1` to `studentSet2` using `UnionWith()` method.
    - Print all elements inside the object `studentSet2`, using the commented `Console.Writeline`

- Run and test your implementation.

**Example** of correct output

Sorting based on age
```
[Ella            19              ece             fail            3,20
, Emma           19              ece             pass            9,60
, Paul           20              cse             pass            8,60
, Tim            20              me              pass            9,80
, Bo             21              me              pass            9,20
]
```
