namespace Game.Base.Texture
{
    public class TextureConfigurationHandler
    {
        public static TextureConfiguration Instance 
        {
            get { return System.Configuration.ConfigurationManager.GetSection("textureConfiguration") as TextureConfiguration; }
        }
    }
}
