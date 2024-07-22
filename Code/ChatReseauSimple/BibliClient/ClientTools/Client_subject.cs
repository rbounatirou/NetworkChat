using BibliClient.ObserverEvents.Observers;
using BibliClient.ObserverEvents.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliClient.ClientTools
{
    public partial class Client : IClientConnectSubject, IClientReceiveMessageSubject
    {
        public void AddSubscriber(IClientReceiveMessageObserver _observer)
        {
            receiveMessageObservers.Add(_observer);
        }

        public void AddSubscriber(IClientConnectObserver _observer)
        {
            clientConnectObservers.Add(_observer);
        }

        public void NotifierClientConnectObservers(object? _params = null)
        {
            clientConnectObservers.ForEach(d=>d.BeNotified(this, _params));
        }

        public void NotifierClientReceiveMessageObservers(object? _params = null)
        {
            receiveMessageObservers.ForEach(d => d.BeNotified(this, _params));
        }

        public bool RemoveSubscriber(IClientReceiveMessageObserver _observer)
        {
            return receiveMessageObservers.Remove(_observer);
        }

        public bool RemoveSubscriber(IClientConnectObserver _observer)
        {
            return clientConnectObservers.Remove(_observer);
        }
    }
}
