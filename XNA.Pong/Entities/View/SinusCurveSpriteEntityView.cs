using System;
using System.Collections.Generic;
using Game.Base.Entities;
using Game.Base.Interfaces.Controller;
using Game.Base.Interfaces.Model;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Entities.View
{
    public class SinusCurveSpriteEntityView: SpriteEntityView
    {
        private readonly List<ISpriteEntity> _entitesToRender;
        private readonly ISpriteEntity _model;
        
        public SinusCurveSpriteEntityView(IController controller, ISpriteEntity model)
        {
            _entitesToRender = new List<ISpriteEntity>();
            _model = model;
        }

        public override ISpriteEntity[] GetSpriteEntitiesToRender(GameTime gameTime)
        {
            _entitesToRender.Clear();
            int length = 50;
            float angle = 0.0f;
            float angleStepsize = 0.1f;
            _model.Position = new Vector2(400, 300);
            int x = 0;
            while (angle < 2 * Math.PI)
            {
                _model.Position = new Vector2(angle + 50 + x, 250 + (float)(length * Math.Sin(angle)));
                _entitesToRender.Add(_model);
                angle += angleStepsize;
                x += 5;
            }

            return _entitesToRender.ToArray();
        }

        public override ITextEntity[] GetTextEntitiesToRender(GameTime gameTime)
        {
            return null;
        }
    }
}