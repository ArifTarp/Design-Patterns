using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);

            StockOrdersController stockOrdersController = new StockOrdersController();
            stockOrdersController.AddOrder(buyStock);
            stockOrdersController.AddOrder(sellStock);
            stockOrdersController.AddOrder(buyStock);
            stockOrdersController.ExecuteOrders();

            Console.ReadLine();
        }
    }

    // ****************** this is invoker and sends a execute request to commands ******************
    class StockOrdersController
    {
        List<IOrder> _orders = new List<IOrder>();

        public void AddOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void ExecuteOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }
    // ****************** END ******************


    // ****************** we made commands object ******************
    class BuyStock : IOrder
    {
        private StockManager _stockManager;

        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Buy();
        }
    }

    class SellStock : IOrder
    {
        private StockManager _stockManager;

        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Sell();
        }
    }
    // ****************** END ******************


    // ****************** this is receiver class and contain some important business logic ******************
    class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;

        public void Buy()
        {
            _quantity += 1;
            Console.WriteLine("Stock Name : {0}, {1} bought!", _name, _quantity);
        }

        public void Sell()
        {
            _quantity -= 1;
            Console.WriteLine("Stock Name : {0}, {1} sold!", _name, _quantity);
        }
    }
    // ****************** END ******************


    // interface of commands
    interface IOrder
    {
        void Execute();
    }
}
