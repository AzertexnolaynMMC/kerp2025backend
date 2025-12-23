using kerp.Entities;
using kerp.Prosedur.Admin.Asset;
using kerp.Prosedur.Admin.AssetTitle;
using kerp.Prosedur.Admin.Dictionary;
using kerp.Prosedur.Admin.Language;
using kerp.Prosedur.Admin.Logs;
using kerp.Prosedur.Admin.ManagerEmploye;
using kerp.Prosedur.Admin.Material;
using kerp.Prosedur.Admin.Pages;
using kerp.Prosedur.Admin.PageUser;
using kerp.Prosedur.Admin.Project;
using kerp.Prosedur.Admin.Section;
using kerp.Prosedur.Admin.UserConMachine;
using kerp.Prosedur.Admin.WorkOrderType;
using kerp.Prosedur.Helpers;
using kerp.Prosedur.Structure;
using kerp.Prosedur.Users.UserPage;
using Microsoft.EntityFrameworkCore;

namespace kerp.Contexts;

public partial class KerpContext : DbContext
{
    public KerpContext()
    {
    }

    public KerpContext(DbContextOptions<KerpContext> options)
        : base(options)
    {
    }
    //basladi
    public virtual DbSet<SqlLogSelect> SqlLogSelect { get; set; }
    public virtual DbSet<AssetTitleSelectAdmin> AssetTitleSelectAdmin { get; set; }
    public virtual DbSet<AssetSelectAdmin> AssetSelectAdmin { get; set; }
    public virtual DbSet<AssetSelectByAssetType> AssetSelectByAssetType { get; set; }
    public virtual DbSet<AssetSelectByStructure> AssetSelectByStructure { get; set; }
    public virtual DbSet<AssetSelectByAssetTitle> AssetSelectByAssetTitle { get; set; }
    public virtual DbSet<UserConMachineSelectMachine> UserConMachineSelectMachine { get; set; }
    public virtual DbSet<UserConMachineSelectUser> UserConMachineSelectUser { get; set; }
    public virtual DbSet<UserConMachineSelectAdmin> UserConMachineSelectAdmin { get; set; }
    public virtual DbSet<ProjectSelectAdmin> ProjectSelectAdmin { get; set; }
    public virtual DbSet<MaterialSelectAdmin> MaterialSelectAdmin { get; set; }
    public virtual DbSet<ManagerEmployeUsers> ManagerEmployeUsers { get; set; }
    public virtual DbSet<ManagerEmployeSelect> ManagerEmployeSelect { get; set; }
    public virtual DbSet<PageUserSelectPage> PageUserSelectPage { get; set; }
    public virtual DbSet<PageUserSelectUser> PageUserSelectUser { get; set; }
    public virtual DbSet<PageUserSelectAdmin> PageUserSelectAdmin { get; set; }
    public virtual DbSet<WorkOrderTypeSelectAdmin> WorkOrderTypeSelectAdmin { get; set; }
    public virtual DbSet<SectionStructureSelect> SectionStructureSelect { get; set; }
    public virtual DbSet<SectionSelectAdmin> SectionSelectAdmin { get; set; }
    public virtual DbSet<StructureSelectAdmin> StructureSelectAdmin { get; set; }
    public virtual DbSet<DictionarySelectLanguage> DictionarySelectLanguage { get; set; }
    public virtual DbSet<DictionarySelect> DictionarySelect { get; set; }
    public virtual DbSet<DictionaryAdminAll> DictionaryAdminAll { get; set; }
    public virtual DbSet<LanguageAdminAll> LanguageAdminAll { get; set; }
    public virtual DbSet<UserRefleshPage> UserRefleshPage { get; set; }
    public virtual DbSet<PageAdminAll> PageAdminAll { get; set; }
    public virtual DbSet<UserPage> UserPage { get; set; }
    public virtual DbSet<LoginTypeLang> LoginTypeLang { get; set; }
    public virtual DbSet<UserLogin> UserLogin { get; set; }

    //Bitti
    public virtual DbSet<LoginType> LoginTypes { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Structure> Structures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserMail> UserMails { get; set; }

    public virtual DbSet<UserPhone> UserPhones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.UseSqlServer("Server=localhost;Database=kerp;User Id=sa;Password=Az@rtexnol@ynSQL;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //basladi
        _ = modelBuilder.Entity<DictionarySelect>().HasKey(q => q.ExternalId);
        _ = modelBuilder.Entity<UserRefleshPage>().HasKey(q => q.UserId);
        _ = modelBuilder.Entity<UserLogin>().HasKey(q => q.UserId);

        _ = modelBuilder.Entity<SqlLogSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<AssetTitleSelectAdmin>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<AssetSelectAdmin>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<AssetSelectByAssetType>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<AssetSelectByStructure>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<AssetSelectByAssetTitle>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserConMachineSelectMachine>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserConMachineSelectUser>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<DictionarySelectLanguage>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserConMachineSelectAdmin>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PageUserSelectPage>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PageUserSelectUser>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<DictionaryAdminAll>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<StructureSelectAdmin>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<LanguageAdminAll>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PageAdminAll>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<SectionStructureSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<SectionSelectAdmin>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PageUserSelectAdmin>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserPage>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<ManagerEmployeSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<ManagerEmployeUsers>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<WorkOrderTypeSelectAdmin>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<LoginTypeLang>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MaterialSelectAdmin>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<ProjectSelectAdmin>().HasKey(q => q.Id);

        //bitti
        _ = modelBuilder.Entity<LoginType>(entity =>
        {
            _ = entity.ToTable("LoginType");

            _ = entity.Property(e => e.Title).HasMaxLength(500);
        });

        _ = modelBuilder.Entity<Section>(entity =>
        {
            _ = entity.ToTable("Section");

            _ = entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("TItle");
        });

        _ = modelBuilder.Entity<Structure>(entity =>
        {
            _ = entity.ToTable("Structure");

            _ = entity.Property(e => e.Title).HasMaxLength(500);
        });

        _ = modelBuilder.Entity<User>(entity =>
        {
            _ = entity.Property(e => e.CanLogin).HasDefaultValue(true);
            _ = entity.Property(e => e.FirstName).HasMaxLength(50);
            _ = entity.Property(e => e.IsActive).HasDefaultValue(true);
            _ = entity.Property(e => e.LastName).HasMaxLength(50);
            _ = entity.Property(e => e.Position).HasMaxLength(100);
        });



        _ = modelBuilder.Entity<UserMail>(entity =>
        {
            _ = entity.ToTable("UserMail");

            _ = entity.Property(e => e.Title).HasMaxLength(500);
        });

        _ = modelBuilder.Entity<UserPhone>(entity =>
        {
            _ = entity.ToTable("UserPhone");

            _ = entity.Property(e => e.Title).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
