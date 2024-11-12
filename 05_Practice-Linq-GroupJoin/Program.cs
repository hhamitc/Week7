using _05_Practice_Linq_GroupJoin;

public class Program
{
    public static void Main(string[] args)
    {
        List<Students> studentList = new List<Students>()
        {
            new Students{StuudentId = 1 , StudentName = "Ali" , ClassId = 1},
            new Students{StuudentId = 2 , StudentName = "Ayşe" , ClassId = 2},
            new Students{StuudentId = 3 , StudentName = "Mehmet" , ClassId = 1},
            new Students{StuudentId = 4 , StudentName = "Fatma" , ClassId = 3},
            new Students{StuudentId = 5 , StudentName = "Ahmet" , ClassId = 2}
        };

        List<Classes> classList = new List<Classes>()
        {
            new Classes{ClassId = 1, ClassName = "Matematik" },
            new Classes{ClassId = 2, ClassName = "Türkçe" },
            new Classes{ClassId = 3, ClassName = "Kimya" }
        };


        //var studentAndClasses = classList.GroupJoin(studentList,
        //                                classItem => classItem.ClassId,
        //                                student => student.ClassId,
        //                                (classItem, studentClasses) => new
        //                                {
        //                                    ClassName = classItem.ClassName,
        //                                    Student = studentClasses
        //                                }
        //                                );

        var studentAndClasses = from classItem in classList
                                join student in studentList
                                on classItem.ClassId equals student.ClassId into studentClasses
                                select new
                                {
                                    ClassName = classItem.ClassName,
                                    Student = studentClasses
                                };


        foreach (var student in studentAndClasses)
        {
            Console.WriteLine($"-----------------\nSınıf: {student.ClassName}\n------------------");
            foreach (var item in student.Student)
            {
                Console.WriteLine($"Öğrenci Adı: {item.StudentName} ");
            }

        }


        Console.ReadKey();
    }
}