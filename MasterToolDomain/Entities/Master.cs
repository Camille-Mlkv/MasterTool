using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Master:User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public Master(User user)
        {
            Username = user.Username;
            Password = user.Password;
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
        }
        //test comment
        public Master()
        {

        }
    }
}
