using BibliClient;
using BibliClient.ObserverEvents.Observers;
using BibliClient.ObserverEvents.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    public class ConsoleManagerClient : IClientConnectObserver, IClientReceiveMessageObserver
    {
        public void BeNotified(IClientReceiveMessageSubject _from, object? _params)
        {
            Message m = (Message)_params;
            Console.WriteLine(m.Content);
        }

        public void BeNotified(IClientConnectSubject _from, object? _params)
        {
            Console.WriteLine("Connecté");
        }
    }
}
