namespace Assignment1;

public class Student : IComparable<Student>
{
    
    // Uncomment this once done. Make sure you use the right names of 'get' properties in the ToString()
    // public override String ToString() {
    //     return $"{Name} \t \t {Age} \t \t {Department} \t \t {Result} \t \t {Marks:.00}\n";
    // }

    public int CompareTo(Student? s)
    {
        throw new NotImplementedException("Not implemented yet!");
    }

    public static void Main(string[] args)
    {
        // Task 1a
        // Console.WriteLine("Sorting based on Marks");
        
        
        // Console.WriteLine("[" + string.Join(", ", studentSet1) + "]");

        // Task 1b
        // Console.WriteLine("Sorting based on Age");
        

        // Console.WriteLine("[" + string.Join(", ", studentSet2) + "]");
    }
}