using _0_Framework.InfraStructure;
using System.Collections.Generic;
using System.Linq;
using Company.Domain.BillAgg;
using CompanyManagment.App.Contracts.Bill;


namespace CompanyManagment.EFCore.Repository
{
    public class BillRepository : RepositoryBase<long, EntityBill>, IBillRepozitory
    {
        private readonly CompanyContext _context;
        public BillRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }
        public List<BillViewModel> GetAllBill()
        {
    
            return _context.EntityBills.Select(x => new BillViewModel
            {
                Id = x.id,
                SubjectBill = x.SubjectBill,
                Description = x.Description,
                Appointed=x.Appointed,
                Contact=x.Contact,
                IsActiveString = x.IsActiveString


            }).ToList();
        }
        public EditBill GetDetails(long id)
        {
            return _context.EntityBills.Select(x => new EditBill
            {
                Id = x.id,     
                SubjectBill = x.SubjectBill,
                Description = x.Description,
                Appointed=x.Appointed,
                Contact=x.Contact,
                ProcessingStage=x.ProcessingStage,
            }).FirstOrDefault(x => x.Id == id);
        }

        List<BillViewModel> IBillRepozitory.Search(BillSearchModel searchModel)
        {
          
            var query = _context.EntityBills.Select(x => new BillViewModel
            {
                Id = x.id,
                SubjectBill = x.SubjectBill,
                Description = x.Description,
                Appointed = x.Appointed,
                Contact = x.Contact,
                ProcessingStage = x.ProcessingStage,
                IsActiveString = x.IsActiveString

            });
            if (!string.IsNullOrWhiteSpace(searchModel.Appointed))
            {
                query = query.Where(x => x.Appointed.Contains(searchModel.Appointed)); ;
                if (searchModel.IsActiveString == "false")
                    query = query.Where(x => x.IsActiveString == "false");
                if (searchModel.IsActiveString == "true")
                    query = query.Where(x => x.IsActiveString == "true");
                if (string.IsNullOrWhiteSpace(searchModel.IsActiveString) || searchModel.IsActiveString == null || searchModel.IsActiveString == "null")
                    query = query.Where(x => x.IsActiveString == "true");
            }
            else
            {
                if (searchModel.IsActiveString == "false")
                    query = query.Where(x => x.IsActiveString == "false");
                if (searchModel.IsActiveString == "true")
                    query = query.Where(x => x.IsActiveString == "true");
                if (string.IsNullOrWhiteSpace(searchModel.IsActiveString) || searchModel.IsActiveString == null || searchModel.IsActiveString == "null")
                    query = query.Where(x => x.IsActiveString == "true");
            }



            if (!string.IsNullOrWhiteSpace(searchModel.ProcessingStage))
                query = query.Where(x => x.ProcessingStage.Contains(searchModel.ProcessingStage));
            if (!string.IsNullOrWhiteSpace(searchModel.Contact))
                query = query.Where(x => x.Contact.Contains(searchModel.Contact));
            if (!string.IsNullOrWhiteSpace(searchModel.Description))
                query = query.Where(x => x.Description.Contains(searchModel.Description));


            return query.OrderByDescending(x => x.Id).ToList();
        }

        }
    }
