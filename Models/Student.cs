namespace Student_Management_API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
        public double Fees { get; set; }


        public Student(int id, string name, int age, string course, double fees)
        {
            Id = id;
            Name = name;
            Age = age;
            Course = course;
            Fees = fees;
        }
    }
}
