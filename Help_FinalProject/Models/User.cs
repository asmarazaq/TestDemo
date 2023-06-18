using System;
using System.Collections.Generic;

namespace Help_FinalProject.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
