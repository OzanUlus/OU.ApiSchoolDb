namespace OU.ApiSchoolDb.Models
{
    public class Student
    {
        public Student()
        {
            Exams = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public List<Exam> Exams { get; set; }
    }
    public enum Gender
    {
        female = 1,
        male = 2

    }
}

