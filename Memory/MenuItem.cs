using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class MenuItem
    {
        private string title;
        private Action action;

        public string Title { get => title; set => title = value; }
        public Action Action { get => action; set => action = value; }

        public MenuItem(string title, Action action = null)
        {
            this.title = title;
            this.action = action;
        }
    }
}
