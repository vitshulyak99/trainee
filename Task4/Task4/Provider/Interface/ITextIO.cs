using System;
using System.Threading.Tasks;

namespace Task4.Provider.Interface
{
    
    public interface ITextIO
    {
        DateTime LastModified { get; }

        string ReadAll();

        void Write(char sym,bool append);

    }
}
