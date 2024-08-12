using BibliClient.ObserverEvents.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliClient.ObserverEvents.Subjects
{
    public interface IClientConnectSubject
    {
        public void NotifierClientConnectObservers(object? _params = null);
        public void AddSubscriber(IClientConnectObserver _observer);
        public bool RemoveSubscriber(IClientConnectObserver _observer);

    }
}
