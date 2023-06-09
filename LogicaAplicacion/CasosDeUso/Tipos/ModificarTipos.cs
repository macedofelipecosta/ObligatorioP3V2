using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoExcepciones;
using LogicaNegocio.Excepciones.TipoExceptions;

namespace LogicaAplicacion.CasosDeUso.Tipos
{
    public class ModificarTipos
    {
        private RepositorioTipo _repositorioTipo;

        public ModificarTipos(RepositorioTipo repositorioTipo)
        {
            _repositorioTipo = repositorioTipo;
        }

        public void Edit(string nombre, string descripcion, int costoHuesped)
        {
            try
            {
         
                if (string.IsNullOrEmpty(nombre))
                {
                    throw new TipoNameException("No se ha recibido un tipo de cabaña para editar!");
                }
                if (string.IsNullOrEmpty(descripcion))
                {
                    throw new TipoDescriptionException("La descripcion no puede estar vacía!");
                }
                if (costoHuesped < 0)
                {
                    throw new TipoCostException("El costo no puede ser menor a cero!");
                }
                _repositorioTipo.Update(nombre, descripcion, costoHuesped);
            }
            catch (Exception)
            {

                throw new TipoUpdateException ("No se ha podido modificar el tipo de cabaña!");
            }




        }


    }
}
//string nombre, string descripcion, int costoHuesped