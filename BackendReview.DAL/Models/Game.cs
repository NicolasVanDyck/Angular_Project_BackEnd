using System;
using System.Collections.Generic;

namespace BackendReview.DAL.Models;

public partial class Game
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public int PlatformId { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<Content>? Contents { get; set; }

    public  Platform? Platform { get; set; }
}
