using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITIprojectDb.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [DisplayName("Instructor Name")]
        public string Name { get; set; }
        public List<Course>? Courses { get; set; }

    }
}
