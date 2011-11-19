using Game.Base.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA.Pong.Scenes.Model
{
    public class MainMenuItem:TextEntity
    {
        public MainMenuItem(SpriteFont font, string text, Vector2 position)
        {
            Font = font;
            Text = text;
            Position = position;
            Scale = 1.0f;
        }
        public Color SelectedColor { get; set; }
    }
}