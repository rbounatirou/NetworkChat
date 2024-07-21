using BibliServeur.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliServeur.Subjects
{
    public interface IServerStartSubject
    {
        public void NotifyOnServerStart(object? _params = null);
        public void AddServerStartObserver(IServerStartObserver _observer);

        public bool RemoveServerStartObserver(IServerStartObserver _observer);
    }
}
