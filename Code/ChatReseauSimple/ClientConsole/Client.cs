using System.Net.Sockets;
using System.Net;
using System.Text;

internal class Client
{
    public const int PORT = 8081;
    private readonly string IP;
    private TcpClient tcpClient { get; set; }

    public Client() : this(findLocalIp(), PORT)
    {
    }
    public Client(string _IP, int _port)
    {
        if (_IP == null)
            throw new Exception("Pb IP");
        this.IP = _IP;
        tcpClient = new TcpClient(); // ON OUVRE UN LISTENET SUR LE PORT 8085
        tcpClient.Connect(IP, PORT);
    }

    ~Client()
    {
        tcpClient.Close();
    }
    public void Send(string str)
    {

        Console.Write("Envoi de " + str);
        ASCIIEncoding asen = new ASCIIEncoding();
        byte[] strToByte = asen.GetBytes(str);
        Stream stm = tcpClient.GetStream();

        stm.Write(strToByte, 0, strToByte.Length);

        byte[] bb = new byte[100];
        int k = stm.Read(bb, 0, 100);
        Console.Write("\n");
        for (int i = 0; i < k; i++)
            Console.Write(Convert.ToChar(bb[i]));

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