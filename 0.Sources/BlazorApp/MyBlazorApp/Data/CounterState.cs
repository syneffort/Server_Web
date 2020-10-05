using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlazorApp.Data
{
    public class CounterState
    {
        private int _count = 0;

        public Action OnStateChanged;

        private void Refresh()
        {
            OnStateChanged?.Invoke();
        }

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                Refresh();
            }
        }
    }
}
