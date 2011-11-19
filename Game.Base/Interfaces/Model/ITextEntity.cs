using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base.Interfaces.Model
{
    public interface ITextEntity
    {

        string Text
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

        SpriteEffects Effects
        {
            get;
            set;
        }
    }
}
