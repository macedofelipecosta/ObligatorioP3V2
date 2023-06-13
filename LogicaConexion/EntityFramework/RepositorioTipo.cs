using LogicaConexion.Excepciones.MantenimientoExceptions;
using LogicaConexion.Excepciones.TipoExcepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfaceRepositorio;
using LogicaNegocio.ValueObject;
using Microsoft.IdentityModel.Tokens;

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
            try
            {
                _hotelContext.Tipos.Add(obj);
                _hotelContext.SaveChanges();
            }
            catch (TipoContextException e) { throw new TipoContextException(e.Message); }
            catch (Exception) { throw new TipoContextException("Ha ocurrido un error inesperado!"); }

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
            catch (TipoContextException e) { throw new TipoContextException(e.Message); }
            catch (Exception) { throw new TipoContextException("Ha ocurrido un error inesperado!"); }

        }

        public Tipo Get(string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre))
                {
                    throw new TipoContextException("No se ha recibido ninugún nombre de tipo de cabaña.");
                }
                var tipo = _hotelContext.Tipos.FirstOrDefault(tipo => tipo.Nombre == nombre);
                if (tipo == null)
                {
                    throw new TipoContextException($"No se ha encontrado el tipo de cabaña de nombre: {nombre}!");
                }
                return tipo;
            }
            catch (TipoContextException e) { throw new TipoContextException(e.Message); }
            catch (Exception) { throw new TipoContextException("Ha ocurrido un error inesperado!"); }

        }

        public IEnumerable<Tipo> GetAll()
        {
            try
            {
                var list = _hotelContext.Tipos.ToList();
                if (list.IsNullOrEmpty()) throw new TipoContextException("No se han encontrado tipos de cabaña para mostrar!");
                return list;
            }
            catch (TipoContextException e) { throw new TipoContextException(e.Message); }
            catch (Exception) { throw new TipoContextException("Ha ocurrido un error inesperado!"); }

        }

        public IEnumerable<Tipo> GetTipoByString(string dato)
        {
            try
            {
                IEnumerable<Tipo> _filtrado =
                                 _hotelContext.Tipos.
                                 Where(tipo => tipo.Nombre.Contains(dato)).
                                 ToList();
                if (_filtrado.IsNullOrEmpty()) throw new TipoContextException($"No se han encotrado tipo de cabañas por el nombre: {dato}");
                return _filtrado;
            }
            catch (TipoContextException e) { throw new TipoContextException(e.Message); }
            catch (Exception) { throw new TipoContextException("Ha ocurrido un error inesperado!"); }

        }

        public int CostoPersona(string nombre)
        {
            try
            {
                var tipo = Get(nombre);
                var costo = tipo.CostoHuesped.Data;
                return costo;
            }
            catch (TipoContextException e) { throw new TipoContextException(e.Message); }
            catch (Exception) { throw new TipoContextException("Ha ocurrido un error inesperado!"); }

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
            catch (TipoContextException e) { throw new TipoContextException(e.Message); }
            catch (Exception) { throw new TipoContextException("Ha ocurrido un error inesperado!"); }
        }

        private void TipoUsado(string nombre)
        {
            try
            {
                var list = _hotelContext.Cabanas.Where(x => x.NombreTipo.Data == nombre).ToList();
                if (list.Count > 0)
                {
                    throw new TipoContextException($"No se puede eliminar el tipo {nombre}, existen cabañas usando este tipo de cabaña!");
                }
            }
            catch (TipoContextException e) { throw new TipoContextException(e.Message); }
            catch (Exception) { throw new TipoContextException("Ha ocurrido un error inesperado!"); }
        }
    }
}
