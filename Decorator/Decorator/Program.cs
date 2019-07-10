using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class Component
    {
        public abstract string Operation();
    }

    class Statue : Component
    {
        public override string Operation()
        {
            return "Statue";
        }
    }

    class PhotoFrame: Component
    {
        public override string Operation()
        {
            return "Photo Frame";
        }
    }

    abstract class Decorator : Component
    {
        protected Component _component;

        public Decorator(Component component)
        {
            this._component = component;
        }

        public void SetComponent(Component component)
        {
            this._component = component;
        }

        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }
    class Stand : Decorator
    {
        public Stand(Component comp) : base(comp)
        {
        }
        public override string Operation()
        {
            return $"Stand + {base.Operation()}";
        }
    }
    class Backlight : Decorator
    {
        public Backlight(Component comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"Backlight + {base.Operation()})";
        }
    }

    public class Client
    {
        public void ClientCode(Component component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            var simple = new Statue();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(simple);
            Console.WriteLine();
            Stand decorator1 = new Stand(simple);
            Backlight decorator2 = new Backlight(decorator1);
            Console.WriteLine("Client: Now I've got a decorated component:");
            client.ClientCode(decorator2);
        }
    }
}