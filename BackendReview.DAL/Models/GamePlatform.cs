using System;
using System.Collections.Generic;

namespace BackendReview.DAL.Models;

public partial class GamePlatform
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int PlatformId { get; set; }

    public DateTime ReleaseDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public  ICollection<Content>? Contents { get; set; } = new List<Content>();

    public  Game? Game { get; set; } = null!;

    public  Platform? Platform { get; set; } = null!;
}
