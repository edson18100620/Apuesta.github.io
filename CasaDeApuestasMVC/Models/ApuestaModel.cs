namespace CasaDeApuestasMVC.Models
{
    public class ApuestaModel
    {
        public int Id { get; set; }
        public int? PartidoId { get; set; }
        public int? EquipoId { get; set; }
        public int? UsuarioId { get; set; }
        public int? ModalidadId { get; set; }
        public string? Detalle { get; set; }
        public decimal? Monto { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaApuesta { get; set; }

        public virtual EquiposModel? Equipo { get; set; }
        public virtual ModalidadPagoModel? Modalidad { get; set; }
        public virtual PartidoModel? Partido { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
