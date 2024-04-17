using System;
using System.Collections.Generic;

namespace SchoolManagementApp.mvc.Data;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int? Credits { get; set; }

    public virtual ICollection<LectureClass> LectureClasses { get; set; } = new List<LectureClass>();
}
