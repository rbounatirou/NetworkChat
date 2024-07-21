using BibliServeur.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliServeur.Observers
{
    public interface IClientJoinObserver
    {
        public void OnClientJoinNotify(IClientJoinSubject from, object? _params);
    }
}
