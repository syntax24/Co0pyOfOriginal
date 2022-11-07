namespace _0_Framework.Application
{
            
    public class OperationResult2
    {
        public long EntityId { get; set; }
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }

        public OperationResult2()
        {
            IsSuccedded = false;
        }
        public OperationResult2 Succcedded(long entityId = -1, string message ="عملیات با موفقیت انجام شد")
        {
            EntityId = entityId;
            IsSuccedded = true;
            Message = message;
            return this;
        }

        public OperationResult2 Failed(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }

       
    }
}


