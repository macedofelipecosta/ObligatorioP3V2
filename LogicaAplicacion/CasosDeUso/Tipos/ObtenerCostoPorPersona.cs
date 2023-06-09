using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoExcepciones;

namespace LogicaAplicacion.CasosDeUso.Tipos
{
    public class ObtenerCostoPorPersona
    {
        private RepositorioTipo _repositorioTipo;
        public ObtenerCostoPorPersona(RepositorioTipo reposiitorioTipo)
        {
            _repositorioTipo = reposiitorioTipo;
        }
        public int GetCostoPersona(Tipo obj)
        {
            try
            {
                return _repositorioTipo.CostoPersona(obj.Nombre);
            }
            catch (Exception)
            {

                throw new TipoCostException ("No se ha podido obtener el costo por persona!");
            }

        }
    }
}
