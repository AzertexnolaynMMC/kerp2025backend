using System;
using System.Collections.Generic;

namespace kerp.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Position { get; set; }

    public int? StructureId { get; set; }

    public int? SectionId { get; set; }

    public bool IsActive { get; set; }

    public bool CanLogin { get; set; }
}
