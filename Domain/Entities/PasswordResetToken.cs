namespace Domain.Entities
{
    public class PasswordResetToken
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }

        public DateTime ExpiresDate { get; set; }

        public bool Used { get; set; } = false;


    }
}
