using System;
using Game.Base.Interfaces;
using Game.Base.Interfaces.Model;

namespace Game.Base
{
    public class CollisionEventArgs:EventArgs
    {
        public CollisionEventArgs(ISpriteEntity collisionWithSpriteEntity)
        {
            CollisionWithSpriteEntity = collisionWithSpriteEntity;
        }

        public ISpriteEntity CollisionWithSpriteEntity { get; set; }

    }
}