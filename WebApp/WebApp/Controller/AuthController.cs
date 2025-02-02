using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;
using WebApp.JWT;

namespace WebApp.Controller
{
    [Route("api/v1/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly JwtService _jwtService;


        public AuthController(PasswordHasher<User> passwordHasher, JwtService jwtService)
        {
            this._passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(_jwtService));
        }
        // запрос для входа в систему
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserDto user)
        {
            try
            {
                using (var db = new DbPersonalManagementContext())
                {
                    // поиск пользователя по имени
                    var exitingUser = await db.Users.FirstOrDefaultAsync(c => c.Name == user.name);
                    if (exitingUser == null)
                    {
                        return StatusCode(404, "Данные пользователя не найдены");
                    }
                    // проверка хэша
                    var result = _passwordHasher.VerifyHashedPassword(exitingUser, exitingUser.Password, user.password);

                    if (result == PasswordVerificationResult.Failed)
                    {
                        return StatusCode(404, "Данные пользователя не найдены");
                    }
                    // генерация Jwt токена
                    var token = _jwtService.GenerateToken(user.name);
                    return Ok(new { Token = token });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, "Неверный формат запроса: {0}" + ex.Message);
            }

        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            //проверка на существующего пользователя
            try 
            {
                using (var db = new DbPersonalManagementContext())
                {
                    var exitingUser = await db.Users.FirstOrDefaultAsync(c => c.Name == userDto.name);
                    if (exitingUser != null)
                    {
                        return BadRequest("Пользователь с таким именем уже существует");
                    }

                    // хеширование пароля
                    var user = new User()
                    {
                        Name = userDto.name,
                        Password = _passwordHasher.HashPassword(null, userDto.password)
                    };

                    // добавление пользователя в базу данных 
                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();
                };

                {
                    return Ok("Пользователь успешно зарегистрирован");
                }
            }
            catch (Exception) 
            {
                return StatusCode(400, "Неправильно сформирован запрос");
                    }
        }
    }
    }
    public class UserDto
    {
        public string name { get; set; }
        public string password { get; set; }
    }


