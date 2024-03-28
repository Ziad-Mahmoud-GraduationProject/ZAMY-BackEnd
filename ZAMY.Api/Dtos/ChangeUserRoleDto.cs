namespace ZAMY.Api.Dtos
{
    public class ChangeUserRoleDto
    {
        [Display(Name = "User Id")]
        public string UserId { get; set; } = null!;
        [Display(Name = "New Role")]
        public string NewRole { get; set; } = null!;
    }
}
