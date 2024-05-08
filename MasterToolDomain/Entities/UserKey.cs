using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MasterToolDomain.Entities
{
    public class UserKey
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string? UserType { get; set; }
        public string? Key { get; set; }

        public UserKey() { }
        public UserKey(string? userType, string? key)
        {
            UserType = userType;
            Key = key;
        }

        public override bool Equals(object? obj)
        {
            if (obj is UserKey userKey) return UserType == userKey.UserType && Key==userKey.Key;
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
