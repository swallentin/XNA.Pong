using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base.Entities;
using Game.Base.Interfaces;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;

namespace Game.Base
{
    public class SpriteLoader:ISpriteLoader
    {
        public SpriteLoader(IGameManager gameManager)
        {
            GameManager = gameManager;
        }

        #region Implementation of ISpriteLoader

        public IGameManager GameManager { get; set; }

        /// <summary>
        /// Loads the sprite.
        /// </summary>
        /// <param name="contentFile">The content file.</param>
        /// <param name="spriteEntity">The sprite entity.</param>
        public void LoadSprite(string contentFile, ref ISpriteEntity spriteEntity)
        {
            spriteEntity = GameManager.ContentManager.Load<SpriteEntity>(contentFile);
            GameManager.TextureManager.LoadTexture(spriteEntity.AssetName, spriteEntity);
        }

        /// <summary>
        /// Loads the sprite.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contentfile">The contentfile.</param>
        /// <param name="spriteEntity">The sprite entity.</param>
        public void LoadSprite<T>(string contentfile, ref T spriteEntity)
        {
            spriteEntity = GameManager.ContentManager.Load<T>(contentfile);
            GameManager.TextureManager.LoadTexture(((ISpriteEntity)spriteEntity).AssetName, (ISpriteEntity)spriteEntity);
        }


        /// <summary>
        /// Loads the sprite.
        /// </summary>
        /// <param name="contentFile">The content file.</param>
        /// <returns></returns>
        public ISpriteEntity LoadSprite(string contentFile)
        {
            ISpriteEntity spriteEntity = new SpriteEntity();
            LoadSprite(contentFile, ref spriteEntity);
            return spriteEntity;
        }

        #endregion
    }
}
