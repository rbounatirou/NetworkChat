using BibliClient.ClientTools;
using BibliClient.ObserverEvents.Observers;

namespace ClientConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client c = Client.getInstance();
            ConsoleManagerClient cm = new ConsoleManagerClient();
            c.AddSubscriber((IClientConnectObserver)cm);
            c.AddSubscriber((IClientReceiveMessageObserver)cm);
            while (true)
            {
                Console.WriteLine("Ecris un message");
                string str = Console.ReadLine();
                c.Send(str);
                Thread.Sleep(100);
            }
        }

    }
}
