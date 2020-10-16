using System;

namespace Task4.EventArgs
{
    public class CustomEventArgs
    {
        public int Count { get; }

        public char Symbol { get; }

        public DateTime UpdateTime { get; }

        public CustomEventArgs(int count, char symbol, DateTime updateTime)
        {
            Count = count;
            Symbol = symbol;
            UpdateTime = updateTime;
        }
    }
}