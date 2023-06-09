using LogicaAplicacion.CasosDeUso.Interfaces;
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
            catch (Exception)
            {

                throw new TipoCreateException("No se ha podido crear el tipo de cabaña!");
            }

        }



    }
}
