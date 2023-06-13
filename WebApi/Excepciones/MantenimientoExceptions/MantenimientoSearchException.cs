namespace WebApi.Excepciones.MantenimientoExceptions
{
    public class MantenimientoSearchException : DomainException
    {
        public MantenimientoSearchException()
        {
        }

        public MantenimientoSearchException(string message) : base(message)
        {
        }
    }
}
