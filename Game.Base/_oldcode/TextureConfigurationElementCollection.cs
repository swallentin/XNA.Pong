using System.Configuration;

namespace Game.Base.Texture
{
    public class TextureConfigurationElementCollection : ConfigurationElementCollection
    {

        /// <summary>
        /// Gets or sets the <see cref="Host"/> at the specified index.
        /// </summary>
        /// <value></value>
        public TextureConfigurationSection this[int index]
        {
            get
            {
                return BaseGet(index) as TextureConfigurationSection;
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new TextureConfigurationSection() ;
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TextureConfigurationSection)element).Name;
        }

    }
}