namespace WebApi.Excepciones.CabanaExceptions
{
    public class CabanaSearchException : DomainException
    {
        public CabanaSearchException()
        {
        }

        public CabanaSearchException(string message) : base(message)
        {
        }
    }
}
