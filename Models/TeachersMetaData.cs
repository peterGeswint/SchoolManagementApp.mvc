using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.mvc.Data
{
    public class TeachersMetaData
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
    }

    [MetadataType(typeof(TeachersMetaData))]
    public partial class Teachers{}

}