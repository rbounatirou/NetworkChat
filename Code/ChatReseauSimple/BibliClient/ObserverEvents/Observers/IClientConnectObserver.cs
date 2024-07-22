using BibliClient.ObserverEvents.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliClient.ObserverEvents.Observers
{
    public interface IClientConnectObserver
    {
        public void BeNotified(IClientConnectSubject _from, object? _params);
    }
}
