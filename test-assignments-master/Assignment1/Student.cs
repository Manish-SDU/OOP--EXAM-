namespace Assignment1;

public class Student : IComparable<Student>
{
    private string name;
    private int age;
    private string department;
    private string result;
    private double marks;

    public Student(string name, int age, string department, string result, double marks)
    {
        this.name = name;
        this.age = age;
        this.department = department;
        this.result = result;
        this.marks = marks;
    }

    public string Name => name;
    public int Age => age;
    public string Department => department;
    public string Result => result;
    public double Marks => marks;

    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        return this.Marks.CompareTo(other.Marks);
    }

    public override string ToString()
    {
        return string.Format("{0,-15} {1,-15} {2,-15} {3,-15} {4}", 
            Name, Age, Department, Result, Marks);
    }

    static void Main(string[] args)
    {
        var studentSet1 = new SortedSet<Student>();
        
        studentSet1.Add(new Student("Tim", 20, "me", "pass", 9.80));
        studentSet1.Add(new Student("Bo", 21, "me", "pass", 9.20));
        studentSet1.Add(new Student("Ella", 19, "ece", "fail", 3.20));
        studentSet1.Add(new Student("Emma", 19, "ece", "pass", 9.60));
        studentSet1.Add(new Student("Paul", 20, "cse", "pass", 8.60));

        Console.WriteLine($"[{string.Join("\n, ", studentSet1)}\n]");

        var studentSet2 = new SortedSet<Student>(new AgeComparer());
        studentSet2.UnionWith(studentSet1);
        
        Console.WriteLine($"\n[{string.Join("\n, ", studentSet2)}\n]");
    }
}