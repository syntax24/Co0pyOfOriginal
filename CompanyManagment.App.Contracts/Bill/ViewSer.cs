
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CompanyManagment.App.Contracts.Bill
{
    public class ViewSearchTextManager
    {
        public List<SelectListItem> SelectListOriginalTitle1;

        public string Description { get; set; }
        public long OriginalTitle_Id { get; set; }
        public long Subtitles_Id { get; set; }
        public List<SelectListItem> SelectListOriginalTitle { get; set; }
        public List<SelectListItem> SelectListSubtitle { get; set; }
    }
}