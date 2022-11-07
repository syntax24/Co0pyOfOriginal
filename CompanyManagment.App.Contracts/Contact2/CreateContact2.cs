using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.Contact2
{
   public class CreateContact2
    {
        [Required(ErrorMessage = " مخاطب  نباید خالی باشد")]
        public string NameContact { get;  set; }
        public long Contact_Id { get;  set; }
    }
    
}
