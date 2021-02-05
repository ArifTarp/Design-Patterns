using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            Console.WriteLine("Initial state: " + context.GetState().ToString());
            string input = "";

            do
            {
                Console.WriteLine("Please write; \n For turn on lamp : turn on \n For turn off lamp : turn off \n");
                input = Convert.ToString(Console.ReadLine());

                if (input == "turn on")
                {
                    context.Open();
                }
                else if (input == "turn off")
                {
                    context.Close();
                }

                Console.WriteLine(context.GetState().ToString() + "\n------------------------------------\n");

            } while (input != "exit");
        }
    }

    class OpenState : IState
    {
        private Context _context;

        public OpenState(Context context)
        {
            _context = context;
        }

        public void Close()
        {
            Console.WriteLine("Lamp is turning off");
            _context.SetState(new CloseState(_context));
        }

        public void Open()
        {
            Console.WriteLine("Lamp is already on");
        }
    }

    class CloseState : IState
    {
        private Context _context;

        public CloseState(Context context)
        {
            _context = context;
        }

        public void Close()
        {
            Console.WriteLine("Lamp is already off");
        }

        public void Open()
        {
            Console.WriteLine("Lamp is turning on");
            _context.SetState(new OpenState(_context));
        }
    }

    class Context : IState
    {
        private IState _state;

        public Context()
        {
            _state = new CloseState(this);
        }

        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }

        public void Close()
        {
            _state.Close();
        }

        public void Open()
        {
            _state.Open();
        }
    }

    interface IState
    {
        void Open();
        void Close();
    }
}
