namespace Game.Base.Interfaces.Model
{
    public interface ITextureManager
    {
        void AddTexture(string assetName);
        void RemoveTexture(string assetName);
        Microsoft.Xna.Framework.Graphics.Texture GetTexture(string assetName);
        void LoadTexture(string assetName, ISpriteEntity spriteEntity);
    }
}
