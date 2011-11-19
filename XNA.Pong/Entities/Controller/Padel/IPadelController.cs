using Game.Base.Interfaces.Controller;
using Microsoft.Xna.Framework;
using XNA.Pong.Entities.Model.Padel;

namespace XNA.Pong.Entities.Controller.Padel
{
    public interface IPadelController:IController
    {
        IPadel Padel {get;set;}
        void MoveUp(GameTime gameTime);
        void MoveDown(GameTime gameTime);
    }
}