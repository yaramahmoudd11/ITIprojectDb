namespace ITIprojectDb.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EnrolDate { get; set; }
        public List<Course> Courses { get; set; }
        public Address Address { get; set; }

    }
}
