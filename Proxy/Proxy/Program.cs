using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface ISender
    {
        void Send();
    }
    class RealSubject : ISender
    {
        public void Send()
        {
            Console.WriteLine("Sended");
        }
    }

    class Proxy : ISender
    {
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            this._realSubject = realSubject;
        }

        public void Send()
        {
            this._realSubject = new RealSubject();
            this._realSubject.Send();
        }
    }

    public class Client
    {
        public void ClientCode(ISender subject)
        {
            subject.Send();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            client.ClientCode(proxy);
        }
    }
}
