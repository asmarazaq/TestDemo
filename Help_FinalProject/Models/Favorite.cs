using System;
using System.Collections.Generic;

namespace Help_FinalProject.Models;

public partial class Favorite
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? CompleteAddress { get; set; }

    public virtual User? User { get; set; }
}
