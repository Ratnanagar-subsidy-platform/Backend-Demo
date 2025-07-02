using Microsoft.AspNetCore.Identity;
using NetWares.Interfaces.Repository;
using NetWares.Models;

namespace NetWares.Seeders
{
    public static class Seed
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = ["Admin", "User"];

            foreach (var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
            Console.WriteLine("Roles Seeded");
        }
        public static async Task SeedSubsidyAsync(ISubsidyRepository repository)
        {
            var existing = await repository.GetAllAsync();
            if (existing.Any()) return; // Prevent duplicate seeding

            var subsidies = new List<Subsidy>
            {
                new() {
                    Title = "Agriculture Subsidy",
                    Category = "Agriculture",
                    Amount = 100000,
                    Capacity = 50,
                    FundSource = "Government Budget 2025",
                    IsDuplicateAllow = false,
                    IsInstallment = true,
                    Remarks = "For certified farmers only."
                },
                new ()
                {
                    Title = "Women Empowerment Grant",
                    Category = "Social Welfare",
                    Amount = 50000,
                    Capacity = 30,
                    FundSource = "International Aid",
                    IsDuplicateAllow = true,
                    IsInstallment = false,
                    Remarks = "Priority to marginalized groups."
                }
            };

            foreach (var subsidy in subsidies)
            {
                await repository.AddAsync(subsidy);
            }

            await repository.SaveChangesAsync();
        }
        public static async Task SeedTrainingAsync(ITrainingRepository repository)
        {
            var existing = await repository.GetAllAsync();
            if (existing.Any()) return;

            var trainings = new List<Training>
            {
                new Training
                {
                    TrainingTitle = "Agriculture Basics",
                    TrainingCategory = "Farming",
                    TrainerName = "Ram Karki",
                    TrainingAddress = "Pokhara Training Center",
                    StartDate = new DateTime(2025, 7, 5).ToUniversalTime(),
                    EndDate = new DateTime(2025, 7, 10).ToUniversalTime(),
                    TrainingCost = 20000,
                    TrainingCapacity = 50
                },
                new Training
                {
                    TrainingTitle = "Agro Business Workshop",
                    TrainingCategory = "Entrepreneurship",
                    TrainerName = "Bishal Sharma",
                    TrainingAddress = "Kathmandu Business Hub",
                    StartDate = new DateTime(2025, 8, 1).ToUniversalTime(),
                    EndDate = new DateTime(2025, 8, 3).ToUniversalTime(),
                    TrainingCost = 15000,
                    TrainingCapacity = 30
                },
                new Training
                {
                    TrainingTitle = "Animal Husbandry Training",
                    TrainingCategory = "Livestock",
                    TrainerName = "Kusum Lama",
                    TrainingAddress = "Chitwan Agriculture Center",
                    StartDate = new DateTime(2025, 7, 15).ToUniversalTime(),
                    EndDate = new DateTime(2025, 7, 20).ToUniversalTime(),
                    TrainingCost = 25000,
                    TrainingCapacity = 40
                },
                new Training
                {
                    TrainingTitle = "Organic Farming Workshop",
                    TrainingCategory = "Farming",
                    TrainerName = "Deepak Thapa",
                    TrainingAddress = "Ilam Organic Center",
                    StartDate = new DateTime(2025, 9, 5).ToUniversalTime(),
                    EndDate = new DateTime(2025, 9, 9).ToUniversalTime(),
                    TrainingCost = 18000,
                    TrainingCapacity = 25
                },
                new Training
                {
                    TrainingTitle = "Entrepreneurship Development",
                    TrainingCategory = "Business",
                    TrainerName = "Sita Gautam",
                    TrainingAddress = "Nepalgunj Business Park",
                    StartDate = new DateTime(2025, 10, 1).ToUniversalTime(),
                    EndDate = new DateTime(2025, 10, 7).ToUniversalTime(),
                    TrainingCost = 30000,
                    TrainingCapacity = 35
                },
                new Training
                {
                    TrainingTitle = "Bee Keeping Training",
                    TrainingCategory = "Agriculture",
                    TrainerName = "Rajan Bhandari",
                    TrainingAddress = "Lalitpur Bee Research Center",
                    StartDate = new DateTime(2025, 11, 2).ToUniversalTime(),
                    EndDate = new DateTime(2025, 11, 4).ToUniversalTime(),
                    TrainingCost = 12000,
                    TrainingCapacity = 20
                },
                new Training
                {
                    TrainingTitle = "Horticulture Advanced",
                    TrainingCategory = "Farming",
                    TrainerName = "Pramod Singh",
                    TrainingAddress = "Butwal Agriculture Office",
                    StartDate = new DateTime(2025, 7, 20).ToUniversalTime(),
                    EndDate = new DateTime(2025, 7, 25).ToUniversalTime(),
                    TrainingCost = 22000,
                    TrainingCapacity = 30
                },
                new Training
                {
                    TrainingTitle = "Poultry Management",
                    TrainingCategory = "Livestock",
                    TrainerName = "Sunita Rana",
                    TrainingAddress = "Chitwan Poultry Center",
                    StartDate = new DateTime(2025, 8, 10).ToUniversalTime(),
                    EndDate = new DateTime(2025, 8, 15).ToUniversalTime(),
                    TrainingCost = 26000,
                    TrainingCapacity = 40
                },
                new Training
                {
                    TrainingTitle = "Sustainable Farming Techniques",
                    TrainingCategory = "Environment",
                    TrainerName = "Kamal Thapa",
                    TrainingAddress = "Kathmandu Eco Center",
                    StartDate = new DateTime(2025, 9, 1).ToUniversalTime(),
                    EndDate = new DateTime(2025, 9, 5).ToUniversalTime(),
                    TrainingCost = 17000,
                    TrainingCapacity = 25
                },
                new Training
                {
                    TrainingTitle = "Dairy Production Training",
                    TrainingCategory = "Livestock",
                    TrainerName = "Gita Basnet",
                    TrainingAddress = "Hetauda Dairy Development Center",
                    StartDate = new DateTime(2025, 10, 12).ToUniversalTime(),
                    EndDate = new DateTime(2025, 10, 17).ToUniversalTime(),
                    TrainingCost = 28000,
                    TrainingCapacity = 30
                }
            };

            foreach (var training in trainings)
            {
                await repository.AddAsync(training);
            }

            await repository.SaveChangesAsync();

        }
        public static async Task SeedUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Create Roles if not exist
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole("User"));

            // Admin account
            var adminEmail = "admin@netwares.com";
            var admin = await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                admin = new User
                {
                    UserName = "adminuser",
                    FullName = "System Administrator",
                    Email = adminEmail,
                    Contact = "9801000001"
                };

                var result = await userManager.CreateAsync(admin, "Admin@123");

                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Admin");
            }

            // Normal User account
            var userEmail = "user@netwares.com";
            var user = await userManager.FindByEmailAsync(userEmail);

            if (user == null)
            {
                user = new User
                {
                    UserName = "regularuser",
                    FullName = "Regular User",
                    Email = userEmail,
                    Contact = "9801000002"
                };

                var result = await userManager.CreateAsync(user, "User@123");

                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, "User");
            }
        }

    }
}