namespace CasaDeApuestasMVC.Models
{
    public class EquiposModel
    {
        public EquiposModel()
        {
            Apuesta = new HashSet<ApuestaModel>();
            PartidoEquipoLoc = new HashSet<PartidoModel>();
            PartidoEquipoVis = new HashSet<PartidoModel>();
        }

        public int Id { get; set; }
        public int? PaisId { get; set; }
        public string? Nombre { get; set; }

        public virtual PaisModel? Pais { get; set; }
        public virtual ICollection<ApuestaModel> Apuesta { get; set; }
        public virtual ICollection<PartidoModel> PartidoEquipoLoc { get; set; }
        public virtual ICollection<PartidoModel> PartidoEquipoVis { get; set; }
    }
}
