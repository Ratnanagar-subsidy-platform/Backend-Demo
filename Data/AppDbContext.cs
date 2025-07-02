using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetWares.Dtos;
using NetWares.Models;
namespace NetWares.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<User>(options)
{
    public DbSet<Subsidy> Subsidies { get; set; }
    public DbSet<SubsidyEntry> SubsidyEntries { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<TrainingParticipant> TrainingParticipants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Subsidy
        modelBuilder.Entity<Subsidy>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Capacity)
                .IsRequired();

            entity.Property(e => e.FundSource)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.IsDuplicateAllow)
                .IsRequired();

            entity.Property(e => e.IsInstallment)
                .IsRequired();

            entity.Property(e => e.Remarks)
                .IsRequired()
                .HasMaxLength(500);
        });

        // SubsidyEntry
        modelBuilder.Entity<SubsidyEntry>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.SubsidyTitle)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.CitizenshipNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(e => e.Email)
                .HasMaxLength(100);

            entity.Property(e => e.TemporaryAddress)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.PermanentAddress)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.Municipality)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Ward)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.Tole)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Occupation)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.DateOfBirth)
                .IsRequired();

            entity.Property(e => e.Age)
                .IsRequired();

            entity.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.SubsidyDemandLetterFilePath)
                .IsRequired()
                .HasMaxLength(300);

            entity.Property(e => e.PaperDocumentFilePath)
                .IsRequired()
                .HasMaxLength(300);

            entity.Property(e => e.NeededAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.GotAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            entity.Property(e => e.FundSettlementStatus)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.BankName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.AccountName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.AccountNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.BankBranch)
                .IsRequired()
                .HasMaxLength(100);
        });

        // Training
        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.TrainingTitle)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.TrainingCategory)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.TrainerName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.TrainingAddress)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.StartDate)
                .IsRequired();

            entity.Property(e => e.EndDate)
                .IsRequired();

            entity.Property(e => e.TrainingCost)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.TrainingCapacity)
                .IsRequired();

            // DurationInDays is calculated property; no DB mapping needed
        });

        // TrainingParticipant
        modelBuilder.Entity<TrainingParticipant>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.TrainingTitle)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.CitizenshipNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(e => e.Email)
                .HasMaxLength(100);

            entity.Property(e => e.TemporaryAddress)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.PermanentAddress)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.Municipality)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Ward)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.Tole)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Occupation)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.DateOfBirth)
                .IsRequired();

            entity.Property(e => e.Age)
                .IsRequired();

            entity.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(10);
        });

        base.OnModelCreating(modelBuilder);
    }
}
