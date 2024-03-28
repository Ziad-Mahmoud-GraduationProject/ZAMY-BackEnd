using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using ZAMY.Api.Dtos;
using ZAMY.Domain.Consts;
using ZAMY.Infrastructure.Persistence;

namespace ZAMY.Api.Contaollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenServices _token;
        public UsersController(UserManager<IdentityUser> UserManager, ApplicationDbContext db, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ITokenServices token)
        {
            _db = db; 
            _userManager = UserManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _token = token;
        }
       
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromQuery] PaginationParameters paginationParameters)
        {
            var users = await _userManager.Users.Where(c => c.Id != AppSettings.IdServer).Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize).ToListAsync();
            if (users.Count() == 0)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage = new List<string> { "Users not found." },
                });
            }

            var model = new List<UserDto>();
            foreach (var user in users)
            {
                var roles = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                model.Add(new UserDto
                {
                    Email = user.Email,
                    Id = user.Id,
                    Phone = user.PhoneNumber,
                    Username = user.UserName,
                    Role = roles
                });
            }

            return Ok(new ApiResponse
            {
                Result = model.OrderBy(x => x.Role),
                ErrorMessage = new List<string> { "user  found." },
            });
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage = new List<string> { $"User with Id = {id} Not Found in System" },
                });
            }

            return Ok(new ApiResponse
            {
                Result = new UserDto()
                {
                    Email = user.Email,
                    Id = user.Id,
                    Phone = user.PhoneNumber,
                    Username = user.UserName,
                    Role = (_userManager.GetRolesAsync(user).Result).FirstOrDefault()!,
                },
                ErrorMessage = new List<string> { "user  found." },
            });
        }

        [HttpGet("GetUserByUsername")]
        public async Task<IActionResult> GetUserByUsername(string Username)
        {
            var user = await _userManager.FindByNameAsync(Username);
            if (user == null)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage = new List<string> { $"User with Username = {Username} Not Found in System" },
                });
            }

            return Ok(new ApiResponse
            {
                Result = new UserDto()
                {
                    Email = user.Email,
                    Id = user.Id,
                    Phone = user.PhoneNumber,
                    Username = user.UserName,

                    Role = (_userManager.GetRolesAsync(user).Result).FirstOrDefault()!,
                },
                ErrorMessage = new List<string> { "user  found." },
            });
        }
        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage = new List<string> { $"User with Email = {Email} Not Found in System" },
                });
            }

            return Ok(new ApiResponse
            {
                Result = new UserDto()
                {
                    Email = user.Email,
                    Id = user.Id,
                    Phone = user.PhoneNumber,
                    Username = user.UserName,
                    Role = (_userManager.GetRolesAsync(user).Result).FirstOrDefault()!,
                },
                ErrorMessage = new List<string> { "user  found." },
            });
        }
        [HttpGet("GetUsersByRoleName/{roleName}")]
        public async Task<IActionResult> GetUsersByRoleName(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage = new List<string> { "Role not found." },
                });
            }

            var usersInRole = (await _userManager.GetUsersInRoleAsync(role.Name))
                .Where(x => x.Id != AppSettings.IdServer).Select(user => new UserDto()
                {
                    Email = user.Email,
                    Id = user.Id,
                    Phone = user.PhoneNumber,
                    Username = user.UserName,
                    Role = (_userManager.GetRolesAsync(user).Result).FirstOrDefault()!,
                });

            return Ok(new ApiResponse
            {
                Result = usersInRole,
                ErrorMessage = new List<string> { "Role  found." },
            });
        }

        [HttpGet("GetUsersByRoleId/{roleId}")]
        public async Task<IActionResult> GetUsersByRoleId(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage = new List<string> { "Role not found." },
                });
            }

            var usersInRole = (await _userManager.GetUsersInRoleAsync(role.Name))
           .Where(x => x.Id != AppSettings.IdServer).Select(user => new UserDto()
           {
               Email = user.Email,
               Id = user.Id,
               Phone = user.PhoneNumber,
               Username = user.UserName,
               Role = (_userManager.GetRolesAsync(user).Result).FirstOrDefault()!,
           });

            return Ok(new ApiResponse
            {
                Result = usersInRole,
                ErrorMessage = new List<string> { "Role  found." },
            });
        }
  

        [HttpGet("CheackUserIsActiveById")]
        public async Task<IActionResult> CheackUserIsActiveById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage = new List<string> { $"User with Id = {id} Not Found in System" },
                });
            }
            if (user.EmailConfirmed)
            {
                return Ok(new ApiResponse
                {
                    Result = $"User with Id = {id} Is  Active",
                    ErrorMessage = new List<string> { "user  found." },
                });
            }
            return Ok(new ApiResponse
            {
                Result = $"User with Id = {id} Is not Active",
                ErrorMessage = new List<string> { "user  found." },
            });

        } 




        [AllowAnonymous, HttpPost("LoginAsync")]
        public async Task<IActionResult> LoginAsync(LoginDto login)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
 
                if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
                    return BadRequest(new ApiResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, ErrorMessage = new List<string> { "Invalid password or email" } });

                if (!user.EmailConfirmed)
                {
                    return BadRequest(new ApiResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, ErrorMessage = new List<string> { "email is not active" } });
                } 



                // create token for the user
                var Roles = await _userManager.GetRolesAsync(user);
                var jwtSecurityToken = await _token.GetTokenAsync(await _userManager.GetClaimsAsync(user), Roles, user);
            

                return Ok(new ApiResponse
                {

                    ErrorMessage = new List<string>() { "Login Sucsessfully !" },
                    Result = new AuthReturnDto()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Username = user.UserName,
                        ExpiresOn = jwtSecurityToken.ValidTo,
                        IsAuthenticated = true,
                        Roles = Roles.ToList(),
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    },
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string>() { ex.Message },
                });
            }
        }

        [HttpPost("RegiserAsync")]
        public async Task<IActionResult> RegiserAsync(RegisterDto model)
        {
            try
            {
                if (await _userManager.FindByEmailAsync(model.Email) is not null)
                    return BadRequest(new ApiResponse { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, ErrorMessage = new List<string>() { "Email is already registered!" } });
              
                IdentityUser user = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                };
                 
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    var errors = new List<string>();

                    foreach (var error in result.Errors)
                        errors.Add(error.Description);
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = errors,
                    });
                }



                var role = await _roleManager.FindByNameAsync(model.Role);
                if (role == null)
                {
                    return NotFound(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorMessage = new List<string> { "Role not found." },
                    });
                }


                await _userManager.AddToRoleAsync(user, model.Role);

                // create token for the user
                var Roles = await _userManager.GetRolesAsync(user);
                var jwtSecurityToken = await _token.GetTokenAsync(await _userManager.GetClaimsAsync(user), Roles, user);

                return Ok(new ApiResponse
                {
                    ErrorMessage = new List<string>() { "User Added Sucsessfully !" },
                    Result = new AuthReturnDto()
                    {
                        Id = user.Id,
                        Email = model.Email,
                        ExpiresOn = jwtSecurityToken.ValidTo,
                        IsAuthenticated = true,
                        Roles = Roles.ToList(),
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                        Username = user.UserName
                    },
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string>() { ex.Message },
                });
            }

        }

        [HttpPost("ActiveByIdAsync/{id}")]
        public async Task<IActionResult> ActiveByIdAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorMessage = new List<string> { $"User with Id = {id} Not Found in System" },
                    });
                }
                if (user.EmailConfirmed)
                {
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = new List<string> { $"User with Id = {id} Is Already Active" },
                    });
                }
                user.EmailConfirmed = true;

                var result = await _userManager.UpdateAsync(user);



                if (!result.Succeeded)
                {
                    var errors = new List<string>();

                    foreach (var error in result.Errors)
                        errors.Add(error.Description);
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = errors,
                    });
                }


                return Ok(new ApiResponse
                {
                    ErrorMessage = new List<string>() { "User Active Sucsessfully !" },
                    Result = new { },
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string>() { ex.Message },
                });
            }

        }

        [HttpPost("ActiveByEmailAsync/{email}")]
        public async Task<IActionResult> ActiveByEmailAsync(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return NotFound(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorMessage = new List<string> { $"User with Email = {email} Not Found in System" },
                    });
                }
                if (user.EmailConfirmed)
                {
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = new List<string> { $"User with Email = {email} Is Already Active" },
                    });
                }

                user.EmailConfirmed = true;

                var result = await _userManager.UpdateAsync(user);



                if (!result.Succeeded)
                {
                    var errors = new List<string>();

                    foreach (var error in result.Errors)
                        errors.Add(error.Description);
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = errors,
                    });
                }


                return Ok(new ApiResponse
                {
                    ErrorMessage = new List<string>() { "User Active Sucsessfully !" },
                    Result = new { },
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string>() { ex.Message },
                });
            }

        }

        [HttpPost("ActiveByUserNameAsync/{username}")]
        public async Task<IActionResult> ActiveByUserNameAsync(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user == null)
                {
                    return NotFound(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorMessage = new List<string> { $"User with Username = {username} Not Found in System" },
                    });
                }
                if (user.EmailConfirmed)
                {
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = new List<string> { $"User with Username = {username} Is Already Active" },
                    });
                }


                user.EmailConfirmed = true;

                var result = await _userManager.UpdateAsync(user);



                if (!result.Succeeded)
                {
                    var errors = new List<string>();

                    foreach (var error in result.Errors)
                        errors.Add(error.Description);
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = errors,
                    });
                }


                return Ok(new ApiResponse
                {
                    ErrorMessage = new List<string>() { "User Active Sucsessfully !" },
                    Result = new { },
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string>() { ex.Message },
                });
            }

        }
 
        [HttpPost("ChangeRole")]
        public async Task<ActionResult> ChangeUserRole([FromBody] ChangeUserRoleDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string> { $"{ModelState}", "Model is not valid" },
                });

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage = new List<string>()
                          {
                              "User not found in system",
                          }
                });
            }

            var roles = await _userManager.GetRolesAsync(user);
            var currentRole = roles.FirstOrDefault();

            if (currentRole == null || currentRole == model.NewRole)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string> { "Invalid role." },
                });
            }

            var resultRemove = await _userManager.RemoveFromRoleAsync(user, currentRole);
            var resultAdd = await _userManager.AddToRoleAsync(user, model.NewRole);

            if (resultRemove.Succeeded && resultAdd.Succeeded)
            {
                return Ok(new ApiResponse
                {
                    Result = model,
                    ErrorMessage = new List<string>() { $"User's role has been changed to {model.NewRole}." }
                });
            }
            else
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string> { "Failed to change user's role." },
                });
            }
        }


        [HttpPost("AddRoleToUserById/{UserId}")]
        public async Task<ActionResult> AddUserRole(string UserId, string roleName)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string> { $"{ModelState}", "Model is not valid" },
                });

            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage = new List<string>()
                          {
                              "User not found in system",
                          }
                });
            }
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return NotFound(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage = new List<string> { "Role not found." },
                });
            }

            await _userManager.AddToRoleAsync(user, roleName);

            return Ok(new ApiResponse() { Result="Add Role"});
        }





        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = new List<string> { $"{ModelState}", "Model is not valid" },
                    });


                var user = await _userManager.FindByEmailAsync(model.Email);



                if (user == null)
                    return NotFound(new ApiResponse() { IsSuccess = false, StatusCode = HttpStatusCode.NotFound, ErrorMessage = new List<string>() { "Admin not found" } });


                var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (!changePasswordResult.Succeeded)
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = new List<string>() { $"{ModelState}", "Error in Result !" },
                        Result = changePasswordResult.Errors.ToList()
                    });

                await _signInManager.RefreshSignInAsync(user);
                return Ok(new ApiResponse
                {
                    Result = "Your password has been changed successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string>() { ex.Message },
                });
            }
        }

       
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(string id, RegisterDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = new List<string> { "Model is not valid" },
                    });

                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorMessage = new List<string>()
                          {
                              "User not found in system",
                          }
                    });
                }
                var ussername = await _userManager.FindByEmailAsync(model.Email);
                if (ussername is not null && ussername.Id != user.Id)
                    return BadRequest(new ApiResponse { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, ErrorMessage = new List<string>() { "Email is already taken!" } });
                var UserEmail = await _userManager.FindByNameAsync(model.Username);
                if (UserEmail is not null && UserEmail.Id != user.Id)
                    return BadRequest(new ApiResponse { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, ErrorMessage = new List<string>() { "Username is already taken!" } });
                var userphone = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.Phone);
                if (userphone is not null && userphone.Id != user.Id)
                    return BadRequest(new ApiResponse { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, ErrorMessage = new List<string>() { "Phone is already taken!" } });
               

                user.UserName = model.Username;
                user.Email = model.Email;
                user.PhoneNumber = model.Phone;
              

                var result = await _userManager.UpdateAsync(user);



                if (!result.Succeeded)
                {
                    var errors = new List<string>();

                    foreach (var error in result.Errors)
                        errors.Add(error.Description);
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = errors,
                    });
                }

                return Ok(new ApiResponse
                {
                    ErrorMessage = new List<string>() { "Update User" }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string>() { ex.Message },
                });
            }

        }
        [HttpDelete("DeleteActualAsync")]
        public async Task<IActionResult> DeleteActualAsync(string email)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = new List<string> { $"{ModelState}", "Model is not valid" },
                    });


                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                    return BadRequest(new ApiResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, ErrorMessage = new List<string> { "Invalid email" } });

                IdentityResult result = await _userManager.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    var errors = new List<string>();

                    foreach (var error in result.Errors)
                        errors.Add(error.Description);
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessage = errors,
                    });
                }

                return Ok(new ApiResponse
                {
                    Result = "User Deleted !!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage = new List<string>() { ex.Message },
                });
            }
        }

       

    }
}
