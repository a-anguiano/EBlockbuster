namespace EBlockbuster.Models
{
    public class LoginModel
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int SecurityLevelId { get; set; }
    }
}
