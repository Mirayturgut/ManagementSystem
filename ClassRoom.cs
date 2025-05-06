namespace Management_System;

public class ClassRoom
{
    public string RoomName { get; set; }
    public List<Student> Students {get; set;} = new   List<Student>();
    public List<Teacher>  Teachers {get; set;} = new  List<Teacher>();
    public string Name { get; set; }
}