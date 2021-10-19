namespace UtopiaCity.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Data { get; set; }

        public string Data { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public bool ShowData => !string.IsNullOrWhiteSpace(Data);
    }
}
