using BibliServeur.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliServeur.Subjects
{
    public interface IClientLeaveSubject
    {
        public void NotifyOnClientLeave(object? _params = null);
        public void AddClientLeaveObserver(IClientLeaveObserver _observer);

        public bool RemoveClientLeaveObserver(IClientLeaveObserver _observer);
    }
}
