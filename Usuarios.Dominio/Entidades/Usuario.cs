
namespace Usuarios.Dominio.Entidades
{
    public class Usuario : EntidadBaseGuid
    {
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public Guid IdRol { get; set; }
        
    }
}
