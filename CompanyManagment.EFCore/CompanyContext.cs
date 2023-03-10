using System.Security.Policy;
using Company.Domain.BillAgg;
using Company.Domain.Board;
using Company.Domain.BoardType;
using Company.Domain.ChapterAgg;
using Company.Domain.Contact2Agg;
using Company.Domain.ContarctingPartyAgg;
using Company.Domain.ContractAgg;
using Company.Domain.EmployeeAgg;
using Company.Domain.EmployeeChildrenAgg;
using Company.Domain.empolyerAgg;
using Company.Domain.Evidence;
using Company.Domain.EvidenceDetail;
using Company.Domain.FileAlert;
using Company.Domain.FileState;
using Company.Domain.FileTiming;
using Company.Domain.FileTitle;
using Company.Domain.HolidayAgg;
using Company.Domain.HolidayItemAgg;
using Company.Domain.JobAgg;
using Company.Domain.LeaveAgg;
using Company.Domain.LeftWorkAgg;
using Company.Domain.MandatoryHoursAgg;
using Company.Domain.MasterPenaltyTitle;
using Company.Domain.MasterPetition;
using Company.Domain.MasterWorkHistory;
using Company.Domain.ModuleAgg;
using Company.Domain.ModuleTextManagerAgg;
using Company.Domain.OriginalTitleAgg;
using Company.Domain.PenaltyTitle;
using Company.Domain.Petition;
using Company.Domain.ProceedingSession;
using Company.Domain.SubtitleAgg;
using Company.Domain.Task;
using Company.Domain.TaskStatus;
using Company.Domain.TaskTitle;
using Company.Domain.TextManagerAgg;
using Company.Domain.WorkHistory;
using Company.Domain.WorkingHoursAgg;
using Company.Domain.WorkingHoursItemsAgg;
using Company.Domain.WorkshopAccountAgg;
using Company.Domain.WorkshopAgg;
using Company.Domain.WorkshopEmployerAgg;
using Company.Domain.YearlySalaryAgg;
using Company.Domain.YearlySalaryItemsAgg;
using Company.Domain.YearlysSalaryTitleAgg;
using CompanyManagment.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using Evidence = Company.Domain.Evidence.Evidence;

namespace CompanyManagment.EFCore
{
    public class CompanyContext : DbContext
    {
        //-----Text-Manager--------------------------------------
        public DbSet<EntitySubtitle> EntitySubtitles { get; set; }
        public DbSet<EntityChapter> EntityChapters { get; set; }
        public DbSet<EntityOriginalTitle> EntityOriginalTitles { get; set; }
        public DbSet<EntityTextManager> EntityTextManagers { get; set; }
        public DbSet<EntityModule> EntityModules { get; set; }
        public DbSet<EntityModuleTextManager> EntityModuleTextManagers { get; set; }
        public DbSet<EntityBill> EntityBills { get; set; }
        public DbSet<EntityContact> EntityContacts { get; set; }
        //---------Files------------------------------
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardType> BoardTypes { get; set; }
        public DbSet<Company.Domain.File1.File1> Files { get; set; }
        public DbSet<PenaltyTitle> PenaltyTitles { get; set; }
        public DbSet<Petition> Petitions { get; set; }
        public DbSet<ProceedingSession> ProceedingSessions { get; set; }
        public DbSet<WorkHistory> WorkHistory { get; set; }
        public DbSet<MasterPetition> MasterPetitions { get; set; }
        public DbSet<MasterPenaltyTitle> MasterPenaltyTitles { get; set; }
        public DbSet<MasterWorkHistory> MasterWorkHistories { get; set; }
        public DbSet<Evidence> Evidences { get; set; }
        public DbSet<EvidenceDetail> EvidenceDetails { get; set; }
        public DbSet<FileTitle> FileTitles { get; set; }
        public DbSet<FileTiming> FileTimings { get; set; }
        public DbSet<FileState> FileStates { get; set; }
        public DbSet<FileAlert> FileAlerts { get; set; }
        //-------Task Manager----------------------------
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<TaskTitle> TaskTitles { get; set; }
        //-------Main-Project----------------------------
        public DbSet<Leave> LeaveList { get; set; }
        public DbSet<LeftWork> LeftWorkList { get; set; }
        public DbSet<WorkshopAccount> WorkshopAccounts { get; set; }
        public DbSet<WorkingHoursItems> WorkingHoursItemsSet { get; set; }
        public DbSet<WorkingHours> WorkingHoursSet { get; set; }
        public DbSet<HolidayItem> HolidayItems { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<MandatoryHours> MandatoryHoursDbSet { get; set; } 
        public DbSet<WorkshopEmployer> WorkshopEmployers { get; set; }
        public DbSet<Job> Jobs { get; set; }    
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<YearlySalaryTitle> YearlySalaryTitles { get; set; }
        public DbSet<YearlySalaryItem> YearlySalaryItems { get; set; }
        public DbSet<YearlySalary> YearlySalaries { get; set; }
        public DbSet<EmployeeChildren> EmployeeChildrenSet { get; set; }    
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<PersonalContractingParty> PersonalContractingParties { get; set; }
      

        public DbSet<Employer> Employers { get; set; }


        public CompanyContext(DbContextOptions<CompanyContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(PersonalContractingpartyMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
         
        }
    }
}
