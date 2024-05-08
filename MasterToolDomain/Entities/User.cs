

namespace MasterToolDomain.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname {  get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserCategory = "";

        public User() { }

        public User(string username, string password, string name, string surname, string email, string phonenumber)
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phonenumber;
        }

        //public virtual bool SignUp(string IdentificationKey)
        //{
        //    //LocalData.Users.Add(this);
        //    return true;
        //}

    }
}
