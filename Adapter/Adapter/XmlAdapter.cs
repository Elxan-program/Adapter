using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Adapter
{
    class XmlAdapter : IAdapter
    {
        Xml Xml;
        public void Read()
        {
            Xml.XML_Deserialize();
        }
        public XmlAdapter(Xml Xml_File)
        {
            Xml = Xml_File;
        }
        public void Write()
        {
            Xml.XML_Serialize();
        }
    }
}
