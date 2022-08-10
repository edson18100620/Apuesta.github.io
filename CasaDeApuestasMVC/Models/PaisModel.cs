namespace CasaDeApuestasMVC.Models
{
    public class PaisModel
    {
        public PaisModel()
        {
            Equipos = new HashSet<EquiposModel>();
            Usuario = new HashSet<UsuarioModel>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? CodPostal { get; set; }

        public virtual ICollection<EquiposModel> Equipos { get; set; }
        public virtual ICollection<UsuarioModel> Usuario { get; set; }
    }
}
