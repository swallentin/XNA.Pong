using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Storage;

namespace Game.Base.Configuration
{
    [XmlType("configuration")]
    public sealed class ConfigurationManager
    {
        public static ConfigurationManager Instance { get; private set; }

        static ConfigurationManager()
        {
            if (Instance == null)
            {
                string file = string.Format("{0}\\Game.config", Environment.CurrentDirectory);


                if (!File.Exists(file))
                {
                    throw new FileNotFoundException();
                }

                using (StreamReader reader = new StreamReader(file))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof (ConfigurationManager));
                    Instance = (ConfigurationManager) serializer.Deserialize(reader);
                }
            }
        }

        [XmlArray("managers"), XmlArrayItem("manager")]
        public Managers Managers { get; set; }


        [XmlArray("textures"), XmlArrayItem("textures")]
        public Textures Textures { get; set; }
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

    public sealed class Textures : KeyedCollection<string, Texture>
    {
        protected override string GetKeyForItem(Texture item)
        {
            return item.AssetName;
        }
    }

    [XmlType("texture")]
    public sealed class Texture
    {
        [XmlAttribute("assetName")]
        public string AssetName { get; set; }
    }
}