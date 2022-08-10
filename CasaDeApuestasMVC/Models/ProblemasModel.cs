namespace CasaDeApuestasMVC.Models
{
    public class ProblemasModel
    {
        public int Id { get; set; }
        public int? CodUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Detalle { get; set; }
        public bool? Estado { get; set; }
        public int? CodAudioVisual { get; set; }

        public virtual AudioVisualModel? CodAudioVisualNavigation { get; set; }
        public virtual UsuarioModel? CodUsuarioNavigation { get; set; }

    }
}
