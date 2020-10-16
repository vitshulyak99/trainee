using System;
using Task4.Provider.Interface;

namespace Task4.Provider
{
    public class RandomIntegerProvider : IGenerateInteger
    {
        public int Generate(int minV, int maxV)
        {
            return new Random().Next(minV, maxV);
        }
    }
}
