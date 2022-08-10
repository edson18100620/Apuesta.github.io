namespace CasaDeApuestasMVC.Models
{
    public class AudioVisualModel
    {
        public AudioVisualModel()
        {
            Promocion = new HashSet<PromocionModel>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<PromocionModel> Promocion { get; set; }
    }
}
