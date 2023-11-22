namespace OU.ApiSchoolDb.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public decimal Grade { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public TypeofExam? TypeofExam { get; set; }
        public Lesson? Lesson { get; set; }

    }
    public enum TypeofExam
    {
        Exam1 = 1,
        Exam2 = 2,
        Exam3 = 3,

    }
    public enum Lesson
    {
        Matematik = 1,
        Türkce = 2

    }
    public class ExamAddDTo 
    {
        public Lesson Lesson { get; set; }
        public TypeofExam TypeofExam { get; set; }
        public int Grade { get; set; }
        public int StudentId { get; set; }


    }
}

