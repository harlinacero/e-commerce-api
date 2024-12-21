using e_commerce_domain.DTO;
using e_commerce_domain.entities.User;
using e_commerce_domain.enums;

namespace e_commerce_domain.services.Contracts
{
    /// <summary>
    /// Servicio para la administración de usuarios
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Crea un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        UserBase CreateUser(UserDTO user);
        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(UserDTO user);
        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="id"></param>
        void DeleteUser(UserType userType, Guid id);
        /// <summary>
        /// Obtiene un usuario a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserBase GetUser(UserType usertType, Guid id);
        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns></returns>
        ICollection<UserBase> GetUsers();
    }
}