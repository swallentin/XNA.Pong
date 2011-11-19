using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base.Entities
{
    public class TextEntity:ITextEntity
    {
        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public SpriteFont Font { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; }
        public SpriteEffects Effects { get; set; }
    }
}
