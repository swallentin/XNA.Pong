using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base.ContentTypes
{
    [ContentSerializerRuntimeType("Game.Base.Entities.SpriteEntity, Game.Base")]
    public class SpriteEntityData
    {
        public string Name;
        public string AssetName;
        public Vector2 Position;
        public Vector2 Direction;
        public Rectangle Source;
        public Rectangle Size;
        public float Scale;
        public Vector2 Origin;
        public Vector2 Velocity;
        public float Rotation;
        public Color Color;
        public float LayerDepth;
        
        //[ContentSerializerIgnore]
        //public Texture2D Texture;
        
        //[ContentSerializerIgnore]
        //public SpriteEffects Effects;
    }
}