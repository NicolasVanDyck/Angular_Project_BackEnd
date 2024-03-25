using BackendReview.DAL.Models;
namespace BackendReview.DAL.Data;

public class DbInitializer
{
    public static void Initialize(ReviewDbContext context)
    {
        context.Database.EnsureCreated();

        // Check if any data exists, if not, seed the database
        
        if (!context.Platforms.Any())
{
    var platforms = new Platform[]
    {
        new Platform { Name = "PlayStation 5" },
        new Platform { Name = "Xbox Series X" },
        new Platform { Name = "Nintendo Switch" },
        new Platform { Name = "PC" },
        new Platform { Name = "PlayStation 4" },
    };

    foreach (Platform platform in platforms)
    {
        context.Platforms.Add(platform);
    }

    context.SaveChanges();
}

if (!context.Games.Any())
{
    var games = new Game[]
    {
        new Game { Name = "The Last of Us Part II", Publisher = "Naughty Dog", PlatformId = 1},
        new Game { Name = "Halo Infinite", Publisher = "343 Industries", PlatformId = 2},
        new Game { Name = "The Legend of Zelda: Breath of the Wild", Publisher = "Nintendo", PlatformId = 3},
        new Game { Name = "Cyberpunk 2077", Publisher = "CD Projekt", PlatformId = 4},
        new Game { Name = "God of War", Publisher = "Santa Monica Studio", PlatformId = 5},
    };

    foreach (Game game in games)
    {
        context.Games.Add(game);
    }

    context.SaveChanges();
}

if (!context.Varieties.Any())
{
    var varieties = new Variety[]
    {
        new Variety { Name = "Review" },
        new Variety { Name = "Walkthrough" },
        new Variety { Name = "YouTube" },
        new Variety { Name = "Twitch" },
        new Variety { Name = "Podcast" },
    };

    foreach (Variety variety in varieties)
    {
        context.Varieties.Add(variety);
    }

    context.SaveChanges();
}

if (!context.Contents.Any())
{
    var contents = new Content[]
    {
        new Content { Title = "The Last of Us Part II Review", Body = "The Last of Us Part II is a masterpiece that evolves the gameplay, cinematic storytelling, and rich world design of the original in nearly every way.", Score = 5, GameId = 1, VarietyId = 1, UserName = "User 1", IsApproved = true},
        new Content { Title = "Halo Infinite Walkthrough", Body = "This is a detailed walkthrough for Halo Infinite, providing a detailed guide on how to complete the game.", Score = 4, GameId = 2, VarietyId = 2, UserName = "User 2", IsApproved = true},
        new Content { Title = "The Legend of Zelda: Breath of the Wild YouTube Playthrough", Body = "This is a YouTube playthrough of The Legend of Zelda: Breath of the Wild, showcasing the game's open-world gameplay and innovative mechanics.", Score = 5, GameId = 3, VarietyId = 3, UserName = "User 3", IsApproved = true},
        new Content { Title = "Cyberpunk 2077 Twitch Stream", Body = "This is a Twitch stream of Cyberpunk 2077, showcasing the game's immersive world and narrative-driven gameplay.", Score = 4, GameId = 4, VarietyId = 4, UserName = "User 4", IsApproved = true},
        new Content { Title = "God of War Podcast Discussion", Body = "This is a podcast discussion about God of War, discussing the game's narrative, gameplay, and impact on the gaming industry.", Score = 5, GameId = 5, VarietyId = 5, UserName = "User 5", IsApproved = true},
    };

    foreach (Content content in contents)
    {
        context.Contents.Add(content);
    }

    context.SaveChanges();
}
    }
}