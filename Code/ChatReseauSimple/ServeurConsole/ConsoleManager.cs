using BibliServeur;
using BibliServeur.Observers;
using BibliServeur.ServeurTools;
using BibliServeur.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeurConsole
{
    public class ConsoleManager : IClientJoinObserver, IClientLeaveObserver, IReceiveMessageObserver, IServerStartObserver, IServerStopObserver
    {
        public void OnClientJoinNotify(IClientJoinSubject from, object? _params)
        {
            Console.WriteLine("Un client à rejoint le serveur");
        }

        public void OnClientLeaveNotify(IClientLeaveSubject _from, object? _params)
        {
            Console.WriteLine("Un client à quitter le serveur");
        }

        public void OnReceiveMessageNotify(IReceiveMessageSubject _from, object? _params)
        {
            if (_params != null)
            {
                Message m = (Message) _params; // Cast de l'objet _params
                string patternDatetime = "hh:mm:ss"; // FORMAT DE L'HEURE
                string dateStr = m.Time.ToString(patternDatetime); // Recuperation du datetime en chaine de caracteres
                Console.WriteLine(String.Format("[{0}]:{1}", dateStr, m.Content));                               
            }

        }

        public void OnServerStartNotify(IServerStartSubject _from, object? _params)
        {
            Console.WriteLine("Le serveur à correctement démarré");
            Serveur s = (Serveur)_from;
            Console.WriteLine("Ecoute du port " + s.ListenPort);
        }

        public void OnServerStopNotify(IServerStopSubject _from, object? _params)
        {
            Console.WriteLine("Le serveur s'est correctement stoppé");
        }
    }
}
