namespace Assignment1;

public class AgeComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x == null) return -1;
        if (y == null) return 1;
        
        int ageCompare = x.Age.CompareTo(y.Age);
        if (ageCompare != 0)
            return ageCompare;
            
        return x.Marks.CompareTo(y.Marks);
    }
}
