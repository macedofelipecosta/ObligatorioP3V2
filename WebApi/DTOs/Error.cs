namespace WebApi.DTOs
{
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public Error() { }

    }
}
