namespace Management_System;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();

    public Student() { }

    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public Student(string firstName, string lastName, string classRoomName)
    {
        FirstName = firstName;
        LastName = lastName;
        ClassRooms = new List<ClassRoom> { new ClassRoom { Name = classRoomName } };
    }

    public static void SaveToTxt(List<Student> students)
    {
        using (var writer = new StreamWriter("kayit.txt"))
        {
            foreach (var student in students)
            {
                var className = student.ClassRooms.FirstOrDefault()?.Name ?? "Yok";
                writer.WriteLine($"{student.FirstName};{student.LastName};{className}");
            }
        }
    }

    public static List<Student> LoadFromTxt()
    {
        var list = new List<Student>();

        if (!File.Exists("ogrenciler.txt"))
            return list;

        var lines = File.ReadAllLines("ogrenciler.txt");

        foreach (var line in lines)
        {
            var parts = line.Split(';');
            if (parts.Length == 3)
            {
                var firstName = parts[0];
                var lastName = parts[1];
                var classroom = parts[2];
                list.Add(new Student(firstName, lastName, classroom));
            }
        }

        return list;
    }
}
 