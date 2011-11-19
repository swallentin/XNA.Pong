namespace Game.Base.Interfaces
{
    public interface ITextureManager
    {
        ITextureManager Instance { get; }
        void AddTexture(string assetName);
        void RemoveTexture(string assetName);
        Microsoft.Xna.Framework.Graphics.Texture GetTexture(string assetName);
        void LoadTexture(string assetName, ISpriteEntity spriteEntity);
    }
}
