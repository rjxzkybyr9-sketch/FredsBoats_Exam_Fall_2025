using Microsoft.EntityFrameworkCore;
using FredsBoats.Web.Data;

namespace FredsBoats.Web.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FredsBoatsContext(
                serviceProvider.GetRequiredService<DbContextOptions<FredsBoatsContext>>()))
            {
                // Look for any boats.
                if (context.Boats.Any())
                {
                    return;   // DB has been seeded
                }

                // 1. Create Categories
                var catSailing = new Category { Name = "Sailing" };
                var catMotor = new Category { Name = "Motor" };
                context.Categories.AddRange(catSailing, catMotor);

                // 2. Create Colours
                var colWhite = new BoatColour { Name = "White" };
                var colBlue = new BoatColour { Name = "Blue" };
                var colRed = new BoatColour { Name = "Red" };
                context.BoatColours.AddRange(colWhite, colBlue, colRed);

                context.SaveChanges(); // Save so we get IDs generated

                // 3. Create Boats
                context.Boats.AddRange(
                    new Boat
                    {
                        Name = "The Sea Breeze",
                        HourRate = 50.00f,
                        DailyRate = 300.00f,
                        CategoryId = catSailing.CategoryId,
                        ColourId = colWhite.ColourId
                    },
                    new Boat
                    {
                        Name = "Ocean Flyer",
                        HourRate = 120.00f,
                        DailyRate = 800.00f,
                        CategoryId = catMotor.CategoryId,
                        ColourId = colBlue.ColourId
                    },
                    new Boat
                    {
                        Name = "Red Rocket",
                        HourRate = 90.00f,
                        DailyRate = 600.00f,
                        CategoryId = catMotor.CategoryId,
                        ColourId = colRed.ColourId
                    }
                );

                context.SaveChanges();
            }
        }
    }
}