using System.Configuration;

namespace Game.Base.Texture
{
    public class TextureConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get { return this["name"] as string; }
        }

        [ConfigurationProperty("assetName")]
        public string AssetName
        {
            get { return this["assetName"] as string; }
        }
    }
}
