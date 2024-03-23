using System;
using System.Collections.Generic;

namespace BackendReview.DAL.Models;

public partial class Content
{
    public int Id { get; set; }
    
    public string Title { get; set; }

    public string Body { get; set; }

    public int Score { get; set; }

    public int GameId { get; set; }

    public int VarietyId { get; set; }

    public string UserName { get; set; }
    
    public bool IsApproved { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public  Game? Game { get; set; }

    public  Variety? Variety { get; set; }
}
