using BibliServeur.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliServeur.Subjects
{
    public interface IReceiveMessageSubject
    {
        public void NotifyOnReceiveMessage(object? _params = null);
        public void AddReceiveMessageObserver(IReceiveMessageObserver _observer);

        public bool RemoveReceiveMessageObserver(IReceiveMessageObserver _observer);
    }
}
