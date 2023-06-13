namespace WebApi.Excepciones.TipoExceptions
{
    public class TipoSearchException : DomainException
    {
        public TipoSearchException()
        {
        }

        public TipoSearchException(string message) : base(message)
        {
        }
    }
}
