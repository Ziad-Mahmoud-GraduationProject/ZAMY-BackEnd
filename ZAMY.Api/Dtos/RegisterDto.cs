namespace ZAMY.Api.Dtos
{
    public class RegisterDto
    {
        public string Role { get; set; } = null!;

        [MaxLength(100), MinLength(8)]
        public string Email { get; set; } = null!;
        [MaxLength(100), MinLength(6)]
        public string Username { get; set; } = null!;
        [MaxLength(11), MinLength(10)]
        public string Phone { get; set; } = null!;
        [MaxLength(100), MinLength(6)]
        public string Password { get; set; } = null!;
        [Compare("Password"), Display(Name = "Password Confirm")]
        public string PasswordConfirm { get; set; } = null!;
    }
}
