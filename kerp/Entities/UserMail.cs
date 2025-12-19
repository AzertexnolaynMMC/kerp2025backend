using System;
using System.Collections.Generic;

namespace kerp.Entities;

public partial class UserMail
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? UserId { get; set; }

    public bool? Status { get; set; }
}
