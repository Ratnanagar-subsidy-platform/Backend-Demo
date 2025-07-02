using Microsoft.AspNetCore.Identity;
using NetWares.DTOs;
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
        public static async Task SeedSubsidyEntryAsync(ISubsidyEntryRepository repository)
        {
            var subsidyEntries = new List<SubsidyEntry>
            {
                new SubsidyEntry
                {
                    SubsidyId = 1,
                    SubsidyTitle = "Agriculture Subsidy",
                    FullName = "Ram Bahadur Thapa",
                    CitizenshipNumber = "123456789",
                    PhoneNumber = "9800000001",
                    Email = "ram.thapa@example.com",
                    TemporaryAddress = "Kathmandu, Bagmati",
                    PermanentAddress = "Gorkha, Gandaki",
                    Municipality = "Gorkha Municipality",
                    Ward = "5",
                    Tole = "Simalchaur",
                    Occupation = "Farmer",
                    DateOfBirth = new DateTime(1985, 5, 15, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Male",
                    SubsidyDemandLetterFilePath = "files/demand/ram.pdf",
                    PaperDocumentFilePath = "files/docs/ram.pdf",
                    NeededAmount = 80000,
                    GotAmount = 50000,
                    FundSettlementStatus = "Partial",
                    BankName = "Nepal Bank",
                    AccountName = "Ram Bahadur Thapa",
                    AccountNumber = "00123456789",
                    BankBranch = "Gorkha"
                },
                new SubsidyEntry
                {
                    SubsidyId = 1,
                    SubsidyTitle = "Agriculture Subsidy",
                    FullName = "Sita Kumari Magar",
                    CitizenshipNumber = "987654321",
                    PhoneNumber = "9800000002",
                    Email = "sita.magar@example.com",
                    TemporaryAddress = "Lalitpur, Bagmati",
                    PermanentAddress = "Lamjung, Gandaki",
                    Municipality = "Lamjung Rural Municipality",
                    Ward = "3",
                    Tole = "Dharapani",
                    Occupation = "Farmer",
                    DateOfBirth = new DateTime(1990, 8, 20, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Female",
                    SubsidyDemandLetterFilePath = "files/demand/sita.pdf",
                    PaperDocumentFilePath = "files/docs/sita.pdf",
                    NeededAmount = 100000,
                    GotAmount = 100000,
                    FundSettlementStatus = "Settled",
                    BankName = "NMB Bank",
                    AccountName = "Sita Kumari Magar",
                    AccountNumber = "00987654321",
                    BankBranch = "Lamjung"
                },
                new SubsidyEntry
                {
                    SubsidyId = 2,
                    SubsidyTitle = "Women Empowerment Grant",
                    FullName = "Anjana Shrestha",
                    CitizenshipNumber = "567891234",
                    PhoneNumber = "9800000003",
                    Email = "anjana.shrestha@example.com",
                    TemporaryAddress = "Pokhara, Gandaki",
                    PermanentAddress = "Pokhara, Gandaki",
                    Municipality = "Pokhara Metropolitan",
                    Ward = "12",
                    Tole = "New Road",
                    Occupation = "Entrepreneur",
                    DateOfBirth = new DateTime(1995, 3, 10, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Female",
                    SubsidyDemandLetterFilePath = "files/demand/anjana.pdf",
                    PaperDocumentFilePath = "files/docs/anjana.pdf",
                    NeededAmount = 50000,
                    GotAmount = 50000,
                    FundSettlementStatus = "Settled",
                    BankName = "Global IME Bank",
                    AccountName = "Anjana Shrestha",
                    AccountNumber = "1234509876",
                    BankBranch = "Pokhara"
                },
                new SubsidyEntry
                {
                    SubsidyId = 2,
                    SubsidyTitle = "Women Empowerment Grant",
                    FullName = "Bimala Rana",
                    CitizenshipNumber = "789012345",
                    PhoneNumber = "9800000004",
                    Email = "bimala.rana@example.com",
                    TemporaryAddress = "Chitwan, Bagmati",
                    PermanentAddress = "Chitwan, Bagmati",
                    Municipality = "Bharatpur Metropolitan",
                    Ward = "7",
                    Tole = "Hakim Chowk",
                    Occupation = "Shopkeeper",
                    DateOfBirth = new DateTime(1992, 12, 5, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Female",
                    SubsidyDemandLetterFilePath = "files/demand/bimala.pdf",
                    PaperDocumentFilePath = "files/docs/bimala.pdf",
                    NeededAmount = 40000,
                    GotAmount = 35000,
                    FundSettlementStatus = "Partial",
                    BankName = "Sanima Bank",
                    AccountName = "Bimala Rana",
                    AccountNumber = "0034567890",
                    BankBranch = "Chitwan"
                },
                new SubsidyEntry
                {
                    SubsidyId = 1,
                    SubsidyTitle = "Agriculture Subsidy",
                    FullName = "Dinesh Bhandari",
                    CitizenshipNumber = "654321987",
                    PhoneNumber = "9800000005",
                    Email = "dinesh.bhandari@example.com",
                    TemporaryAddress = "Biratnagar, Province 1",
                    PermanentAddress = "Morang, Province 1",
                    Municipality = "Biratnagar Metropolitan",
                    Ward = "9",
                    Tole = "Main Road",
                    Occupation = "Farmer",
                    DateOfBirth = new DateTime(1988, 4, 25, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Male",
                    SubsidyDemandLetterFilePath = "files/demand/dinesh.pdf",
                    PaperDocumentFilePath = "files/docs/dinesh.pdf",
                    NeededAmount = 90000,
                    GotAmount = 60000,
                    FundSettlementStatus = "Partial",
                    BankName = "NIC Asia Bank",
                    AccountName = "Dinesh Bhandari",
                    AccountNumber = "0076543210",
                    BankBranch = "Biratnagar"
                }
            };
            foreach (var entry in subsidyEntries)
            {
                await repository.AddAsync(entry);
            }
            await repository.SaveChangesAsync();
        }
        public static async Task SeedTrainingParticipate(ITrainingParticipantRepository repository)
        {
            var trainingParticipants = new List<TrainingParticipant>
            {
                new TrainingParticipant
                {
                    TrainingId = 1,
                    TrainingTitle = "Agriculture Basics",
                    FullName = "Ram Bahadur Thapa",
                    CitizenshipNumber = "123456789",
                    PhoneNumber = "9800000001",
                    Email = "ram.thapa@example.com",
                    TemporaryAddress = "Kathmandu, Bagmati",
                    PermanentAddress = "Gorkha, Gandaki",
                    Municipality = "Gorkha Municipality",
                    Ward = "5",
                    Tole = "Simalchaur",
                    Occupation = "Farmer",
                    DateOfBirth = new DateTime(1985, 5, 15, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Male"
                },
                new TrainingParticipant
                {
                    TrainingId = 2,
                    TrainingTitle = "Agro Business Workshop",
                    FullName = "Sita Kumari Magar",
                    CitizenshipNumber = "987654321",
                    PhoneNumber = "9800000002",
                    Email = "sita.magar@example.com",
                    TemporaryAddress = "Lalitpur, Bagmati",
                    PermanentAddress = "Lamjung, Gandaki",
                    Municipality = "Lamjung Rural Municipality",
                    Ward = "3",
                    Tole = "Dharapani",
                    Occupation = "Entrepreneur",
                    DateOfBirth = new DateTime(1990, 8, 20, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Female"
                },
                new TrainingParticipant
                {
                    TrainingId = 3,
                    TrainingTitle = "Animal Husbandry Training",
                    FullName = "Dinesh Bhandari",
                    CitizenshipNumber = "654321987",
                    PhoneNumber = "9800000003",
                    Email = "dinesh.bhandari@example.com",
                    TemporaryAddress = "Biratnagar, Province 1",
                    PermanentAddress = "Morang, Province 1",
                    Municipality = "Biratnagar Metropolitan",
                    Ward = "9",
                    Tole = "Main Road",
                    Occupation = "Farmer",
                    DateOfBirth = new DateTime(1988, 4, 25, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Male"
                },
                new TrainingParticipant
                {
                    TrainingId = 4,
                    TrainingTitle = "Organic Farming Workshop",
                    FullName = "Anjana Shrestha",
                    CitizenshipNumber = "567891234",
                    PhoneNumber = "9800000004",
                    Email = "anjana.shrestha@example.com",
                    TemporaryAddress = "Pokhara, Gandaki",
                    PermanentAddress = "Pokhara, Gandaki",
                    Municipality = "Pokhara Metropolitan",
                    Ward = "12",
                    Tole = "New Road",
                    Occupation = "Farmer",
                    DateOfBirth = new DateTime(1995, 3, 10, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Female"
                },
                new TrainingParticipant
                {
                    TrainingId = 5,
                    TrainingTitle = "Entrepreneurship Development",
                    FullName = "Manisha Gurung",
                    CitizenshipNumber = "543210987",
                    PhoneNumber = "9800000005",
                    Email = "manisha.gurung@example.com",
                    TemporaryAddress = "Butwal, Lumbini",
                    PermanentAddress = "Syangja, Gandaki",
                    Municipality = "Butwal Sub-Metropolitan",
                    Ward = "10",
                    Tole = "Traffic Chowk",
                    Occupation = "Businesswoman",
                    DateOfBirth = new DateTime(1993, 9, 22, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Female"
                },
                new TrainingParticipant
                {
                    TrainingId = 6,
                    TrainingTitle = "Bee Keeping Training",
                    FullName = "Kamal Rai",
                    CitizenshipNumber = "234567890",
                    PhoneNumber = "9800000006",
                    Email = "kamal.rai@example.com",
                    TemporaryAddress = "Hetauda, Bagmati",
                    PermanentAddress = "Makwanpur, Bagmati",
                    Municipality = "Hetauda Sub-Metropolitan",
                    Ward = "4",
                    Tole = "Basundhara",
                    Occupation = "Farmer",
                    DateOfBirth = new DateTime(1983, 11, 9, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Male"
                },
                new TrainingParticipant
                {
                    TrainingId = 7,
                    TrainingTitle = "Horticulture Advanced",
                    FullName = "Sarita Chaudhary",
                    CitizenshipNumber = "876543210",
                    PhoneNumber = "9800000007",
                    Email = "sarita.chaudhary@example.com",
                    TemporaryAddress = "Nepalgunj, Lumbini",
                    PermanentAddress = "Bardiya, Lumbini",
                    Municipality = "Nepalgunj Sub-Metropolitan",
                    Ward = "2",
                    Tole = "Dhamboji",
                    Occupation = "Farmer",
                    DateOfBirth = new DateTime(1991, 7, 30, 0, 0, 0, DateTimeKind.Utc),
                    Gender = "Female"
                }
            };
            foreach (var entry in trainingParticipants)
            {
                await repository.AddAsync(entry);
            }
            await repository.SaveChangesAsync();
        }
    }
}