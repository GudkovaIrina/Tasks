using Epam.ListUsers.Entities;
using System;
using System.Xml.Serialization;

namespace Epam.ListUsers.DAL.XMLFiles
{
    public class UserForXML
    {
        [XmlElementAttribute("Id")]
        public Guid Id { get; set; }

        [XmlElementAttribute("Name")]
        public string Name { get; set; }

        [XmlElementAttribute("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        public UserForXML()
        {
        }

        public UserForXML(User user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.DateOfBirth = user.DateOfBirth;
        }
    }
}