using System.Configuration;

namespace Game.Base.Texture
{
    public class TextureConfiguration:ConfigurationSection
    {
        /// <summary>
        /// Gets the hosts.
        /// </summary>
        /// <value>The hosts.</value>
        [ConfigurationProperty("textures")]
        public TextureConfigurationElementCollection Textures
        {
            get
            {
                return this["textures"] as TextureConfigurationElementCollection;
            }
        }
    }
}
