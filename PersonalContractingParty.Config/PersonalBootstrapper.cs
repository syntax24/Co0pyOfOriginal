using System;
using Company.Domain.BillAgg;
using Company.Domain.Board;
using Company.Domain.ChapterAgg;
using Company.Domain.Contact2Agg;
using Company.Domain.ContarctingPartyAgg;
using Company.Domain.ContractAgg;
using Company.Domain.EmployeeAgg;
using Company.Domain.EmployeeChildrenAgg;
using Company.Domain.empolyerAgg;
using Company.Domain.Evidence;
using Company.Domain.EvidenceDetail;
using Company.Domain.File1;
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
using Company.Domain.OriginalTitleAgg;
using Company.Domain.PenaltyTitle;
using Company.Domain.Petition;
using Company.Domain.ProceedingSession;
using Company.Domain.SubtitleAgg;
using Company.Domain.WorkHistory;
using Company.Domain.WorkingHoursAgg;
using Company.Domain.WorkingHoursItemsAgg;
using Company.Domain.WorkshopAgg;
using Company.Domain.YearlySalaryAgg;
using Company.Domain.YearlySalaryItemsAgg;
using Company.Domain.YearlysSalaryTitleAgg;
using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.Chapter;
using CompanyManagment.App.Contracts.Contact2;
using CompanyManagment.App.Contracts.Contract;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.EmployeeChildren;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.Evidence;
using CompanyManagment.App.Contracts.EvidenceDetail;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.FileAlert;
using CompanyManagment.App.Contracts.FileState;
using CompanyManagment.App.Contracts.FileTiming;
using CompanyManagment.App.Contracts.FileTitle;
using CompanyManagment.App.Contracts.Holiday;
using CompanyManagment.App.Contracts.HolidayItem;
using CompanyManagment.App.Contracts.Job;
using CompanyManagment.App.Contracts.Leave;
using CompanyManagment.App.Contracts.LeftWork;
using CompanyManagment.App.Contracts.MandantoryHours;
using CompanyManagment.App.Contracts.MasterPenaltyTitle;
using CompanyManagment.App.Contracts.MasterPetition;
using CompanyManagment.App.Contracts.MasterWorkHistory;
using CompanyManagment.App.Contracts.Module;
using CompanyManagment.App.Contracts.OriginalTitle;
using CompanyManagment.App.Contracts.PenaltyTitle;
using CompanyManagment.App.Contracts.PersonalContractingParty;
using CompanyManagment.App.Contracts.Petition;
using CompanyManagment.App.Contracts.ProceedingSession;
using CompanyManagment.App.Contracts.Subtitle;
using CompanyManagment.App.Contracts.TextManager;
using CompanyManagment.App.Contracts.WorkHistory;
using CompanyManagment.App.Contracts.WorkingHours;
using CompanyManagment.App.Contracts.WorkingHoursItems;
using CompanyManagment.App.Contracts.Workshop;
using CompanyManagment.App.Contracts.YearlySalary;
using CompanyManagment.App.Contracts.YearlySalaryItems;
using CompanyManagment.App.Contracts.YearlySalaryTitles;
using CompanyManagment.Application;
using CompanyManagment.EFCore;
using CompanyManagment.EFCore.Repository;
using File.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using P_TextManager.Domin.TextManagerAgg;

namespace PersonalContractingParty.Config
{
    public class PersonalBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IPersonalContractingPartyApp, PersonalContractingPartyApplication>();
            services.AddTransient<IPersonalContractingPartyRepository, PersonalContractingPartyRepository>();
           

            services.AddTransient<IEmployerApplication, EmployerApplication>();
            services.AddTransient<IEmployerRepository, EmployerRepository>();

            services.AddTransient<IWorkshopApplication, WorkshopAppliction>();
            services.AddTransient<IWorkshopRepository, WorkshopRepository>();

            services.AddTransient<IEmployeeApplication, EmployeeAplication>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IEmployeeChildrenApplication, EmployeeChildrenApplication>();
            services.AddTransient<IEmployeeChildrenRepository, EmployeeChildrenRepository>();

            services.AddTransient<IYearlySalaryApplication, YearlySalaryApplication>();
            services.AddTransient<IYearlySalaryRepository, YearlySalaryRepository>();

            services.AddTransient<IYearlySalaryItemApplication, YearlySalaryItemApplication>();
            services.AddTransient<IYearlySalaryItemRepository, YearlySalaryItemRepository>();

            services.AddTransient<IYearlySalaryTitleApplication, YearlySalaryTitleApplication>();
            services.AddTransient<IYearlySalaryTitleRepository, YearlySalaryTitleRepository>();

            services.AddTransient<IContractApplication, ContractApplication>();
            services.AddTransient<IContractRepository, ContractRepository>();

            services.AddTransient<IJobApplication, JobApplication>();
            services.AddTransient<IJobRepository, JobRepository>();

            services.AddTransient<IMandatoryHoursApplication, MandatoryHoursApplication>();
            services.AddTransient<IMandatoryHoursRepository, MandatoryHoursRepository>();

            services.AddTransient<IHolidayApplication, HolidayApplication>();
            services.AddTransient<IHolidayRepository, HolidayRepository>();

            services.AddTransient<IHolidayItemApplication, HolidayItemApplication>();
            services.AddTransient<IHolidayItemRepository, HolidayItemRepository>();

            services.AddTransient<IWorkingHoursApplication, WorkingHoursApplication>();
            services.AddTransient<IWorkingHoursRepository, WorkingHoursRepository>();

            services.AddTransient<IWorkingHoursItemsApplication, WorkingHoursItemsApplication>();
            services.AddTransient<IWorkingHoursItemsRepository, WorkingHoursItemsRepository>();

            services.AddTransient<ILeftWorkApplication, LeftWorkApplication>();
            services.AddTransient<ILeftWorkRepository, LeftWorkRepository>();

            services.AddTransient<ILeaveApplication, LeaveApplication>();
            services.AddTransient<ILeaveRepository, LeaveRepository>();

            //---File Project------------------------------------

            services.AddTransient<IBoardApplication, BoardApplication>();
            services.AddTransient<IBoardRepository, BoardRepository>();

            services.AddTransient<IFileApplication, FileApplication>();
            services.AddTransient<IFileRepository, FileRepository>();

            services.AddTransient<IPetitionApplication, PetitionApplication>();
            services.AddTransient<IPetitionRepository, PetitionRepository>();

            services.AddTransient<IWorkHistoryApplication, WorkHistoryApplication>();
            services.AddTransient<IWorkHistoryRepository, WorkHistoryRepository>();

            services.AddTransient<IPenaltyTitleApplication, PenaltyTitleApplication>();
            services.AddTransient<IPenaltyTitleRepository, PenaltyTitleRepository>();

            services.AddTransient<IProceedingSessionApplication, ProceedingSessionApplication>();
            services.AddTransient<IProceedingSessionRepository, ProceedingSessionRepository>();

            services.AddTransient<IMasterPetitionApplication, MasterPetitionApplication>();
            services.AddTransient<IMasterPetitionRepository, MasterPetitionRepository>();

            services.AddTransient<IMasterWorkHistoryApplication, MasterWorkHistoryApplication>();
            services.AddTransient<IMasterWorkHistoryRepository, MasterWorkHistoryRepository>();

            services.AddTransient<IMasterPenaltyTitleApplication, MasterPenaltyTitleApplication>();
            services.AddTransient<IMasterPenaltyTitleRepository, MasterPenaltyTitleRepository>();

            services.AddTransient<IEvidenceApplication, EvidenceApplication>();
            services.AddTransient<IEvidenceRepository, EvidenceRepository>();

            services.AddTransient<IEvidenceDetailApplication, EvidenceDetailApplication>();
            services.AddTransient<IEvidenceDetailRepository, EvidenceDetailRepository>();

            services.AddTransient<IFileTitleApplication, FileTitleApplication>();
            services.AddTransient<IFileTitleRepository, FileTitleRepository>();

            services.AddTransient<IFileTimingApplication, FileTimingApplication>();
            services.AddTransient<IFileTimingRepository, FileTimingRepository>();

            services.AddTransient<IFileStateApplication, FileStateApplication>();
            services.AddTransient<IFileStateRepository, FileStateRepository>();

            services.AddTransient<IFileAlertApplication, FileAlertApplication>();
            services.AddTransient<IFileAlertRepository, FileAlertRepository>();

            //----Text-Manager-Project---------------------------------
            services.AddTransient<ISubtitleApplication, SubtitleAppliction>();
            services.AddTransient<ISubtitleRepozitory, SubtitleRepository>();

            services.AddTransient<IOriginalTitleApplication, OriginalTitleAppliction>();
            services.AddTransient<IOriginalTitleRepozitory, OriginalTitleRepository>();

            services.AddTransient<ITextManagerApplication, TextManagerAppliction>();
            services.AddTransient<ITextManagerRepozitory, TextManagerRepository>();

            services.AddTransient<IModuleApplication, ModuleAppliction>();
            services.AddTransient<IModuleRepozitory, ModuleRepository>();

            services.AddTransient<IBillApplication, BillAppliction>();
            services.AddTransient<IBillRepozitory, BillRepository>();
            services.AddTransient<IContactApplication2, Contact2Appliction>();
            services.AddTransient<IContactRepozitory2, ContactRepository2>();
            services.AddTransient<IChapterApplication, ChapterAppliction>();
            services.AddTransient<IChapterRepozitory, ChapterRepository>();

            services.AddDbContext<CompanyContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
