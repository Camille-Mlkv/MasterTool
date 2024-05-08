using SQLite;
using System.Collections.ObjectModel;

namespace MasterToolDomain.Entities
{
    public class Client:User
    {
        [PrimaryKey, AutoIncrement]
        public int Id {  get; set; }
        public Client(User user) 
        {
            Username = user.Username;
            Password = user.Password;
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
        }
        public Client() { }
    }
}
