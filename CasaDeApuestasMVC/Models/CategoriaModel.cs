namespace CasaDeApuestasMVC.Models
{
    public class CategoriaModel
    {
        public CategoriaModel()
        {
            Partido = new HashSet<PartidoModel>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<PartidoModel> Partido { get; set; }
    }
}
