using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public interface ISender
    {
        string Send(string message);
    }

    // Адаптируемый класс содержит некоторое полезное поведение, но его
    // интерфейс несовместим  с существующим клиентским кодом. Адаптируемый
    // класс нуждается в некоторой доработке,  прежде чем клиентский код сможет
    // его использовать.
    class MessageSender
    {
        public string SendMessage(string message)
        {
            return message;
        }
    }

    // Адаптер делает интерфейс Адаптируемого класса совместимым с целевым
    // интерфейсом.
    class Adapter : ISender
    {
        private readonly MessageSender _adaptee;

        public Adapter(MessageSender adaptee)
        {
            this._adaptee = adaptee;
        }

        public string Send(string message)
        {
            return $"This is '{this._adaptee.SendMessage(message)}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MessageSender messageSender = new MessageSender();
            ISender target = new Adapter(messageSender);

            Console.WriteLine(target.Send("Hello"));
        }
    }
}
