using System.Net.Sockets;
using System.Net;
using System.Text;
using BibliClient.ObserverEvents.Observers;

namespace BibliClient.ClientTools
{
    public partial class Client
    {
        public const int PORT = 8081;
        private readonly string ip;

        public string Ip { get => ip; }
        private TcpClient tcpClient { get; set; }
        private static Client instance;
        private Socket communication;
        private readonly Encoding ENCODING = Encoding.UTF8;
        private List<IClientConnectObserver> clientConnectObservers;
        private List<IClientReceiveMessageObserver> receiveMessageObservers;
        private Thread threadEcoute;

        private Client() : this(findLocalIp(), PORT)
        {
        }
        private Client(string _IP, int _port)
        {
            if (_IP == null)
                throw new Exception("Pb IP");

            clientConnectObservers = new List<IClientConnectObserver>();
            receiveMessageObservers = new List<IClientReceiveMessageObserver>();

            this.ip = _IP;
            tcpClient = new TcpClient();
            tcpClient.Connect(ip, PORT);
            communication = tcpClient.Client;
            NotifierClientConnectObservers();
            threadEcoute = new Thread(new ThreadStart(ListenServer));
            threadEcoute.Start();

        }

        ~Client()
        {
            tcpClient.Close();
            
        }

        public static Client getInstance()
        {
            if (instance == null)
                instance = new Client();
            return instance;
        }
        public void Send(string str)
        {

            communication.Send(prepareMessage(str));
            

        }


        private void ListenServer() // LANCE DANS UN THREAD
        {

            while (communication.Connected)
            {
                byte[] bytes = new byte[100];
                int length = communication.Receive(bytes);
                string str= ENCODING.GetString(bytes);
                NotifierClientReceiveMessageObservers(new Message(str));
                Thread.Sleep(5); // PETITE PAUSE
            }
        }

        private byte[] prepareMessage(string _str)
        {
            return ENCODING.GetBytes(_str);
        }


        private static string findLocalIp()
        {
            IPHostEntry iph = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = iph.AddressList;
            string str = null;
            int i = 0;

            while (i < addr.Length && str == null)
            {
                if (addr[i].AddressFamily == AddressFamily.InterNetwork)
                    str = addr[i].ToString();
                i++;
            }
            return str;
        }

    }
}