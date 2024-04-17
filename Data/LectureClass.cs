using System;
using System.Collections.Generic;

namespace SchoolManagementApp.mvc.Data;

public partial class LectureClass
{
    public int Id { get; set; }

    public int? TeacherId { get; set; }

    public int? CourseId { get; set; }

    public TimeOnly? Time { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
