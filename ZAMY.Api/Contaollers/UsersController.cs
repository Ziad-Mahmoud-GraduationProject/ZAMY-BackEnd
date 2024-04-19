using Authentication.Authorization.Helper.Dtos;
using Authentication.Authorization.Helper.Helpers;
using Authentication.Authorization.Helper.Models;
using Authentication.Authorization.Helper.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using ZAMY.Api.Dtos;
namespace ZAMY.Api.Contaollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IRoleService _roleService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWT _jwt;

        public UsersController(IAuthService authService, IRoleService roleService, UserManager<ApplicationUser> userManager, IOptions<JWT> jwt)
        {
            _authService = authService;
            _roleService = roleService;
            _userManager = userManager;
            _jwt = jwt.Value;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(ResponseFinal.Ok(Result : result));
        } 
        [HttpPost("Login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("AddPermissions")]
        public async Task<IActionResult> AddPermissions(PermissionsFormDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddPermissions(model);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(model);
        }
        [HttpGet("GetPermissions")]
        public async Task<IActionResult> GetPermissions(string roleId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetPermissions(roleId);

            if (result == null)
                return NotFound("");

            return Ok(result);
        }


        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromQuery] Authentication.Authorization.Helper.Helpers.PaginationParameters paginationParameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetAllUser(paginationParameters);

            if (result == null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetUserById(id);

            if (result == null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetUserByUsername")]
        public async Task<IActionResult> GetUserByUsername(string Username)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetUserByUsername(Username);

            if (result == null)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string Email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetUserByEmail(Email);

            if (result == null)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpGet("GetUsersByRoleName/{roleName}")]
        public async Task<IActionResult> GetUsersByRoleName(string roleName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetUsersByRoleName(roleName);

            if (result == null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetUsersByRoleId/{roleId}")]
        public async Task<IActionResult> GetUsersByRoleId(string roleId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetUsersByRoleId(roleId);

            if (result == null)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpGet("CheackUserIsActiveById")]
        public async Task<IActionResult> CheackUserIsActiveById(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.CheackUserIsActiveById(id);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);

        }

        [HttpGet("CheackUserIsBlockById")]
        public async Task<IActionResult> CheackUserIsBlockById(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.CheackUserIsBlockById(id);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("ActiveByIdAsync/{id}")]
        public async Task<IActionResult> ActiveByIdAsync(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ActiveByIdAsync(id);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("ActiveByEmailAsync/{email}")]
        public async Task<IActionResult> ActiveByEmailAsync(string email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ActiveByEmailAsync(email);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("ActiveByUserNameAsync/{username}")]
        public async Task<IActionResult> ActiveByUserNameAsync(string username)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ActiveByUserNameAsync(username);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("ChangeRole")]
        public async Task<ActionResult> ChangeUserRole([FromBody] ChangeUserRoleDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ChangeUserRole(model);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ChangePassword(model);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ResetPassword(model);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(string id, UpdateUserDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.UpdateAsync(id, model);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        [HttpPut("UpdateUsernameAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(string id, UpdateUsernameforUserDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.UpdateUsernameAsync(id, model);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(model);
        }

        [HttpPut("UpdateEmaiilAsync/{id}")]
        public async Task<IActionResult> UpdateAsync(string id, UpdateEmailforUserDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.UpdateEmailAsync(id, model);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);
        }



        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(string email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.DeleteAsync(email);

            if (result.Code == HttpStatusCode.BadRequest)
                return BadRequest(result.Message);

            if (result.Code == HttpStatusCode.NotFound)
                return NotFound(result.Message);

            return Ok(result.Message);
        }







        #region Roles
        [HttpGet("GetAllRole")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetRolesAsync();

            if (roles == null) return NotFound("404");

            return Ok(roles);
        }
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles([FromQuery] Authentication.Authorization.Helper.Helpers.PaginationParameters paginationParameters)
        {
            var roles = await _roleService.GetRolesAsync(paginationParameters);

            if (roles == null) return NotFound("404");

            return Ok(roles);
        }

        [HttpGet("GetRoleById/Id")]
        public async Task<IActionResult> GetRoleById(string Id)
        {
            var roles = await _roleService.GetRoleAsync(Id);

            if (roles == null) return NotFound("404");

            return Ok(new RoleDto() { Id = roles.Id, Name = roles.Name });
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(string name)
        {
            var roles = await _roleService.AddRoleAsync(name);

            if (roles == null) return BadRequest(roles);

            return Ok(roles);
        }
        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(RoleDto role)
        {
            var roles = await _roleService.UpdateRoleAsync(role);

            if (roles == null) return BadRequest(roles);

            return Ok(roles);
        }
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var roles = await _roleService.DeleteRoleAsync(id);

            if (roles == null) return BadRequest(roles);

            return Ok(roles);
        }

        #endregion


    }
}
