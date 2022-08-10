namespace CasaDeApuestasMVC.Models
{
    public class PartidoModel
    {
        public PartidoModel()
        {
            Apuesta = new HashSet<ApuestaModel>();
        }

        public int Id { get; set; }
        public int? EquipoLocId { get; set; }
        public int? EquipoVisId { get; set; }
        public int? CategoriaId { get; set; }
        public double? CuotaLoc { get; set; }
        public double? CuotaVis { get; set; }

        public virtual CategoriaModel? Categoria { get; set; }
        public virtual EquiposModel? EquipoLoc { get; set; }
        public virtual EquiposModel? EquipoVis { get; set; }
        public virtual ICollection<ApuestaModel> Apuesta { get; set; }
    }
}
