namespace ClientConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            Console.WriteLine("Ecris un message");
            string str = Console.ReadLine();
            c.Send(str);

            Console.ReadKey();
        }
    }
}
