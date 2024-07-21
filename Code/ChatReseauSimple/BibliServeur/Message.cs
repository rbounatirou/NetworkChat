using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliServeur
{
    public class Message
    {
        private DateTime time;
        private string content;

        public DateTime Time { get => time; }
        public string Content { get => content; }
        public Message(DateTime _time, string _message)
        {
            this.time = _time;
            this.content = _message;
        }

        public Message(string _message) : this(DateTime.Now, _message) { }

    }
}
