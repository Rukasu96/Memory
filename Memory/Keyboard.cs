using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Keyboard
    {
        public event Action? OnUp;
        public event Action? OnDown;
        public event Action? OnRight;
        public event Action? OnLeft;
        public event Action? OnEnter;

        public void ButtonPressed(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    OnUp?.Invoke();
                    break;
                case ConsoleKey.DownArrow:
                    OnDown?.Invoke();
                    break;
                case ConsoleKey.LeftArrow:
                    OnLeft?.Invoke();
                    break;
                case ConsoleKey.RightArrow:
                    OnRight?.Invoke();
                    break;
                case ConsoleKey.Enter:
                    OnEnter?.Invoke();
                    break;
                default: 
                    break;
            }
        }

        
    }
}
