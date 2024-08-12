﻿using BibliServeur.Observers;
using BibliServeur.ServeurTools.Utilisateurs;
using BibliServeur.Subjects;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace BibliServeur.ServeurTools
{

    /* CLASSE CHARGEE DE REALISER LES COMMUNICATION SOUS LE ROLE
     * DE SERVEUR
     * IMPLEMENTE UN PATTERN SINGLETON
     * */
    public partial class Serveur
    {
        private int listenPort;
        private string ipAddress;
        private TcpListener listener;
        private static Serveur instance;
        private List<IClientJoinObserver> clientJoinObservers;
        private List<IClientLeaveObserver> clientLeaveObservers;
        private List<IReceiveMessageObserver> receiveMessageObservers;
        private List<IServerStartObserver> serverStartObservers;
        private List<IServerStopObserver> serverStopObservers;
        private List<Utilisateur> clients;

        #region Accesseur et Mutateurs
        public int ListenPort { get => listenPort; private set => setListenPort(value); }
        public string IpAddress { get => ipAddress; }
        #endregion


        private void setListenPort(int _port)
        {
            if (_port < 1)
                throw new ArgumentOutOfRangeException("Le port d'ecoute ne peut etre associe à une valeur inférieur à 1");
            listenPort = _port;
        }


        private Serveur(int _port, string _ipAddress)
        {
            if (_ipAddress == null)
                throw new Exception("ipAdress cannot be null");
            ListenPort = _port;
            clientJoinObservers = new List<IClientJoinObserver>();
            clientLeaveObservers = new List<IClientLeaveObserver>();
            receiveMessageObservers = new List<IReceiveMessageObserver>();
            serverStartObservers = new List<IServerStartObserver>();
            serverStopObservers = new List<IServerStopObserver>();
            clients = new List<Utilisateur>();
            ipAddress = _ipAddress;
            listener = new TcpListener(IPAddress.Parse(ipAddress), listenPort);
        }

        ~Serveur()
        {
            listener.Stop();
        }

        public void Start()
        {
            listener.Start();
            this.NotifyOnServerStart();
            while (true)
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                //accept
                
                Socket s = listener.AcceptSocket();

                //receive

                Thread th = new Thread(new ThreadStart(()=>ReceiveMessage(s)));
                th.Start();
            }
            this.NotifyOnServerStop();
        }

        private void ReceiveMessage(Socket _s)
        {
            bool end = false;
            while (!end)
            {
                try
                {
                    ReceiveClient(_s);
                }
                catch (SocketException e)
                {
                    end = true;
                    _s.Close();
                }
            }
        }

        private void AddClient(Utilisateur _s)
        {
            if (clients.Find(c => c.Socket.Connected && c.Socket.RemoteEndPoint.Equals(_s.Socket.RemoteEndPoint)) != null)
                return;
            clients.Add(_s);
            this.NotifyOnClientJoin(_s);

        }
             
        private void ReceiveClient(Socket _s)
        {
            AddClient(new Utilisateur(_s));
            string str = GetMessageFromSocket(_s);
            this.NotifyOnReceiveMessage(new Message(str));
            SendMessageToAll(str);

        }

        private void SendMessageToAll(string _s)
        {
            List<Utilisateur> userConnected = clients.FindAll(c => c.Socket.Connected);

            for (int i = 0; i < userConnected.Count; i++)
            {
                Socket tmp = userConnected[i].Socket;
                SendConfirmMessage(tmp, _s);
            }
        }

        private string GetMessageFromSocket(Socket _s)
        {
            string str = "";
            const int BUFFER_SIZE = 100;
            byte[] b;
            int k;

            do
            {
                b = new byte[BUFFER_SIZE];
                k = _s.Receive(b);
                str += Encoding.UTF8.GetString(b).Substring(0,k);


            } while (_s.Available > 0);
            return str;
            /*
            int k = _s.Receive(b);
            
            
            string str = "";
            for (int i = 0; i < k; i++)
                str = str + Convert.ToChar(b[i]);
            k = _s.Receive(b);
            return str;*/
        }


        private void SendConfirmMessage(Socket _s, string _message)
        {
            byte[] b = Encoding.UTF8.GetBytes(_message);
            _s.Send(b);
        }

        private static string? FindLocalIp()
        {
            IPHostEntry iph = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = iph.AddressList;
            string? str = null;
            int i = 0;

            while (i < addr.Length && str == null)
            {
                if (addr[i].AddressFamily == AddressFamily.InterNetwork)
                    str = addr[i].ToString();
                i++;
            }
            return str;
        }


        // Pattern Singletons

        public static Serveur getInstance(int _port, string _ipAddress)
        {
            if (instance == null)
            {
                instance = new Serveur(_port, _ipAddress);
            }
            return instance;
        }

        public static Serveur getInstance(int _port) => getInstance(_port, FindLocalIp());
        public static Serveur getInstance() => getInstance(8081, FindLocalIp());


    }
}
