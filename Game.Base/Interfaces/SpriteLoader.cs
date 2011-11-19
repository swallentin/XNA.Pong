using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;

namespace Game.Base.Interfaces
{
    public interface ISpriteLoader
    {
        IGameManager GameManager { get; set; }
        void LoadSprite(string contentFile, ref ISpriteEntity spriteEntity);
        void LoadSprite<T>(string contentfile, ref T spriteEntity);
        ISpriteEntity LoadSprite(string contentFile);
        
    }
}