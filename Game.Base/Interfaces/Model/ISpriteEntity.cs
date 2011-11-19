using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base.Interfaces.Model
{
    public interface ISpriteEntity:IEntity
    {


        /// <summary>
        /// Gets or sets the name of the asset.
        /// </summary>
        /// <value>The name of the asset.</value>
        string AssetName { get; set; }

        /// <summary>
        /// Gets or sets the sprite texture.
        /// </summary>
        /// <value>The sprite texture.</value>
        
        Texture2D Texture { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        Rectangle Source { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        Rectangle Size { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>The scale.</value>
        float Scale { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        Color Color { get; set; }

        /// <summary>
        /// Gets or sets the layer depth.
        /// </summary>
        /// <value>The layer depth.</value>
        float LayerDepth { get; set; }

        /// <summary>
        /// Gets or sets the effects.
        /// </summary>
        /// <value>The effects.</value>

        SpriteEffects Effects { get; set; }
    }
}
