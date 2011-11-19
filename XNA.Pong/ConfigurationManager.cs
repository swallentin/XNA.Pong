using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XNA.Pong
{
    [XmlType("configuration")]
    public sealed class ConfigurationManager
    {

        public static ConfigurationManager Instance { get; private set; }

        static ConfigurationManager()
        {
            if(Instance == null)
            {
                string file = @"Managers.config";

                if( !File.Exists(file))
                {
                    throw new FileNotFoundException();
                }

                using(StreamReader reader = new StreamReader(file))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ConfigurationManager));
                    Instance = (ConfigurationManager) serializer.Deserialize(reader);
                }
            }
        }

        [XmlArray("managers"), XmlArrayItem("manager")]
        public Managers Managers { get; set; }

    }

    public sealed class Managers : KeyedCollection<string, Manager>
    {
        protected override string GetKeyForItem(Manager item)
        {
            return item.Value;
        }
    }

    [XmlType("manager")]
    public sealed class Manager
    {
        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("interfaceType")]
        public string InterfaceType { get; set; }
    }
}
