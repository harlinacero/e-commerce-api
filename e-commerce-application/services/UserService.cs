using e_commerce_domain.customExceptions;
using e_commerce_domain.DTO;
using e_commerce_domain.entities.User;
using e_commerce_domain.enums;
using e_commerce_domain.services.Contracts;

namespace e_commerce_application.services
{
    public class UserService : IUserService
    {
        public UserBase CreateUser(UserDTO user)
        {
            return user.UserType switch
            {
                UserType.Customer => new Customer(user.UserName, user.Email, user.Password, user.FirstName, user.LastName, user.Address),
                UserType.Admin => new Admin(user.UserName, user.Email, user.Password),
                UserType.Seller => new Seller(user.UserName, user.Email, user.Password, user.Phone),
                _ => throw new CreateUserException("El tipo de usuario no es válido"),
            };
        }

        public void DeleteUser(UserType userType, Guid id)
        {
            // Lógica para eliminar el usuario
        }

        public UserBase GetUser(UserType userType, Guid id)
        {
            // Lógica para obtener el usuario

            // Si el usuario no existe, retorna excepción
            throw new ArgumentNullException("El no pudo ser encontrado");
        }

        public ICollection<UserBase> GetUsers()
        {
            // Lógia para obtener todos los usuarios
            return new List<UserBase>();
        }

        public void UpdateUser(UserDTO user)
        {
            // Lógica para actualizar el usuario
            // Busca el usuario para editarlo
            // Si no existe, lanza excepción
            throw new ArgumentNullException("El usuario no pudo ser encontrado");
        }
    }
}
