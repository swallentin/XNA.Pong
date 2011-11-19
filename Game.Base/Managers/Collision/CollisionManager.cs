using System;
using System.Collections;
using System.Collections.Generic;
using Game.Base.Interfaces;

using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;

namespace Game.Base
{
    public class CollisionManager:GameComponent, ICollisionManager
    {
        protected Hashtable CollisionObserverContainer;
        protected List<ISpriteEntity> CollisionEnties;

        public CollisionManager(Microsoft.Xna.Framework.Game game) : base(game)
        {
            CollisionObserverContainer = new Hashtable();
            CollisionEnties = new List<ISpriteEntity>();
        }

        public event CollisionEventHandler Collision;
        public void RegisterCollision(ISpriteEntity spriteEntity)
        {
            CollisionEnties.Add(spriteEntity);
        }

        public void UnregisterCollision(ISpriteEntity spriteEntity)
        {
            CollisionEnties.Add(spriteEntity);
        }

        public void PerformCollisionCheck(ISpriteEntity spriteEntityA, ISpriteEntity spriteEntityB)
        {
            Rectangle a = GetBoundingBox(spriteEntityA);
            Rectangle b = GetBoundingBox(spriteEntityB);

            if (PerformCollisionCheck(a, b))
            {
                NotifyCollisionObservers(spriteEntityA, spriteEntityB);
            }
        }

        private void NotifyCollisionObservers(ISpriteEntity spriteEntityA, ISpriteEntity spriteEntityB)
        {
            foreach (DictionaryEntry dictionaryEntry in CollisionObserverContainer)
            {
                if (dictionaryEntry.Key.ToString() == spriteEntityA.Name )
                {
                    ((ICollisionObserver)dictionaryEntry.Value).CollisionNotification(spriteEntityB);
                }
                if (dictionaryEntry.Key.ToString() == spriteEntityB.Name)
                {
                    ((ICollisionObserver)dictionaryEntry.Value).CollisionNotification(spriteEntityA);
                }
            }
        }

        public bool PerformCollisionCheck(Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }

        public Rectangle GetBoundingBox(ISpriteEntity spriteEntity)
        {
            return new Rectangle((int)spriteEntity.Position.X, (int)spriteEntity.Position.Y, spriteEntity.Size.Width, spriteEntity.Size.Height);
        }

        #region Implementation of ICollisionObservable

        public void RegisterCollisionObserver(string entityName, ICollisionObserver collisionObserver)
        {
            CollisionObserverContainer.Add(entityName, collisionObserver);
        }

        public void UnRegisterCollisionObserver(ICollisionObserver collisionObserver)
        {
            CollisionObserverContainer.Remove(collisionObserver);
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < CollisionEnties.Count; i++)
            {
                for (int j = i+1; j < CollisionEnties.Count; j++)
                {
                    PerformCollisionCheck(CollisionEnties[i], CollisionEnties[j]);
                }
            }
            base.Update(gameTime);
        }
        #endregion
    }
}