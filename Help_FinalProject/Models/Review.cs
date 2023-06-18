using System;
using System.Collections.Generic;

namespace Help_FinalProject.Models;

public partial class Review
{
    public int Id { get; set; }

    public string? CompleteAddress { get; set; }

    public string? PropertyAdress { get; set; }

    public string? PropertyCity { get; set; }

    public string? PropertyState { get; set; }

    public int? PropertyZip { get; set; }

    public string? Reporter { get; set; }

    public string? Category { get; set; }

    public string? Title { get; set; }

    public string? Detail { get; set; }
}
