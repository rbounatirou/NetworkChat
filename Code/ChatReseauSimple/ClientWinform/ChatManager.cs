using BibliClient.ObserverEvents.Observers;
using BibliClient.ObserverEvents.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWinform
{
    public class ClientManager : IClientConnectObserver, IClientReceiveMessageObserver
    {

        private Form form;
        public ClientManager(Form _form)
        {
            this.form = _form;
        }
        public void BeNotified(IClientReceiveMessageSubject _from, object? _params)
        {
            BibliClient.Message m = (BibliClient.Message)_params;
            ((FormChat)form).AddMessageOnList(m);
           
        }

        public void BeNotified(IClientConnectSubject _from, object? _params)
        {
            ((FormChat)form).AddMessageOnList("Vous avez bien rejoint le serveur");
        }
    }
}
