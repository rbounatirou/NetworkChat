using BibliClient.ObserverEvents.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliClient.ObserverEvents.Observers
{
    public interface IClientReceiveMessageObserver
    {
        public void BeNotified(IClientReceiveMessageSubject _from, object? _params);
    }
}
