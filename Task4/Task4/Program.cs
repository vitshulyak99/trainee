

using Task4.Provider;
using Task4.UserInterface;

namespace Task4
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string path = @"../../../File/Text.txt";
            var prov = new TextProvider(path);
            var work = new Worker.MainWorker();
            work.SetProvider(prov);
            var ui = new UI(work);

            await ui.MenuAsync();

        }
    }
}
