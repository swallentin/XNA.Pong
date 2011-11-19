using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class SpriteEntity : ISpriteEntity
    {
        #region Fields

        private Rectangle _size;
        private Rectangle _source;
        private float _scale = 1.0f;
        private Vector2 _origin;

        #endregion

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteEntity"/> class.
        /// </summary>
        public SpriteEntity()
        {
            Color = Color.White;
        }

        #endregion

        #region Virtual Methods
        

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the asset.
        /// </summary>
        /// <value>The name of the asset.</value>
        public string AssetName
        {
            get; set; 
        }
        
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        
        public Vector2 Direction
        {
            get; set; 
        }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public Rectangle Source
        {
            get { return _source; }
            set
            {
                _source = value;
                Size = new Rectangle(0,0, (int)(_source.Width * Scale), (int)(_source.Height* Scale) );
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public Rectangle Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>The scale.</value>
        public float Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                Size = new Rectangle(0, 0, (int)(Source.Width * Scale), (int)(Source.Height * Scale));
            }
        }

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>The origin.</value>
        public virtual Vector2 Origin { 
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the velocity.
        /// </summary>
        /// <value>The velocity.</value>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        public float Rotation { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {
            get; set; 
        }

        /// <summary>
        /// Gets or sets the layer depth.
        /// </summary>
        /// <value>The layer depth.</value>
        public float LayerDepth { get; set; }

        /// <summary>
        /// Gets or sets the effects.
        /// </summary>
        /// <value>The effects.</value>
        [ContentSerializerIgnore]
        public SpriteEffects Effects { get; set; }


        /// <summary>
        /// Gets or sets the sprite texture.
        /// </summary>
        /// <value>The sprite texture.</value>
        [ContentSerializerIgnore]
        public Texture2D Texture { get; set; }

        #endregion

    }
}