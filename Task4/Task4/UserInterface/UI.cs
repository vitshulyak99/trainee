using System;
using Task4.LineHandlers;
using Task4.Worker;

namespace Task4.UserInterface
{
    public class UI
    {
        private const string constLine = "a,b,a,c,d,g,f,f,d,y,t,r,e,e,a,a,2";
        private readonly string _menuInfo = $"\n1 - write line and do job\n2 - do job with {constLine} parametr\n3 - exit";
        MainWorker _worker = null;
   

        public UI(MainWorker worker)
        {
            _worker = worker ?? throw new ArgumentNullException(nameof(worker));
            _worker.OnUpdate += _worker_OnUpdate;
        }

        

        public async System.Threading.Tasks.Task MenuAsync()
        {
            
            bool b = true;


            while (b)

            {
                PrintMenuInfo();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        {
                            Console.WriteLine("\nwrite line. Formar 'char,([char,]...)int'");
                            var line = Console.ReadLine();
                            var symbols = LineParser.GetOnlyWordCharacterFromString(line);
                            var n = LineParser.GetOnlyNumber(line);
                            _worker.DoJob(symbols,n);

                        }
                        break;

                    case ConsoleKey.D2:
                        {
                            Console.WriteLine("\n");
                            
                            var symbols = LineParser.GetOnlyWordCharacterFromString(constLine);
                            var n = LineParser.GetOnlyNumber(constLine);
                            _worker.DoJob(symbols, n);
                        }
                        break;

                    case ConsoleKey.D3:
                        {

                            Console.WriteLine("\n");
                            b = false;
                        }
                        break;

                }
            }

        }

        private void PrintMenuInfo() => Console.WriteLine(_menuInfo);

        private void _worker_OnUpdate(object arg1, EventArgs.CustomEventArgs arg2)
        {
            var number = arg2.Count;
            var symbol = arg2.Symbol;
            var FileLastModifiedDate = arg2.UpdateTime;
            Console.WriteLine($"File has {number} {symbol} symbols at {FileLastModifiedDate.TimeOfDay}");
        }

    }
}
