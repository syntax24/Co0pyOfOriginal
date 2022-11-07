﻿using _0_Framework.InfraStructure;
using System.Collections.Generic;
using System.Linq;
using Company.Domain.ModuleTextManagerAgg;
using Company.Domain.TextManagerAgg;
using CompanyManagment.App.Contracts.TextManager;
using P_TextManager.Domin.TextManagerAgg;

namespace CompanyManagment.EFCore.Repository
{
    public class TextManagerRepository : RepositoryBase<long, EntityTextManager>, ITextManagerRepozitory
    {
        private readonly CompanyContext _context;
        public TextManagerRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }
        public List<TextManagerViewModel> GetAllTextManager()
        {
    
            return _context.EntityTextManagers.Select(x => new TextManagerViewModel
            {
                Id = x.id,
                NoteNumber = x.NoteNumber,
                SubjectTextManager = x.SubjectTextManager,
                NumberTextManager = x.NumberTextManager,
                DateTextManager = x.DateTextManager.ToString(),
                Description = x.Description,
                Paragraph = x.Paragraph,
                Status=x.Status,
                OriginalTitle_Id = x.OriginalTitle_Id,
                Subtitles_Id = x.Subtitles_Id,
                OriginalTitle= _context.EntityOriginalTitles .Where(i=>i.id== x.OriginalTitle_Id).Select(t=>t.Title).FirstOrDefault(),
                Subtitle = _context.EntitySubtitles.Where(i => i.id == x.Subtitles_Id).Select(t => t.Subtitle).FirstOrDefault(),
            }).ToList();
        }
        public EditTextManager GetDetails(long id)
        {
            return _context.EntityTextManagers.Select(x => new EditTextManager
            {
                Id = x.id,
                NoteNumber = x.NoteNumber,
                SubjectTextManager = x.SubjectTextManager,
                NumberTextManager = x.NumberTextManager,
                DateTextManager = x.DateTextManager.ToString(),
                Description = x.Description,
                Paragraph = x.Paragraph,
                Status = x.Status,
                OriginalTitle_Id = x.OriginalTitle_Id,
                Subtitles_Id = x.Subtitles_Id,

            }).FirstOrDefault(x => x.Id == id);
        }

        List<TextManagerViewModel> ITextManagerRepozitory.Search(TextManagerSearchModel searchModel)
        {
          
            var query = _context.EntityTextManagers.Select(x => new TextManagerViewModel
            {
                Id = x.id,
                NoteNumber = x.NoteNumber,
                SubjectTextManager = x.SubjectTextManager,
                NumberTextManager = x.NumberTextManager,
                DateTextManager = x.DateTextManager.ToString(),
                Description = x.Description,
                Paragraph = x.Paragraph,
                Status = x.Status,
                OriginalTitle_Id = x.OriginalTitle_Id,
                Subtitles_Id = x.Subtitles_Id,
                OriginalTitle = _context.EntityOriginalTitles.Where(i => i.id == x.OriginalTitle_Id).Select(t => t.Title).FirstOrDefault(),
                Subtitle = _context.EntitySubtitles.Where(i => i.id == x.Subtitles_Id).Select(t => t.Subtitle).FirstOrDefault(),
                ListUseModule = _context.EntityModuleTextManagers.Where(xi => xi.TextManagerId == x.id) .Select(xi => xi.Module.NameSubModule).ToList(),

            });


            if (searchModel.OriginalTitle_Id!=0)
                query = query.Where(x => x.OriginalTitle_Id==searchModel.OriginalTitle_Id);
            if (searchModel.Subtitles_Id != 0)
                query = query.Where(x => x.Subtitles_Id == searchModel.Subtitles_Id); ;
            if (searchModel.Status != 0)
                query = query.Where(x => x.Status == searchModel.Status); 
            //if (!string.IsNullOrWhiteSpace(searchModel.SubjectTextManager))
            //    query = query.Where(x => x.SubjectTextManager.Contains(searchModel.SubjectTextManager));
            //if (searchModel.NoteNumber != 0)
            //    query = query.Where(x => x.NoteNumber == searchModel.NoteNumber); ;
            return query.OrderByDescending(x => x.Id).ToList();
        }


        public List<long> GetRelation(long textManagerId)
        {
            var moduleId = _context.EntityModuleTextManagers.Where(x => x.TextManagerId == textManagerId)
                .Select(x => x.ModuleId).ToList();
            return moduleId;
        }
        public List<string> GetlisModulet(long textManagerId)
        {
            var moduleId = _context.EntityModuleTextManagers.Where(x => x.TextManagerId == textManagerId)
                .Select(x => x.Module.NameSubModule).ToList();
            return moduleId;
        }
        public List<string> GetlisAllModulet()
        {
            var moduleId = _context.EntityModules.Select(xi => xi.NameSubModule).ToList();
            return moduleId;
        }
        public void RemoveOldRelation(long textManagerId)
        {
            _context.EntityModuleTextManagers.Where(x => x.TextManagerId == textManagerId).ToList()
                .ForEach(x => _context.EntityModuleTextManagers.Remove(x));
        }

        public void ModuleTextManager(long textManagerId, long moduleId)
        {
            _context.EntityModuleTextManagers.Add(new EntityModuleTextManager
            {
                TextManagerId= textManagerId,
                ModuleId= moduleId
            });
            _context.SaveChanges();
        }

        }
    }