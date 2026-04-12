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
using kerp.Prosedur.Admin.Permission.MachineIncidentPermission;
using kerp.Prosedur.Admin.Permission.MachineIncidentReportPermission;
using kerp.Prosedur.Admin.Permission.PMOrderPermission;
using kerp.Prosedur.Admin.Permission.ProfilePermission;
using kerp.Prosedur.Admin.PreCheckGroup;
using kerp.Prosedur.Admin.PreCheckResultType;
using kerp.Prosedur.Admin.PreCheckTemplate;
using kerp.Prosedur.Admin.Project;
using kerp.Prosedur.Admin.Section;
using kerp.Prosedur.Admin.UserConMachine;
using kerp.Prosedur.Admin.UserLogins;
using kerp.Prosedur.Admin.UserStructureSee;
using kerp.Prosedur.Admin.UserWorkOrderSee;
using kerp.Prosedur.Admin.WorkOrderType;
using kerp.Prosedur.Canban;
using kerp.Prosedur.Helpers;
using kerp.Prosedur.Hr.Users.Mail;
using kerp.Prosedur.Hr.Users.Phone;
using kerp.Prosedur.Hr.Users.Section;
using kerp.Prosedur.Hr.Users.Structur;
using kerp.Prosedur.Hr.Users.User;
using kerp.Prosedur.MachineIncident.Assistant;
using kerp.Prosedur.MachineIncident.Chat;
using kerp.Prosedur.MachineIncident.Event;
using kerp.Prosedur.MachineIncident.Group;
using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.MachineIncident.MachineIncidentDocument;
using kerp.Prosedur.MachineIncident.MachineIncidentLostTime;
using kerp.Prosedur.MachineIncident.Material;
using kerp.Prosedur.MachineIncident.Record;
using kerp.Prosedur.MachineIncident.Section;
using kerp.Prosedur.MachineIncident.SelectModels;
using kerp.Prosedur.MachineIncident.Structure;
using kerp.Prosedur.MachineIncident.Task;
using kerp.Prosedur.MachineIncident.Type;
using kerp.Prosedur.MachineIncident.WorkOrderType;
using kerp.Prosedur.MachineIncident.WorkShift;
using kerp.Prosedur.MachineIncidentReport;
using kerp.Prosedur.Pm.PMChecklistTemplate;
using kerp.Prosedur.Pm.PmGroup;
using kerp.Prosedur.Pm.PMSchedule;
using kerp.Prosedur.Pm.PMScheduleAssignees;
using kerp.Prosedur.Pm.PMScheduleStructure;
using kerp.Prosedur.Pm.PMScheduleWorkOrderType;
using kerp.Prosedur.PM.PMScheduleAsset;
using kerp.Prosedur.PMOrders;
using kerp.Prosedur.PMOrders.Asset;
using kerp.Prosedur.PMOrders.CheckList;
using kerp.Prosedur.PMOrders.Doc;
using kerp.Prosedur.PMOrders.Event;
using kerp.Prosedur.PMOrders.Material;
using kerp.Prosedur.PMOrders.Order;
using kerp.Prosedur.PMOrders.Record;
using kerp.Prosedur.PMOrders.WorkOrder;
using kerp.Prosedur.SmtpSettings;
using kerp.Prosedur.Structure;
using kerp.Prosedur.Translation;
using kerp.Prosedur.Users;
using kerp.Prosedur.Users.Asset;
using kerp.Prosedur.Users.Employer;
using kerp.Prosedur.Users.Login;
using kerp.Prosedur.Users.Mail;
using kerp.Prosedur.Users.Permission;
using kerp.Prosedur.Users.phone;
using kerp.Prosedur.Users.See;
using kerp.Prosedur.Users.UserPages;
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
    public virtual DbSet<PMOrderAssetSelect> PMOrderAssetSelect { get; set; }
    public virtual DbSet<PMScheduleAssetSelect> PMScheduleAssetSelect { get; set; }
    public virtual DbSet<PreCheckResultTypeSelect> PreCheckResultTypeSelect { get; set; }
    public virtual DbSet<PreCheckTemplateGroupSelect> PreCheckTemplateGroupSelect { get; set; }
    public virtual DbSet<PreCheckTemplateSelect> PreCheckTemplateSelect { get; set; }
    public virtual DbSet<PreCheckGroupSelect> PreCheckGroupSelect { get; set; }
    public virtual DbSet<UserPMOrderPermissionSelect> UserPMOrderPermissionSelect { get; set; }
    public virtual DbSet<PMOrderPermissionSelect> PMOrderPermissionSelect { get; set; }
    public virtual DbSet<PMMaterialSelectMulti> PMOrderMaterialSelectMulti { get; set; }
    public virtual DbSet<PMChecklistExecutionSelect> PMChecklistExecutionSelect { get; set; }
    public virtual DbSet<PMEventSelectMulti> PMEventSelectMulti { get; set; }
    public virtual DbSet<PMEventSelect> PMEventSelect { get; set; }
    public virtual DbSet<PMChatSelect> PMChatSelect { get; set; }
    public virtual DbSet<PMAssigneesSelect> PMAssigneesSelect { get; set; }
    public virtual DbSet<PMDocumentsSelect> PMDocumentsSelect { get; set; }
    public virtual DbSet<PMMaterialSelect> PMMaterialSelect { get; set; }
    public virtual DbSet<PMRecordSelect> PMRecordSelect { get; set; }
    public virtual DbSet<PMOrderWorkOrderTypeSelect> PMOrderWorkOrderTypeSelect { get; set; }
    public virtual DbSet<PMOrdersSelect> PMOrdersSelect { get; set; }
    public virtual DbSet<PMScheduleWorkOrderTypeSelectMulti> PMPMScheduleWorkOrderTypeSelectMulti { get; set; }
    public virtual DbSet<PMScheduleSelect> PMScheduleSelect { get; set; }
    public virtual DbSet<PMScheduleAssigneesSelect> PMScheduleAssigneesSelect { get; set; }
    public virtual DbSet<PMScheduleWorkOrderTypeSelect> PMScheduleWorkOrderTypeSelect { get; set; }
    public virtual DbSet<PMScheduleStructureSelect> PMScheduleStructureSelect { get; set; }
    public virtual DbSet<PMChecklistTemplateSelect> PMChecklistTemplateSelect { get; set; }
    public virtual DbSet<PMChecklistGroupSelect> PMChecklistGroupSelect { get; set; }
    public virtual DbSet<TranslationGetByLang> TranslationGetByLang { get; set; }
    public virtual DbSet<UserFcmToken> UserFcmToken { get; set; }
    public virtual DbSet<MachineIncidentSelectForBackEndWorkOrderType> MachineIncidentSelectForBackEndWorkOrderType { get; set; }
    public virtual DbSet<MachineIncidentSelectForBackEndCrashType> MachineIncidentSelectForBackEndCrashType { get; set; }
    public virtual DbSet<MachineIncidentReportPermissionSelect> MachineIncidentReportPermissionSelect { get; set; }
    public virtual DbSet<GetMachineIncidentReportPermission> GetMachineIncidentReportPermission { get; set; }
    public virtual DbSet<MailMachineIncidentResult> MailMachineIncidentResult { get; set; }
    public virtual DbSet<SmtpSettingsResult> SmtpSettingsResult { get; set; }
    public virtual DbSet<MachineIncidentReportWorkShiftSelect> MachineIncidentReportWorkShiftSelect { get; set; }
    public virtual DbSet<MachineIncidentEventSelectMulti> MachineIncidentEventSelectMulti { get; set; }
    public virtual DbSet<MachineIncidentReportYear> MachineIncidentReportYear { get; set; }
    public virtual DbSet<MachineIncidentReportWorkOrderTypeSelect> MachineIncidentReportWorkOrderTypeSelect { get; set; }
    public virtual DbSet<MachineIncidentReportStructureSelect> MachineIncidentReportStructureSelect { get; set; }
    public virtual DbSet<MachineIncidentReportSectionSelect> MachineIncidentReportSectionSelect { get; set; }
    public virtual DbSet<MachineIncidentReportCrashTypeSelect> MachineIncidentReportCrashTypeSelect { get; set; }
    public virtual DbSet<MachineIncidentReportSelect> MachineIncidentReportSelect { get; set; }
    public virtual DbSet<UserProfilePermissionSelect> UserProfilePermissionSelect { get; set; }
    public virtual DbSet<ProfilePermissionSelect> ProfilePermissionSelect { get; set; }
    public virtual DbSet<MachineIncidentPermissionSelect> MachineIncidentPermissionSelect { get; set; }
    public virtual DbSet<UserMachineIncidentPermissionSelect> UserMachineIncidentPermissionSelect { get; set; }
    public virtual DbSet<MachineIncidentRecordSelect> MachineIncidentRecordSelect { get; set; }
    public virtual DbSet<MachineIncidentMaterialSelectMulti> MachineIncidentMaterialSelectMulti { get; set; }
    public virtual DbSet<MachineIncidentSelect> MachineIncidentSelect { get; set; }
    public virtual DbSet<CanbanCardHub> CanbanCardHub { get; set; }
    public virtual DbSet<CanbanCardStructure> CanbanCardStructure { get; set; }
    public virtual DbSet<CanbanCardSection> CanbanCardSection { get; set; }
    public virtual DbSet<CanbanCard> CanbanCard { get; set; }
    public virtual DbSet<CanbanCardCrashType> CanbanCardCrashType { get; set; }
    public virtual DbSet<CanbanCardWorkOrderType> CanbanCardWorkOrderType { get; set; }
    public virtual DbSet<UserLoginWorkOrderSelect> UserLoginWorkOrderSelect { get; set; }
    public virtual DbSet<UserLoginStructureSelect> UserLoginStructureSelect { get; set; }
    public virtual DbSet<UserWorkOrderSeeSelect> UserWorkOrderSeeSelect { get; set; }
    public virtual DbSet<UserWorkOrderSeeUsersSelect> UserWorkOrderSeeUsersSelect { get; set; }
    public virtual DbSet<UserWorkOrderSeeWorkOrderSelect> UserWorkOrderSeeWorkOrderSelect { get; set; }
    public virtual DbSet<UserStructureSeeStructureSelect> UserStructureSeeStructureSelect { get; set; }
    public virtual DbSet<UserStructureSeeUserSelect> UserStructureSeeUserSelect { get; set; }
    public virtual DbSet<UserStructureSeeSelect> UserStructureSeeSelect { get; set; }
    public virtual DbSet<MachineIncidentWorkShiftSelectMulti> MachineIncidentWorkShiftSelectMulti { get; set; }
    public virtual DbSet<MachineIncidentProjectSelectMulti> MachineIncidentProjectSelectMulti { get; set; }
    public virtual DbSet<MachineIncidentAssetSelectMulti> MachineIncidentAssetSelectMulti { get; set; }
    public virtual DbSet<MachineIncidentWorkOrderTypeSelectMulti> MachineIncidentWorkOrderTypeSelectMulti { get; set; }
    public virtual DbSet<MachineIncidentCrashGroupSelectMulti> MachineIncidentCrashGroupSelectMulti { get; set; }
    public virtual DbSet<MachineIncidentCrashTypeSelectMulti> MachineIncidentCrashTypeSelectMulti { get; set; }
    public virtual DbSet<MachineIncidentLostTimeSelect> MachineIncidentLostTimeSelect { get; set; }
    public virtual DbSet<MachineIncidentWorkOrderTypeSelect> MachineIncidentWorkOrderTypeSelect { get; set; }
    public virtual DbSet<MachineIncidentDocumentSelect> MachineIncidentDocumentSelect { get; set; }
    public virtual DbSet<MachineIncidentChatSelect> MachineIncidentChatSelect { get; set; }
    public virtual DbSet<MachineIncidentAssistantSelect> MachineIncidentAssistantSelect { get; set; }
    public virtual DbSet<MachineIncidentWorkShiftSelect> MachineIncidentWorkShiftSelect { get; set; }
    public virtual DbSet<MachineIncidentTaskSelect> MachineIncidentTaskSelect { get; set; }
    public virtual DbSet<MachineIncidentSectionSelect> MachineIncidentSectionSelect { get; set; }
    public virtual DbSet<MachineIncidentStructureSelect> MachineIncidentStructureSelect { get; set; }
    public virtual DbSet<MachineIncidentMaterialSelect> MachineIncidentMaterialSelect { get; set; }
    public virtual DbSet<MachineIncidentEventSelect> MachineIncidentEventSelect { get; set; }
    public virtual DbSet<MachineIncidentCrashTypeSelect> MachineIncidentCrashTypeSelect { get; set; }
    public virtual DbSet<MachineIncidentCrashGroupSelect> MachineIncidentCrashGroupSelect { get; set; }
    public virtual DbSet<MachineIncidentSelectForBackEnd> MachineIncidentSelectForBackEnd { get; set; }
    public virtual DbSet<UserSelectLoginTypeMulti> UserSelectLoginTypeMulti { get; set; }
    public virtual DbSet<UserSelectLoginSingle> UserSelectLoginSingle { get; set; }
    public virtual DbSet<UserSelectEmployerMulti> UserSelectEmployerMulti { get; set; }
    public virtual DbSet<UserSelectEmployerSingle> UserSelectEmployerSingle { get; set; }
    public virtual DbSet<UserSelectAssets> UserSelectAssets { get; set; }
    public virtual DbSet<UserSelectConMachineSingle> UserSelectConMachineSingle { get; set; }
    public virtual DbSet<UserSelectPhoneCheck> UserSelectPhoneCheck { get; set; }
    public virtual DbSet<UserSelectPhoneSingle> UserSelectPhoneSingle { get; set; }
    public virtual DbSet<UserSelectMailSingle> UserSelectMailSingle { get; set; }
    public virtual DbSet<UserSelectMailCheck> UserSelectMailCheck { get; set; }
    public virtual DbSet<UserSelectShortInfo> UserSelectShortInfo { get; set; }
    public virtual DbSet<AppLog> AppLog { get; set; }
    public virtual DbSet<UserPhoneInfoSelect> UserPhoneInfoSelect { get; set; }
    public virtual DbSet<UserUserLoginsSelect> UserUserLoginsSelect { get; set; }
    public virtual DbSet<UserUserConMachineSelect> UserUserConMachineSelect { get; set; }
    public virtual DbSet<UserManagerEmployeSelect> UserManagerEmployeSelect { get; set; }
    public virtual DbSet<UserMailInfoSelect> UserMailInfoSelect { get; set; }
    public virtual DbSet<UserLoginsSelectLoginType> UserLoginsSelectLoginType { get; set; }
    public virtual DbSet<UserLoginsSelectUser> UserLoginsSelectUser { get; set; }
    public virtual DbSet<UserLoginsSelectAdmin> UserLoginsSelectAdmin { get; set; }
    public virtual DbSet<UserSelectSection> UserSelectSection { get; set; }
    public virtual DbSet<UserSelectStructure> UserSelectStructure { get; set; }
    public virtual DbSet<UserSelectPhone> UserSelectPhone { get; set; }
    public virtual DbSet<UserSelectMail> UserSelectMail { get; set; }
    public virtual DbSet<UserSelectAdmin> UserSelectAdmin { get; set; }
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

        _ = modelBuilder.Entity<AppLog>().HasKey(q => q.LogId);

        _ = modelBuilder.Entity<PMScheduleWorkOrderTypeSelect>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<PMScheduleStructureSelect>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<MachineIncidentSelectForBackEndWorkOrderType>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<MachineIncidentSectionSelect>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<MachineIncidentCrashTypeSelect>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<MachineIncidentStructureSelect>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<MachineIncidentTaskSelect>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<MachineIncidentWorkOrderTypeSelect>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<CanbanCardWorkOrderType>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<CanbanCardCrashType>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<CanbanCardSection>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<CanbanCardStructure>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<MachineIncidentReportWorkOrderTypeSelect>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<MachineIncidentReportStructureSelect>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<MachineIncidentReportSectionSelect>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<MachineIncidentReportCrashTypeSelect>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<MachineIncidentSelectForBackEndCrashType>().HasKey(q => q.LangId);
        _ = modelBuilder.Entity<PMOrderWorkOrderTypeSelect>().HasKey(q => q.LangId);






        _ = modelBuilder.Entity<TranslationGetByLang>().HasKey(q => q.Key);




        _ = modelBuilder.Entity<PMOrderAssetSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMScheduleAssetSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PreCheckResultTypeSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PreCheckGroupSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PreCheckTemplateSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PreCheckTemplateGroupSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserPMOrderPermissionSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMOrderPermissionSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMMaterialSelectMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMChecklistExecutionSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMEventSelectMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMAssigneesSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMDocumentsSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMScheduleWorkOrderTypeSelectMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMScheduleSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMScheduleAssigneesSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMChecklistTemplateSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMChecklistGroupSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserFcmToken>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<GetMachineIncidentReportPermission>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MailMachineIncidentResult>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentReportSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserWorkOrderSeeSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserWorkOrderSeeUsersSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserWorkOrderSeeWorkOrderSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentReportPermissionSelect>().HasKey(q => q.Id);






        _ = modelBuilder.Entity<PMEventSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMChatSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMMaterialSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMRecordSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<PMOrdersSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<SmtpSettingsResult>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentReportWorkShiftSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentEventSelectMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentReportYear>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserProfilePermissionSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<ProfilePermissionSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentPermissionSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserMachineIncidentPermissionSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentRecordSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentRecordSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentRecordSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentMaterialSelectMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<CanbanCardHub>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<CanbanCard>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserLoginWorkOrderSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserLoginStructureSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserStructureSeeStructureSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserStructureSeeUserSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserStructureSeeSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentWorkShiftSelectMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentProjectSelectMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentAssetSelectMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentWorkOrderTypeSelectMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentCrashGroupSelectMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentCrashTypeSelectMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentLostTimeSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentDocumentSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentChatSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentWorkShiftSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentMaterialSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentEventSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentCrashGroupSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<MachineIncidentSelectForBackEnd>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectLoginTypeMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectLoginSingle>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectEmployerMulti>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectEmployerSingle>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectAssets>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectConMachineSingle>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectPhoneCheck>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectPhoneSingle>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectMailCheck>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectMailSingle>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectShortInfo>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserPhoneInfoSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserUserLoginsSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserUserConMachineSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserManagerEmployeSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserMailInfoSelect>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserLoginsSelectLoginType>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserLoginsSelectUser>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserLoginsSelectAdmin>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectSection>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectStructure>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectMail>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectPhone>().HasKey(q => q.Id);
        _ = modelBuilder.Entity<UserSelectAdmin>().HasKey(q => q.Id);
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
