namespace Sprencia_Api.Entities.API.Usuarios.Requests.Create
{
    public class RegisterUsersRequest
    {
        public string UserName { get; set; }
        public string Contraseña { get; set; }
        public string RepiteContraseña { get; set; }
    }
}
