using LogicaAplicacion.Excepciones.TipoExcepciones;
using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoExceptions;

namespace LogicaAplicacion.CasosDeUso.Tipos
{
    public class EncontrarTipo
    {
        private RepositorioTipo _repositorioTipo;

        public EncontrarTipo(RepositorioTipo repositorioTipo)
        {
            _repositorioTipo = repositorioTipo;
        }

        public Tipo Encontrar_Tipo(string nombre)
        {
            try
            {
                
                return _repositorioTipo.Get(nombre);
            }
            catch (TipoLAException)
            {

                throw new TipoLAException("No se ha encontrado el tipo de cabaña buscado!");
            }
            
        }

        

        
        

    }
}
