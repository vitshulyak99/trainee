using System;
using System.Threading.Tasks;
using Task4.EventArgs;
using Task4.LineHandlers;
using Task4.Provider;
using Task4.Provider.Interface;

namespace Task4.Worker
{
    public class MainWorker
    {
        private ITextIO _provider;
        private object lockerProv = new object();
        private object lockerN = new object();



        public event Action<object, CustomEventArgs> OnUpdate;

        public MainWorker()
        {

        }

        public void SetProvider(ITextIO provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public void DoJob(string symbols, int n)
        {
            int _n = 0;

            Parallel.ForEach(symbols, sym =>
            {

                int N = 0;
                //System.Threading.Thread.Sleep(new Random().Next(1, 5) * 1000);
                string text = string.Empty;
                lock (lockerProv)
                    text = _provider.ReadAll();
                var count = LineParser.SymRepeats(text, sym);

                lock (lockerN)
                {
                    _n++;
                    N = _n;
                }



                if (N%n == 0)
                {
                    var rsym = LineParser.RandomSymbolFromString(symbols, new RandomIntegerProvider());
                    lock (lockerProv)
                        _provider.Write(rsym, true);

                }


                OnUpdate?.Invoke(this, new CustomEventArgs(count, sym, _provider.LastModified));

            });

        }
    }
}
