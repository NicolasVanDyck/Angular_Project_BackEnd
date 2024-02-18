using System;
using System.Collections.Generic;

namespace BackendReview.DAL.Models;

public partial class Game
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();
}
