using System;
using System.Collections.Generic;

namespace BackendReview.DAL.Models;

public partial class Content
{
    public int Id { get; set; }

    public string Body { get; set; } = null!;

    public int Score { get; set; }

    public int GameId { get; set; }

    public int VarietyId { get; set; }

    public string UserName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public  Game? Game { get; set; } = null!;

    public  Variety? Variety { get; set; } = null!;
}
