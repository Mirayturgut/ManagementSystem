namespace Management_System;

public class Teacher
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List< ClassRoom> ClassRooms { get; set; } = new  List< ClassRoom >();
    
    public Teacher(string firstName, string LastName)
    {
        FirstName = firstName;
        LastName = LastName;
    }

    public Teacher()
    {
        ClassRooms = new List<ClassRoom>();
    }

    public static void SaveToTxt(List<Teacher>yeniTeachers)
    {
        using (var writer = new StreamWriter("kayit.txt")) // streamWriter en baştan yazar kaldığınız yerden yazmaz
        {
            foreach (var teacher in yeniTeachers)
            {
                writer.WriteLine($"{teacher.FirstName};{teacher.LastName}");
            }
            writer.Close();
        }
    }
    public static List<Teacher> LoadFromTxt()
    {
        var list = new List<Teacher>();
    
        if (!File.Exists("ogretmenler.txt"))
            return list;

        var lines = File.ReadAllLines("ogretmenler.txt");

        foreach (var line in lines)
        {
            var parts = line.Split(';');
            if (parts.Length == 2)
            {
                var firstName = parts[0];
                var lastname = parts[1];
                list.Add(new (firstName, lastname));
            }
        }

        return list;
    }
}