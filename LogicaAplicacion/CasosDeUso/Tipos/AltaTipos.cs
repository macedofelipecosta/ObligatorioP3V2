using LogicaAplicacion.CasosDeUso.Interfaces;
using LogicaAplicacion.Excepciones.TipoExcepciones;
using LogicaConexion.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoExceptions;


namespace LogicaAplicacion.CasosDeUso.Tipos
{
    public class AltaTipos : IAlta<Tipo>
    {
        private RepositorioTipo _repositorioTipo;

        public AltaTipos(RepositorioTipo repositorioTipo)
        {
            _repositorioTipo = repositorioTipo;
        }

        public void Create(Tipo obj)
        {
            try
            {
                _repositorioTipo.Add(obj);
             
            }
            catch (TipoLAException)
            {

                throw new TipoLAException("No se ha podido crear el tipo de cabaña!");
            }

        }



    }
}
