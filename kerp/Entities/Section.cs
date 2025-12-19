using System;
using System.Collections.Generic;

namespace kerp.Entities;

public partial class Section
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool? Status { get; set; }

    public int? UnderId { get; set; }

    public int? StructureId { get; set; }
}
