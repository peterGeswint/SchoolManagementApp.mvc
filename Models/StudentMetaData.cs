using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.mvc.Data
{
    public class StudentMetaData
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Date Of Birth")]
        public string? DateOfBirth { get; set; }
    }

    [MetadataType(typeof(StudentMetaData))]
    public partial class Student{}
}