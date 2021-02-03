using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new EmailSender());
            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }

    /*
                ManagerBase --------------------BRIDGE--------------------- MessageSenderBase
                     |                                                              |
                     |                                                              |
           -------------------------                                     -------------------------
           |                       |                                     |                       |
           |                       |                                     |                       |
           v                       v                                     v                       v
      CustomerManager           StaffManager                        EmailSender              SmsSender

    */

    // ***************************** refine abstraction *****************************
    class CustomerManager : ManagerBase
    {
        public CustomerManager(MessageSenderBase messageSenderBase) : base (messageSenderBase)
        {

        }

        public void UpdateCustomer()
        {
            _messageSenderBase.Send(new MessageBody { Title = "New customers is came."});
            Console.WriteLine("Customer Updated");
        }

        public void GetCustomers()
        {
            Console.WriteLine("Customers brought.");
        }
    }

    class StaffManager : ManagerBase
    {
        public StaffManager(MessageSenderBase messageSenderBase) : base(messageSenderBase)
        {

        }

        public void UpdateStaff()
        {
            _messageSenderBase.Send(new MessageBody { Title = "New staffs is came." });
            Console.WriteLine("Staffs Updated");
        }

        public void GetStaffs()
        {
            Console.WriteLine("Staffs brought.");
        }
    }
    // ***************************** refine abstraction END *****************************


    // ***************************** abstraction *****************************
    abstract class ManagerBase
    {
        protected MessageSenderBase _messageSenderBase;

        public ManagerBase(MessageSenderBase messageSenderBase)
        {
            _messageSenderBase = messageSenderBase;
        }
    }
    // ***************************** abstraction END *****************************


    // ***************************** implementation *****************************
    class SmsSender : MessageSenderBase
    {
        public override void Send(MessageBody body)
        {
            Console.WriteLine("{0} sent via SmsSender", body.Title);
        }
    }

    class EmailSender : MessageSenderBase
    {
        public override void Send(MessageBody body)
        {
            Console.WriteLine("{0} sent via EmailSender", body.Title);
        }
    }
    // ***************************** implementation END *****************************


    abstract class MessageSenderBase
    {
        public abstract void Send(MessageBody body);

        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }

    class MessageBody
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
