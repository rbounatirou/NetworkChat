using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BibliServeur.ServeurTools.Utilisateurs
{
    public class Utilisateur
    {
        private Socket socket;
        private string? name;

        public Socket Socket { get => socket; }
        public string? Name {  get => name; }

        public Utilisateur(Socket _socket, string? _name = null)
        {
            socket = _socket;
            name = _name;
        }

    }
}
