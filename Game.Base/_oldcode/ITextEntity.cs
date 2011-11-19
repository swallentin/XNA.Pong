using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base.Interfaces
{
    public interface ITextEntity
    {
        void Draw(GameTime gameTime);

        string Text
        {
            get;
            set;
        }

        ITextGraphics Graphics
        {
            get;
            set;
        }

        Vector2 Position
        {
            get;
            set;
        }

        SpriteFont Font
        {
            get;
            set;
        }

        Color Color
        {
            get;
            set;
        }

        float Rotation
        {
            get;
            set;
        }

        float Scale
        {
            get;
            set;
        }

        SpriteEffects SpriteEffects
        {
            get;
            set;
        }
    }
}
