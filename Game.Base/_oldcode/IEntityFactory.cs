namespace Game.Base.Interfaces
{
    public interface IEntityFactory
    {
        ISpriteEntity CreateSprite(string type);
    }
}
