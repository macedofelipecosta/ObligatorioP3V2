using LogicaConexion.EntityFramework;


namespace LogicaAplicacion.CasosDeUso.Cabanas
{
    public class Ultimo_Id
    {
        private RepositorioCabana _repoCabana;
        public Ultimo_Id(RepositorioCabana repoCabana)
        {
            _repoCabana = repoCabana;
        }

        public int GetLastId()
        {
            return _repoCabana.UltimoId();
        }
    }
}
