﻿using Company.Domain.BillAgg;
using Company.Domain.Board;
using Company.Domain.Contact2Agg;
using Company.Domain.File1;
using Company.Domain.ModuleAgg;
using Company.Domain.OriginalTitleAgg;
using Company.Domain.PenaltyTitle;
using Company.Domain.Petition;
using Company.Domain.ProceedingSession;
using Company.Domain.SubtitleAgg;
using Company.Domain.WorkHistory;
using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.Contact2;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.Module;
using CompanyManagment.App.Contracts.OriginalTitle;
using CompanyManagment.App.Contracts.PenaltyTitle;
using CompanyManagment.App.Contracts.Petition;
using CompanyManagment.App.Contracts.ProceedingSession;
using CompanyManagment.App.Contracts.Subtitle;
using CompanyManagment.App.Contracts.TextManager;
using CompanyManagment.App.Contracts.WorkHistory;
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

            services.AddDbContext<CompanyContext>(x => x.UseSqlServer(connectionString));
        }
    }
}