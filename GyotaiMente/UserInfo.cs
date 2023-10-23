namespace AuthenticationApp
{
    public class UserInfo
    {
        public string id;
        public string password;
        public string name;

        public UserInfo(string id, string password, string name)
        {
            this.id = id;
            this.password = password;
            this.name = name;
        }
    }
}