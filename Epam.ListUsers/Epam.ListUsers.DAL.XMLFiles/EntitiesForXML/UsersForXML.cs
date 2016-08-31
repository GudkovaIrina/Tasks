using Epam.ListUsers.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Epam.ListUsers.DAL.XMLFiles
{
    [XmlRootAttribute("Data")]
    public class UsersForXML
    {
        [XmlArrayAttribute("Users")]
        public UserForXML[] users;

        public UsersForXML()
        {
        }

        public UsersForXML(IEnumerable<User> users)
        {
            this.users = users.Select(u => new UserForXML(u)).ToArray();
        }
    }
}