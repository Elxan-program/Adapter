using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Adapter
{
    public class JsonAdapter:IAdapter
    {
        Json _JSON;
        public void Read()
        {
            _JSON.JSON_Deserialize();
        }

        public JsonAdapter(Json Json)
        {
            _JSON = Json;
        }
        public void Write()
        {
            _JSON.JSON_Serialize();
        }
    }
}
