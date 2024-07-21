using BibliServeur.ServeurTools;

namespace ServeurConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Serveur serv = Serveur.getInstance();
            ConsoleManager manager = new ConsoleManager();
            serv.AddServerStartObserver(manager);
            serv.AddClientJoinObserver(manager);
            serv.AddReceiveMessageObserver(manager);
            serv.AddClientLeaveObserver(manager);
            serv.AddServerStopObserver(manager);
            serv.Start();

            Console.WriteLine("Fin");
        }
    }
}
