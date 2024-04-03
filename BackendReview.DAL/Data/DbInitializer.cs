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
        new Content { Title = "The Last of Us Part II Review", Body = "The Last of Us Part II\" is a masterpiece that pushes the boundaries of storytelling and gameplay in the gaming industry. Set in a post-apocalyptic world ravaged by a fungal infection, the game follows the journey of Ellie as she seeks revenge for a devastating loss.\n\nThe game's narrative is a rollercoaster of emotions, exploring themes of love, loss, and the consequences of violence. The character development is exceptional, with each character feeling real and multifaceted. The performances by the voice actors are top-notch, immersing players even deeper into the story.\n\nGameplay mechanics are refined and polished, offering a seamless blend of stealth, action, and exploration. The environments are meticulously crafted, showcasing stunning visuals and attention to detail. From the overgrown ruins of Seattle to the hauntingly beautiful landscapes, every location feels alive and teeming with danger.\n\nOne of the game's standout features is its moral ambiguity, forcing players to confront difficult decisions and their repercussions. It challenges traditional notions of heroism and villainy, making for a thought-provoking experience.\n\nWhile some may find the game's narrative choices controversial, \"The Last of Us Part II\" is undeniably a groundbreaking achievement in gaming. It's a testament to the medium's ability to deliver powerful storytelling and emotional impact.", Score = 6, GameId = 1, VarietyId = 1, UserName = "User 1", IsApproved = true},
        new Content { Title = "Halo Infinite Walkthrough", Body = "This is a detailed walkthrough for Halo Infinite, providing a detailed guide on how to complete the game.", Score = null, GameId = 2, VarietyId = 2, UserName = "User 2", IsApproved = true},
        new Content { Title = "The Legend of Zelda: Breath of the Wild YouTube Playthrough", Body = "This is a YouTube playthrough of The Legend of Zelda: Breath of the Wild, showcasing the game's open-world gameplay and innovative mechanics.", Score = 9, GameId = 3, VarietyId = 1, UserName = "User 3", IsApproved = true},
        new Content { Title = "Cyberpunk 2077 Twitch Stream", Body = "This is a Twitch stream of Cyberpunk 2077, showcasing the game's immersive world and narrative-driven gameplay.", Score = null, GameId = 4, VarietyId = 2, UserName = "User 4", IsApproved = true},
        new Content { Title = "God of War Podcast Discussion", Body = "This is a podcast discussion about God of War, discussing the game's narrative, gameplay, and impact on the gaming industry.", Score = 3, GameId = 5, VarietyId = 1, UserName = "User 5", IsApproved = true},
    };

    foreach (Content content in contents)
    {
        context.Contents.Add(content);
    }

    context.SaveChanges();
}
    }
}