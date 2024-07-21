using BibliServeur.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliServeur.Observers
{
    public interface IClientLeaveObserver
    {
        public void OnClientLeaveNotify(IClientLeaveSubject _from, object? _params);
    }
}
