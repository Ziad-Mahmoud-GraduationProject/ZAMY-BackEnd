namespace ZAMY.Api.Dtos
{
    public class AuthReturnDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<string> Roles { get; set; }
    }
}
