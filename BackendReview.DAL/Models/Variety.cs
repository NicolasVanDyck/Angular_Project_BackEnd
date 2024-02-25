using System;
using System.Collections.Generic;

namespace BackendReview.DAL.Models;

public partial class Variety
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public ICollection<Content>? Contents { get; set; }
}
