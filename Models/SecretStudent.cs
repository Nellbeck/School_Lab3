using System;
using System.Collections.Generic;

namespace School_Lab3.Models;

public partial class SecretStudent
{
    public int StudentNumber { get; set; }

    public string StudentBirthDate { get; set; } = null!;

    public string StudentFirstName { get; set; } = null!;

    public string StudentLastName { get; set; } = null!;
}
