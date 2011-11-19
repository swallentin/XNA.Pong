using System;

namespace Game.Base.Configuration
{
    public sealed class ComponentActivator
    {
        public static object CreateInstance(Type type, Microsoft.Xna.Framework.Game game)
        {
            return ManagerActivator.CreateInstance(type, game);
        }
    }
}