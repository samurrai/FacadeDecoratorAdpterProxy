using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Facade
    {
        protected CourierOrder _courierOrder;

        protected ParcelPack _parcelPack;

        protected ShippingPay _shippingPay;


        public Facade(CourierOrder courierOrder, ParcelPack parcelPack, ShippingPay shippingPay)
        {
            this._courierOrder = courierOrder;
            this._parcelPack = parcelPack;
            this._shippingPay = shippingPay;
        }

        // Методы Фасада удобны для быстрого доступа к сложной
        // функциональности подсистем. Однако клиенты получают только часть
        // возможностей подсистемы.
        public string Operation()
        {
            string result = "";
            result += this._courierOrder.Order();
            result += this._parcelPack.Pack();
            result += this._shippingPay.Pay();
            return result;
        }
    }

    public class CourierOrder
    {
        public string Order()
        {
            return "Courier ordered!\n";
        }
    }

    public class ShippingPay
    {
        public string Pay()
        {
            return "Shipping paid!\n";
        }
    }

    public class ParcelPack
    {
        public string Pack()
        {
            return "Parsel packed!\n";
        }
    }

    class Client
    {
        public static void ClientCode(Facade facade)
        {
            Console.Write(facade.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CourierOrder courierOrder = new CourierOrder();
            ParcelPack parcelPack = new ParcelPack();
            ShippingPay shippingPay = new ShippingPay();

            Facade facade = new Facade(courierOrder, parcelPack, shippingPay);
            Client.ClientCode(facade);
        }
    }
}
