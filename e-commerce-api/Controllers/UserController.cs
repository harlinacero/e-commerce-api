using e_commerce_application.services;
using e_commerce_domain.DTO;
using e_commerce_domain.enums;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    { 
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateUser([FromBody] UserDTO user)
        {
            try
            {
                var newUser = _userService.CreateUser(user);
                return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateUser(Guid id, [FromBody] UserDTO user)
        {
            try
            {
                user.Id = id;
                _userService.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(Guid id, UserType userType)
        {
            try
            {
                _userService.DeleteUser(userType, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un usuario
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet($"{nameof(GetUser)}")]
        public ActionResult GetUser(UserType userType, Guid id)
        {
            try
            {
                var user = _userService.GetUser(userType, id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet($"{nameof(GetUsers)}")]
        public ActionResult GetUsers()
        {
            try
            {
                var users = _userService.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}