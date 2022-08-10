namespace CasaDeApuestasMVC.Models
{
    public class UsuarioRolModel
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? RolId { get; set; }

        public virtual RolModel? Rol { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
