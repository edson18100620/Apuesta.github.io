namespace CasaDeApuestasMVC.Models
{
    public class ModalidadPagoModel
    {
        public ModalidadPagoModel()
        {
            Apuesta = new HashSet<ApuestaModel>();
        }

        public int Id { get; set; }
        public string? Detalle { get; set; }

        public virtual ICollection<ApuestaModel> Apuesta { get; set; }
    }
}
