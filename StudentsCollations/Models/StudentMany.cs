using System;
using System.Collections.Generic;

namespace StudentsCollations.Models;

public partial class StudentMany
{
    public int StuId { get; set; }

    public string StuName { get; set; } = null!;

    public string StuSurName { get; set; } = null!;

    public string StuEmail { get; set; } = null!;

    public string StuPhoneNo { get; set; } = null!;

    public string StuCourse { get; set; } = null!;

    public int StuCourseFees { get; set; }
}
