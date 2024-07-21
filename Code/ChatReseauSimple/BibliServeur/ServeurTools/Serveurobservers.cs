using BibliServeur.Observers;
using BibliServeur.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliServeur.ServeurTools
{
    public partial class Serveur : IReceiveMessageSubject, IClientJoinSubject, IClientLeaveSubject, IServerStartSubject, IServerStopSubject
    {
        
        #region PATTERN OBSERVER METHOD
        public void NotifyOnReceiveMessage(object? _params = null)
        {
            receiveMessageObservers.ForEach(d => d.OnReceiveMessageNotify(this, _params));
        }

        public void AddReceiveMessageObserver(IReceiveMessageObserver _observer)
        {
            receiveMessageObservers.Add(_observer);
        }

        public bool RemoveReceiveMessageObserver(IReceiveMessageObserver _observer)
        {
            return receiveMessageObservers.Remove(_observer);
        }

        public void NotifyOnClientJoin(object? _params = null)
        {
            clientJoinObservers.ForEach(d => d.OnClientJoinNotify(this, _params));
        }

        public void AddClientJoinObserver(IClientJoinObserver _observer)
        {
            clientJoinObservers.Add(_observer);
        }

        public bool RemoveClientJoinObserver(IClientJoinObserver _observer)
        {
            return clientJoinObservers.Remove(_observer);
        }

        public void NotifyOnClientLeave(object? _params = null)
        {
            clientLeaveObservers.ForEach(d => d.OnClientLeaveNotify(this, _params));
        }

        public void AddClientLeaveObserver(IClientLeaveObserver _observer)
        {
            clientLeaveObservers.Add(_observer);
        }

        public bool RemoveClientLeaveObserver(IClientLeaveObserver _observer)
        {
            return clientLeaveObservers.Remove(_observer);
        }

        public void AddServerStopObserver(IServerStopObserver _observer)
        {
            serverStopObservers.Add(_observer);
        }

        public bool RemoveServerStopObserver(IServerStopObserver _observer)
        {
            return serverStopObservers.Remove(_observer);
        }

        public void AddServerStartObserver(IServerStartObserver _observer)
        {
            serverStartObservers.Add(_observer);
        }

        public bool RemoveServerStartObserver(IServerStartObserver _observer)
        {
            return serverStartObservers.Remove(_observer);
        }

        public void NotifyOnServerStart(object? _params = null)
        {
            serverStartObservers.ForEach(d => d.OnServerStartNotify(this, _params));
        }

        public void NotifyOnServerStop(object? _params = null)
        {
            serverStopObservers.ForEach(d => d.OnServerStopNotify(this, _params));  
        }
        #endregion
    }
}
