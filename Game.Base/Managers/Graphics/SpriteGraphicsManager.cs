using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base.Managers.Graphics
{
    public class SpriteGraphicsManager:GraphicsManagerBase,ISpriteGraphicsManager
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteGraphicsManager"/> class.
        /// </summary>
        /// <param name="game">The Game that the game component should be attached to.</param>
        public SpriteGraphicsManager(Microsoft.Xna.Framework.Game game) : base(game)
        {
            
        }

        #endregion


        #region Members

        /// <summary>
        /// Called when the DrawableGameComponent needs to be drawn. Override this method with component-specific drawing code. Reference page contains links to related conceptual articles.
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw.</param>
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            foreach (ISpriteEntity spriteEntity in SceneManager.GetSpriteEntitiesToRender(gameTime))
            {
                Draw(spriteEntity);
            }

            SpriteBatch.End();
        }

        /// <summary>
        /// Draws the specified sprite.
        /// </summary>
        /// <param name="spriteEntity">The sprite.</param>
        public virtual void Draw(ISpriteEntity spriteEntity)
        {
            SpriteBatch.Draw(spriteEntity.Texture, spriteEntity.Position, spriteEntity.Source, spriteEntity.Color, spriteEntity.Rotation, spriteEntity.Origin, spriteEntity.Scale, spriteEntity.Effects, spriteEntity.LayerDepth);
        }
        

        #endregion

    }
}
