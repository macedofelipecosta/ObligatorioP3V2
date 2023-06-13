using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfaceRepositorio;
using LogicaNegocio.ValueObject;

namespace LogicaConexion.EntityFramework
{
    public class RepositorioTipo : IRepositorioTipo
    {
        private HotelContext _hotelContext;

        public RepositorioTipo(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public void Add(Tipo obj)
        {

            _hotelContext.Tipos.Add(obj);
            _hotelContext.SaveChanges();
        }

        public void Delete(string nombre)
        {
            try
            {
                var tipo = Get(nombre);
                TipoUsado(nombre);
                _hotelContext.Tipos.Remove(tipo);
                _hotelContext.SaveChanges();
            }
            catch (TipoContextException e)
            {

                throw new TipoContextException(e.Message);
            }

        }

        public Tipo Get(string nombre)
        {

            if (string.IsNullOrEmpty(nombre))
            {
                throw new TipoContextException("No se ha recibido ninugún nombre de tipo de cabaña.");
            }
            var tipo = _hotelContext.Tipos.FirstOrDefault(tipo => tipo.Nombre == nombre);
            if (tipo == null)
            {
                throw new TipoContextException("No se ha encontrado el tipo de cabaña");
            }
            return tipo;
        }

        public IEnumerable<Tipo> GetAll()
        {
            try
            {
                return _hotelContext.Tipos.ToList();
            }
            catch (TipoContextException)
            {
                throw new TipoContextException("No se han encontrado cabañas a mostrar");
            }

        }

        public IEnumerable<Tipo> GetTipoByString(string dato)
        {
            IEnumerable<Tipo> _filtrado =
                 _hotelContext.Tipos.
                 Where(tipo => tipo.Nombre.Contains(dato)).
                 ToList();
            return _filtrado;
        }

        public int CostoPersona(string nombre)
        {
            var tipo = Get(nombre);
            var costo = tipo.CostoHuesped.Data;
            return costo;
        }

        public void Update(string nombre, string descripcion, int costoHuesped)
        {

            try
            {
                var tipo = Get(nombre);
                tipo.Descripcion = new Descripcion(descripcion);
                tipo.CostoHuesped = new Costo(costoHuesped);
                _hotelContext.Tipos.Update(tipo);
                _hotelContext.SaveChanges();
            }
            catch (TipoContextException)
            {
                throw new TipoContextException($"Ha ocurrido un error al modificar el tipo ({nombre}) de cabaña!");
            }
        }

        private void TipoUsado(string nombre)
        {
            try
            {
                var list = _hotelContext.Cabanas.Where(x => x.NombreTipo.Data == nombre).ToList();
                if (list.Count > 0)
                {
                    throw new TipoContextException($"No se puede eliminar el tipo {nombre}, existen cabañas con este tipo!");
                }
            }
            catch (TipoContextException e)
            {
                throw new TipoContextException(e.Message);
            }
        }
    }
}
