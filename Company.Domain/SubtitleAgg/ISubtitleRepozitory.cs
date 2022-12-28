using _0_Framework.Domain;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.Subtitle;


namespace Company.Domain.SubtitleAgg
{
 public interface ISubtitleRepozitory : IRepository<long,EntitySubtitle>
    {
        EditSubtitle GetDetails( long id);
        //DeleteSubtitle GetDelete(long id);
        List<SubtitleViewModel> Search(SubtitleSearchModel SearchModel);
        List<SubtitleViewModel> GetAllSubtitle();
      }
}
