using System;
using System.Collections.Generic;

namespace BackendReview.DAL.Models;

public partial class Content
{
    public int Id { get; set; }

    public string Body { get; set; } = null!;

    public int Score { get; set; }

    public int GamePlatformId { get; set; }

    public int VarietyId { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual GamePlatform GamePlatform { get; set; } = null!;

    public virtual Variety Variety { get; set; } = null!;
}
