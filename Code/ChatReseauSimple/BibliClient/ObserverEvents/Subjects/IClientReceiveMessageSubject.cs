using BibliClient.ObserverEvents.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliClient.ObserverEvents.Subjects
{
    public interface IClientReceiveMessageSubject
    {
        public void NotifierClientReceiveMessageObservers(object? _params = null);
        public void AddSubscriber(IClientReceiveMessageObserver _observer);
        public bool RemoveSubscriber(IClientReceiveMessageObserver _observer);
    }
}
