using System;
using System.Collections.Generic;

namespace BackendReview.DAL.Models;

public partial class Platform
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Game>? Games { get; set; } = new List<Game>();
}
