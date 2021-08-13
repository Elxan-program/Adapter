using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Adapter
{
    public class AppL
    {
        private readonly Converter _converter;

        public AppL(IAdapter adapter)
        {
            _converter = new Converter(adapter);
        }

        public void Start()
        {
            _converter.WriteFile();
            _converter.ReadFile();

        }
    }
}
