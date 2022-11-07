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
                ProcessingStage=x.ProcessingStage,
                Status=x.Status,
    
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
                Status = x.Status,
              

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
                Status = x.Status,
           
            });
            if (searchModel.Status != 0)
                query = query.Where(x => x.Status == searchModel.Status);
           
            // if(!string.IsNullOrWhiteSpace(searchModel.SubjectBill))
            //   query = query.Where(x => x.SubjectBill.Contains(searchModel.SubjectBill));
            //if (!string.IsNullOrWhiteSpace(searchModel.Appointed))
            //    query = query.Where(x => x.SubjectBill.Contains(searchModel.Appointed));
            //if (!string.IsNullOrWhiteSpace(searchModel.ProcessingStage))
            //    query = query.Where(x => x.SubjectBill.Contains(searchModel.ProcessingStage));


            return query.OrderByDescending(x => x.Id).ToList();
        }

        }
    }
