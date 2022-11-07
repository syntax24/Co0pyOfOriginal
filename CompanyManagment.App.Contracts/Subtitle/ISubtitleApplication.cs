using _0_Framework.Application;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.Subtitle
{
    public interface ISubtitleApplication
    {
        OperationResult Create(CreateSubtitle command);
        OperationResult Edit(EditSubtitle command);
        EditSubtitle GetDetails( long id);
        List<SubtitleViewModel> Search(SubtitleSearchModel SearchModel);
        List<SubtitleViewModel> GetAllSubtitle();
     
    }
}
