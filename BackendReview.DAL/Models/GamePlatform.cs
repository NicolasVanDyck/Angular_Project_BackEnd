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

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();

    public virtual Game Game { get; set; } = null!;

    public virtual Platform Platform { get; set; } = null!;
}
