using System;
using System.Collections.Generic;

namespace StudentRelationApi.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;
}
