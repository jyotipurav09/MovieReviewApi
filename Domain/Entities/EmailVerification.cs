namespace Domain.Entities
{
    public class EmailVerification
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }

        public DateTime ExpiresDate { get; set; }

        public bool Vereified { get; set; }
    }
}
