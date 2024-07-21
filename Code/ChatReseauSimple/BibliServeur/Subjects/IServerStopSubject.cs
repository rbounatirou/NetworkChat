using BibliServeur.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliServeur.Subjects
{
    public interface IServerStopSubject
    {
        public void NotifyOnServerStop(object? _params = null);
        public void AddServerStopObserver(IServerStopObserver _observer);

        public bool RemoveServerStopObserver(IServerStopObserver _observer);
    }
}
