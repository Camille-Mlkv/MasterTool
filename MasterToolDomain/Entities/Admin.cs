

using SQLite;

namespace MasterToolDomain.Entities
{
    public class Admin:User
    {
        [PrimaryKey, AutoIncrement]
        public int Id {  get; set; }

        public Admin() { }
        public Admin(User user)
        {
            Username = user.Username;
            Password = user.Password;
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
        }

    }
}
