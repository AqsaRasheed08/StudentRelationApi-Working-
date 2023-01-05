using System;
using System.Collections.Generic;

namespace StudentRelationApi.Models;

public partial class Stud
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public string StudentName { get; set; } = null!;

    public int RollNumb { get; set; }
}
