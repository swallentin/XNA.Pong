using System;
using Game.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNA.Pong
{
    public class Entity:EntityBase,IFocusable
    {
        #region Fields

        #endregion

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        internal Entity(IInput input, IGraphic graphics, Microsoft.Xna.Framework.Game game):base(input, graphics, game)
        {
            Position = new Vector2(0,0);
        }

        #endregion


        #region Properties


        #endregion

        #region Methods

        ITextureManager TextureManager
        {
            get { return Game.Services.GetService(typeof (ITextureManager)) as ITextureManager; }
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public override void LoadContent( string assetName)
        {
            TextureManager.LoadTexture(assetName, this);
        }



        #endregion
    }
}