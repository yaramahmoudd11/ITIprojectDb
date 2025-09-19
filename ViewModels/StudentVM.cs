using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITIprojectDb.ViewModels
{
    public class StudentVM
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime EnrolDate { get; set; }

        [DisplayName("Student City")]
        [MinLength(5,ErrorMessage ="must be contain more than 4 characters")]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "street is required")]
        public string street { get; set; }
    }
}
