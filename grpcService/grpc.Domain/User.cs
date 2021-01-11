namespace grpc.Domain
{
    public class User
    {
        public string userId { get; set; }
        public string password { get; set; }
        public LoginStatus login { get; set; }
    }
}
