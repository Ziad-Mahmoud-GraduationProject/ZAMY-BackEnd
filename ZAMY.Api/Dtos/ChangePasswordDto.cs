namespace ZAMY.Api.Dtos
{
    public class ChangePasswordDto
    {
        public string Email { get; set; } = null!;
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; } = null!;
        [Display(Name = "New Password")]
        public string NewPassword { get; set; } = null!;
        [Compare("NewPassword"), Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; } = null!;
    }
}
