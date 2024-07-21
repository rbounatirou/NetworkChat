using BibliServeur.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliServeur.Observers
{
    public interface IReceiveMessageObserver
    {
        public void OnReceiveMessageNotify(IReceiveMessageSubject _from, object? _params);
    }
}
