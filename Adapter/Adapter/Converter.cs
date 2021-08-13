using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Adapter
{
    public class Converter
    {
        private readonly IAdapter _adapter;

        public Converter(IAdapter adapter)
        {
            _adapter = adapter;
        }

        public void WriteFile()
        {
            _adapter.Write();
        }

        public void ReadFile()
        {
            _adapter.Read();
        }
    }
}
