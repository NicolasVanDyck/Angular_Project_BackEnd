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
                new Platform { Name = "Platform 1" },
                new Platform { Name = "Platform 2" },
                // Add more platforms as needed
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
                new Game { Name = "Game 1", Publisher = "Publisher 1", PlatformId = 1},
                new Game { Name = "Game 2", Publisher = "Publisher 2", PlatformId = 2},
                // Add more games as needed
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
                // Add more varieties as needed
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
                new Content { Body = "Review 1", Score = 5, GameId = 1, VarietyId = 1, UserId = 1},
                new Content { Body = "Review 2", Score = 4, GameId = 2, VarietyId = 2, UserId = 2},
                // Add more content as needed
            };

            foreach (Content content in contents)
            {
                context.Contents.Add(content);
            }

            context.SaveChanges();
        }
    }
}