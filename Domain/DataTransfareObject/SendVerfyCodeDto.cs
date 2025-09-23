

namespace Domain.DataTransfareObject
{
    public class SendVerfyCodeDto
    {
        public string UserName { get; set; }
        public string PhonNumber { get; set; }
        public string ContryCode { get; set; }
    }
    public class CheckVerfyCode
    {
        public string PhonNumber { get; set; }
        public string Code { get; set; }
    }
}
