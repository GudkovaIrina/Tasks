using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messages.Models
{
    public class Message
    {
        static public List<Message> _messages = new List<Message>();

        public Guid Id { get; set; }
        public String Text { get; set; }

        public static IEnumerable<Message> GetAll()
        {
            return _messages.ToArray();
        }

        public static Message GetById(Guid id)
        {
            return _messages.FirstOrDefault(m => m.Id == id);
        }

        public static void Create(Message model)
        {
            model.Id = Guid.NewGuid();
            _messages.Add(model);
        }

        public static void Edit(Message model)
        {
            var forEdit = GetById(model.Id);
            if (forEdit != null)
            {
                forEdit.Text = model.Text;
            }
            else 
            {
                throw new ArgumentException("This message was not found!");
            }
        }

        public static void Remove(Guid id)
        {
            var forRemove = GetById(id);
            if (forRemove != null)
            {
                _messages.Remove(forRemove);
            }
            else
            {
                throw new ArgumentException("This message was not found!");
            }
        }
    }
}