using System;
using System.Collections.Generic;

namespace StudentRelationApi.Models;

public partial class Tech
{
    public int TeacherId { get; set; }

    public string TeacherName { get; set; } = null!;

    public int CourseId { get; set; }

    public int Salary { get; set; }
}
