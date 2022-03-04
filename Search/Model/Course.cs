namespace Search.Model
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}
