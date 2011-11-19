using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base.Interfaces
{
    public interface ISpriteEntity
    {
        void Initialize();

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="assetname">The assetname.</param>
        void LoadContent(string assetname);

        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the asset.
        /// </summary>
        /// <value>The name of the asset.</value>
        string AssetName { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        Vector2 Direction { get; set; }

        /// <summary>
        /// Gets or sets the sprite texture.
        /// </summary>
        /// <value>The sprite texture.</value>
        Texture2D SpriteTexture { get; set; }

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
        /// Gets or sets the origin.
        /// </summary>
        /// <value>The origin.</value>
        Vector2 Origin { get; set; }

        /// <summary>
        /// Gets or sets the velocity.
        /// </summary>
        /// <value>The velocity.</value>
        Vector2 Velocity { get; set; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        float Rotation { get; set; }

        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>The game.</value>
        Microsoft.Xna.Framework.Game Game { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        Color Color { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>The input.</value>
        IInput Input
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the Graphics.
        /// </summary>
        /// <value>The Graphics.</value>
        ISpriteGraphics Graphics
        {
            get;
            set;
        }
    }
}
