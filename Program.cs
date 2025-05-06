
using Management_System;

var students = new List<Student>
{
   new Student { FirstName = "Miray", LastName = "Turgut" },
   new Student { FirstName = "Janset", LastName = "Ergen"},
   new Student { FirstName = "Arda", LastName = "Aslantürk"},
   new Student { FirstName = "Yaren", LastName = "Karslı"},
};
var  teachers = new List<Teacher>
{
   new Teacher { FirstName = "Orhan", LastName = "Ekici" },
   new Teacher { FirstName = "Nihat", LastName = "Duysak" },
   new Teacher { FirstName = "Ayşe", LastName = "Güler" },
};
var  classRooms = new List<ClassRoom>
{
   new ClassRoom { RoomName = "BE Focus"},
   new ClassRoom { RoomName = "BE Flex"},
   new ClassRoom { RoomName = "FE Focus/Flex"},
};
// Miray --> BE Focus
classRooms[0].Students.Add(students[0]);
students[0].ClassRooms.Add(classRooms[0]);
//Janset --> BE Flex
classRooms[1].Students.Add(students[1]);
students[1].ClassRooms.Add(classRooms[1]);
//Arda --> FE Focus/Flex
classRooms[2].Students.Add(students[2]);
students[2].ClassRooms.Add(classRooms[2]);
//Yaren --> BE Focus
classRooms[2].Students.Add(students[3]);
students[3].ClassRooms.Add(classRooms[2]);

//Orhan Hoca --> BE Focus
classRooms[0].Teachers.Add(teachers[0]);
teachers[0].ClassRooms.Add(classRooms[0]);
//Nihat Hoca --> BE Flex
classRooms[1].Teachers.Add(teachers[1]);
teachers[1].ClassRooms.Add(classRooms[1]);
// Ayşe hoca --> FE Focus/Flex
classRooms[2].Teachers.Add(teachers[2]);
teachers[2].ClassRooms.Add(classRooms[2]);

List<ClassRoom> classRooms2 = new List<ClassRoom>();

while (true)
{
    Console.Clear();
    var inputSecim = Helper.AskOption("Yapmak istediğiniz işlemi seçin",
        ["Öğrenci Yönetimi", "Öğretmen Yönetimi", "Sınıf Yönetimi", "Çıkış"]);
    if (inputSecim == 1)
    {
        while (true)
        {
            Console.Clear();
            var studentOption = Helper.AskOption("Öğrenci işlemi seçin:", new[]
            {
                "Öğrenci Ekle",
                "Öğrenci Listele",
                "Öğrenci Sil",
                "Geri Dön"
            });

            if (studentOption == 1)
            {
                Console.Clear();
                Console.WriteLine("--- Yeni Öğrenci Kaydı ---");
                var inputFirstName = Helper.Ask("Öğrenci adı giriniz");
                var inputLastName = Helper.Ask("Öğrenci soyadı giriniz");

                Console.WriteLine("Sınıf seçin:");
                for (int i = 0; i < classRooms.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {classRooms[i].RoomName}");
                }

                var classIndex = Helper.AskNumber("Sınıf numarası:") - 1;
                if (classIndex < 0 || classIndex >= classRooms.Count)
                {
                    Helper.ShowErrorMsg("Geçersiz sınıf seçimi.");
                    continue;
                }

                var selectedClass = classRooms[classIndex];

                var newStudent = new Student(inputFirstName, inputLastName);
                students.Add(newStudent);
                selectedClass.Students.Add(newStudent);
                newStudent.ClassRooms.Add(selectedClass);

                Helper.ShowSuccessMsg("Öğrenci başarıyla eklendi.");
            }
            else if (studentOption == 2)
            {
                Console.Clear();
                Console.WriteLine("--- Öğrenciler ---");
                if (students.Count == 0)
                {
                    Console.WriteLine("Hiç öğrenci kaydı yok.");
                }
                else
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"Adı: {student.FirstName} {student.LastName}");
                        foreach (var room in student.ClassRooms)
                        {
                            Console.WriteLine($"- Sınıf: {room.RoomName}");
                        }

                        Console.WriteLine("------------------------");
                    }
                }

                Console.ReadKey();
            }
            else if (studentOption == 3)
            {
                Console.Clear();
                if (students.Count == 0)
                {
                    Console.WriteLine("Silinecek öğrenci yok.");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("Silinecek öğrenciyi seçin:");
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {students[i].FirstName} {students[i].LastName}");
                }

                var secim = Helper.AskNumber("Numara:") - 1;
                if (secim < 0 || secim >= students.Count)
                {
                    Helper.ShowErrorMsg("Geçersiz seçim");
                    continue;
                }

                var silinecek = students[secim];
                foreach (var room in silinecek.ClassRooms)
                {
                    room.Students.Remove(silinecek);
                }

                students.Remove(silinecek);
                Helper.ShowSuccessMsg("Öğrenci silindi");
            }
            else if (studentOption == 4)
            {
                break;
            }
        }
    }
    else if (inputSecim == 2)
    {
        while (true)
        {
            Console.Clear();
            var teacherOption = Helper.AskOption("Öğretmen işlemi seçin:", new[]
            {
                "Öğretmen Ekle",
                "Öğretmen Listele",
                "Öğretmen Sil",
                "Geri Dön"
            });
            if (teacherOption == 1)
            {
                Console.Clear();
                Console.WriteLine("--- Yeni Öğretmen Kaydı ---");
                var inputFirstName = Helper.Ask("Öğretmen adı giriniz");
                var inputLastName = Helper.Ask("Öğretmen soyadı giriniz");

                Console.WriteLine("Sınıf seçin:");
                for (int i = 0; i < classRooms.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {classRooms[i].RoomName}");
                }

                var classIndex = Helper.AskNumber("Sınıf numarası:") - 1;
                if (classIndex < 0 || classIndex >= classRooms.Count)
                {
                    Helper.ShowErrorMsg("Geçersiz sınıf seçimi");
                    continue;
                }

                var selectedClass = classRooms[classIndex];

                var newTeacher = new Teacher(inputFirstName, inputLastName);
                teachers.Add(newTeacher);
                selectedClass.Teachers.Add(newTeacher);
                newTeacher.ClassRooms.Add(selectedClass);

                Helper.ShowSuccessMsg("Öğrenci başarıyla eklendi");
            }
            else if (teacherOption == 2)
            {
                Console.Clear();
                Console.WriteLine("--- Öğretmenler ---");
                if (teachers.Count == 0)
                {
                    Console.WriteLine("Hiç öğretmen kaydı yok.");
                }
                else
                {
                    foreach (var teacher in teachers)
                    {
                        Console.WriteLine($"Adı: {teacher.FirstName} {teacher.LastName}");
                        foreach (var room in teacher.ClassRooms)
                        {
                            Console.WriteLine($"Sınıf: {room.RoomName}");
                        }

                        Console.WriteLine("-------------------------");
                    }
                }

                Console.ReadKey();
            }
            else if (teacherOption == 3)
            {
                Console.Clear();
                if (teachers.Count == 0)
                {
                    Console.WriteLine("Silinecek öğretmen yok.");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("Silinecek Öğretmeni seçin:");
                for (int i = 0; i < teachers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {teachers[i].FirstName},{teachers[i].LastName}");
                }

                var secim = Helper.AskNumber("Numara:") - 1;
                if (secim < 0 || secim >= teachers.Count)
                {
                    Helper.ShowErrorMsg("Geçersiz seçim.");
                    continue;
                }

                var silinecek = teachers[secim];
                foreach (var room in silinecek.ClassRooms)
                {
                    room.Teachers.Remove(silinecek);
                }

                teachers.Remove(silinecek);
                Helper.ShowSuccessMsg("Öğretmen silindi");
            }
            else if (teacherOption == 4)
            {
                break;
            }
        }
    }
    else if (inputSecim == 3)
    {
        while (true)
        {
            Console.Clear();
            var sinifSecim = Helper.AskOption("Sınıf yönetimi için seçim yapınız:",
                new[] { "Sınıf Ekle", "Sınıfları Listele", "Sınıf Sil", "Ana Menü" });

            if (sinifSecim == 1) // Sınıf Ekle
            {
                Console.Clear();
                Console.WriteLine("----Yeni Sınıf Kaydı----");
                var inputRoomName = Helper.Ask("Sınıf adı giriniz:");
                var newClass = new ClassRoom { RoomName = inputRoomName };
                classRooms.Add(newClass);
                Console.WriteLine("Sınıf başarıyla eklendi!");
                Helper.ShowSuccessMsg("Ana menüye dönülüyor.");
                Thread.Sleep(2000);
            }
            else if (sinifSecim == 2) // Sınıf Listele
            {
                Console.Clear();
                Console.WriteLine("----Sınıflar ve İçeriği----");

                if (classRooms.Count == 0)
                {
                    Console.WriteLine("Henüz hiç sınıf yok.");
                }
                else
                {
                    foreach (var sinif in classRooms)
                    {
                        Console.WriteLine($"Sınıf Adı: {sinif.RoomName}");

                        Console.WriteLine("Öğrenciler:");
                        if (sinif.Students.Count == 0)
                            Console.WriteLine("- Yok");
                        else
                            foreach (var student in sinif.Students)
                                Console.WriteLine($"- {student.FirstName} {student.LastName}");

                        Console.WriteLine("Öğretmenler:");
                        if (sinif.Teachers.Count == 0)
                            Console.WriteLine("- Yok");
                        else
                            foreach (var teacher in sinif.Teachers)
                                Console.WriteLine($"- {teacher.FirstName} {teacher.LastName}");

                        Console.WriteLine("----------------------------");
                    }
                }

                Console.WriteLine("Ana menüye dönmek için bir tuşa basın...");
                Console.ReadKey(true);
            }
            else if (sinifSecim == 3) // Sınıf Sil
            {
                Console.Clear();
                Console.WriteLine("----Sınıf Sil----");
                if (classRooms.Count == 0)
                {
                    Console.WriteLine("Silinecek sınıf yok.");
                    Helper.ShowErrorMsg("Ana menüye dönülüyor.");
                    Thread.Sleep(2000);
                    continue;
                }

                for (int i = 0; i < classRooms.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {classRooms[i].RoomName}");
                }

                var sinifNo = Helper.AskNumber("Silmek istediğiniz sınıfın numarasını girin:");
                if (sinifNo < 1 || sinifNo > classRooms.Count)
                {
                    Helper.ShowErrorMsg("Geçersiz seçim.");
                    Thread.Sleep(2000);
                    continue;
                }

                var secilenSinif = classRooms[sinifNo - 1];
                Console.WriteLine($"Seçilen sınıf: {secilenSinif.RoomName}");
                var cevap = Console.ReadLine()?.ToLower();

                if (cevap == "e")
                {
                    // Öğrenci ve öğretmen listesinden de kaldır
                    foreach (var student in secilenSinif.Students)
                        student.ClassRooms.Remove(secilenSinif);

                    foreach (var teacher in secilenSinif.Teachers)
                        teacher.ClassRooms.Remove(secilenSinif);

                    classRooms.Remove(secilenSinif);
                    Helper.ShowSuccessMsg("Sınıf silindi.");
                }
                else
                {
                    Console.WriteLine("Silme işlemi iptal edildi.");
                }
            }
            else if (sinifSecim == 4) // Ana Menü
            {
                break;
            }
        }
    }
    else if (inputSecim == 4)
    {
        Console.Clear();
        Console.WriteLine("Programdan çıkılıyor...Hoşçakal!");
        Thread.Sleep(3000);
        break;
    }
}  
       