using Student_Management_API.Models;

namespace Student_Management_API.Repository
{
    public static class StudentRepository
    {
        public static List<Student> students = new List<Student> {

    new Student(1, "John Doe", 20, "B.TECH", 45000.00),
    new Student(2, "Jane Smith", 22, "BCA", 50200.00),
    new Student(3, "Michael Johnson", 19, "B.TECH", 36800.00),
    new Student(4, "Emily Davis", 21, "BCA", 42000.00),
    new Student(5, "William Brown", 23, "BCA", 48000.00),
    new Student(6, "Olivia Wilson", 20, "BCA", 39000.00),
    new Student(7, "James Taylor", 22, "B.TECH", 55000.00),
    new Student(8, "Sophia Anderson", 19, "BCA", 41000.00),
    new Student(9, "Daniel Thomas", 21, "BCA", 47000.00),
    new Student(10, "Ava Martinez", 20, "BCA", 43000.00),

    };
        public static List<Student> GetAllStudent()
        {
            return students;

        }
        public static Student? GetStudentbyId(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);

        }
        public static List<Student> GetStudentbyCourse(string course)
        {
            return students.Where<Student>(x => x.Course == course).ToList();

        }
        public static List<Student> GetStudentbyfees(double fees)
        {
            return students.Where<Student>(x => x.Fees > fees).ToList();
        }
        public static bool AddStudent(Student? student)
        {
            var newstd = students.FirstOrDefault(x => x.Id == student.Id);
            if (newstd == null)
            {
                students.Add(student);
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool UpdateStudent(Student? student)
        {
            var newstd = students.FirstOrDefault(x => x.Id == student.Id);
            if (newstd is not null)
            {
                newstd.Id = student.Id;
                newstd.Name = student.Name;
                newstd.Course = student.Course;
                newstd.Age = student.Age;
                newstd.Fees = student.Fees;

                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DeleteStudent(int id)
        {
            var dltstd = students.FirstOrDefault(x => x.Id == id);
            if (dltstd is not null)
            {
                students.Remove(dltstd);
                return true;
            }
            else
                return false;
        }


    }
}
