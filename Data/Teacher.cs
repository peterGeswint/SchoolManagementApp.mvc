using System;
using System.Collections.Generic;

namespace SchoolManagementApp.mvc.Data;

public partial class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<LectureClass> LectureClasses { get; set; } = new List<LectureClass>();
}
