using System.ComponentModel.DataAnnotations;
namespace CompanyManagment.App.Contracts.Module
{
   public class CreateModule
    {
        [Required(ErrorMessage = "نام ماژول نباید خالی باشد")]
        public string NameSubModule { get;  set; }
        public long SubModule_Id { get;  set; }
    }
    
}
