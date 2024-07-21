namespace Serveur
{
    using System.Runtime.Remoting;
    public class myRemoteClass : MarshalByRefObject
    {
        public myRemoteClass()
        {
            // TO DO: Add constructor logic here.
        }

        public bool SetString(String sTemp)
        {
            try
            {
                Console.WriteLine("This string '{0}' has a length of {1}", sTemp, sTemp.Length);
                return sTemp != "";
            }
            catch
            {
                return false;
            }
        }
    }
}
