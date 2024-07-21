using BibliServeur.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliServeur.Subjects
{
    public interface IClientJoinSubject
    {
        public void NotifyOnClientJoin(object? _params = null);
        public void AddClientJoinObserver(IClientJoinObserver _observer);

        public bool RemoveClientJoinObserver(IClientJoinObserver _observer);

    }
}
