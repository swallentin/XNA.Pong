namespace Game.Base.Interfaces
{
    public interface ITexture
    {
        string AssetName { get; set; }
        Microsoft.Xna.Framework.Graphics.Texture TextureBase { get; }
        void LoadContent();
        void UnloadContent();
    }
}