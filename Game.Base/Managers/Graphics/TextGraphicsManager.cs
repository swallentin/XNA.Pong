using Game.Base.Interfaces.Model;
using Game.Base.Interfaces.View;
using Microsoft.Xna.Framework;

namespace Game.Base.Managers.Graphics
{
    public class TextGraphicsManager : GraphicsManagerBase, ITextGraphicsManager
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteGraphicsManager"/> class.
        /// </summary>
        /// <param name="game">The Game that the game component should be attached to.</param>
        public TextGraphicsManager(Microsoft.Xna.Framework.Game game)
            : base(game)
        {}

        #endregion

        #region Members

        /// <summary>
        /// Called when the DrawableGameComponent needs to be drawn. Override this method with component-specific drawing code. Reference page contains links to related conceptual articles.
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw.</param>
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            foreach (ITextEntity textEntity in SceneManager.GetTextEntitiesToRender(gameTime))
            {
                Draw(textEntity);
            }

            SpriteBatch.End();
        }

        /// <summary>
        /// Draws the specified text entity.
        /// </summary>
        /// <param name="textEntity">The text entity.</param>
        public void Draw(ITextEntity textEntity)
        {
            SpriteBatch.DrawString(textEntity.Font, textEntity.Text, textEntity.Position, textEntity.Color, textEntity.Rotation, Vector2.Zero, textEntity.Scale, textEntity.Effects, 1);
        }

        #endregion


    }
}